using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    public class FireStore
    {
        public static string claveCli;
        public static int id_xrb;

        public static FirestoreDb conexionDB() {
            var credential = GoogleCredential.FromFile("C:\\Users\\gherr\\Downloads\\SGCC-d42386a165af.json");
            Channel channel = new Channel(FirestoreClient.DefaultEndpoint.Host, FirestoreClient.DefaultEndpoint.Port, credential.ToChannelCredentials());
            FirestoreClient client = FirestoreClient.Create(channel);

            FirestoreDb db = FirestoreDb.Create("sgcc-57fde", client);
            return db;
        }

        public static async Task<List<Solicitud>> GetSolicitudesFromFireStore()
        {
            List<Solicitud> solicitudesAll = new List<Solicitud>();
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {

                FirestoreDb db = conexionDB();
                CollectionReference collection = db.Collection("Solicitudes");

                QuerySnapshot allSolicitudes = await collection.GetSnapshotAsync();

                foreach (DocumentSnapshot document in allSolicitudes.Documents)
                {
                    Solicitud solicitud = document.ConvertTo<Solicitud>();
                    solicitud.solicitudID = document.Id;
                    solicitudesAll.Add(solicitud);
                }

                //Renovaciones
                CollectionReference collectionR = db.Collection("Renovaciones");

                QuerySnapshot allSolicitudesR = await collectionR.GetSnapshotAsync();

                foreach (DocumentSnapshot document in allSolicitudesR.Documents)
                {
                    if (document.ContainsField("clienteID"))
                    {
                        Solicitud solicitud = new Solicitud
                        {
                            renovacion = true,
                            fechaCaputra = document.GetValue<DateTime>("fechaCaptura"),
                            grupoID = document.GetValue<String>("grupoID"),
                            grupoNombre = document.GetValue<String>("grupoNombre"),
                            importe = document.GetValue<double>("importe"),
                            status = document.GetValue<int>("status"),
                            tipoContrato = document.GetValue<int>("tipoContrato"),
                            userID = document.GetValue<String>("userID"),
                        };

                        try { solicitud.dictamen = document.GetValue<bool>("dictamen"); } catch (Exception e) { }
                        try
                        {
                            solicitud.mesaControlID = document.GetValue<string>("mesaControlID");
                            solicitud.mesaControlUsuario = document.GetValue<string>("mesaControlUsuario");
                        }
                        catch (Exception e) { }

                        solicitud.solicitudID = document.Id;
                        solicitudesAll.Add(solicitud);
                    }
                    else
                    {
                        Solicitud solicitud = document.ConvertTo<Solicitud>();
                        solicitud.solicitudID = document.Id;
                        solicitud.renovacion = true;
                        solicitudesAll.Add(solicitud);
                    }
                }
                //Renovaciones

                foreach (Solicitud solicitud in solicitudesAll)
                {
                    if (solicitud.grupoID == null)//INDIVIDUAL
                    {
                        solicitud.grupoNombre = solicitud.persona.nombre + " " + solicitud.persona.nombreSegundo + " " + solicitud.persona.apellido + " " + solicitud.persona.apellidoSegundo;
                        solicitudes.Add(solicitud);
                    }
                    else//GRUPAL
                    {
                        var res = solicitudes.Find(s => s.grupoID == solicitud.grupoID);
                        if (res == null)
                        {
                            solicitud.status = solicitud.status == 2 || solicitud.status == 3 ? 99 : 98;
                            if (solicitud.dictamen != null) {
                                solicitud.status = solicitud.dictamen == true ? 101 : 100; 
                            }
                            solicitudes.Add(solicitud);
                            
                        }
                        else
                        {
                            double importe = solicitudes.Find(s => s.grupoID == solicitud.grupoID).importe;
                            solicitudes.Find(s => s.grupoID == solicitud.grupoID).importe = importe + solicitud.importe;

                            int estadoGrupo = solicitudes.Find(s => s.grupoID == solicitud.grupoID).status;
                            if (estadoGrupo == 99 && solicitud.status != 2 && solicitud.status != 3)
                            {
                                solicitudes.Find(s => s.grupoID == solicitud.grupoID).status = 98;
                            }
                            if (solicitud.dictamen != null)
                            {
                                solicitudes.Find(s => s.grupoID == solicitud.grupoID).status = solicitud.dictamen == true ? 101 : 100;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception GetSolicitudesFromFireStore: {0}", ex.Message);
                //ViewBag.errores = "Error en conexión a FSBD";
            }
            return solicitudes;
        }

        public static async Task<Solicitud> GetSolicitudFromFireStore(string _ID) {

            Solicitud solicitud = new Solicitud();
            try {

                FirestoreDb db = conexionDB();
                CollectionReference collection = db.Collection("Solicitudes");
                DocumentReference docRef = collection.Document(_ID);
                DocumentSnapshot document = await docRef.GetSnapshotAsync();
                if (!document.Exists)
                {
                    collection = db.Collection("Renovaciones");
                    docRef = collection.Document(_ID);
                    document = await docRef.GetSnapshotAsync();
                }
                if (document.Exists) {
                    solicitud = document.ConvertTo<Solicitud>();
                    solicitud.solicitudID = _ID;

                    List<Documento> documentosAux = new List<Documento>();
                    foreach (Documento doc in solicitud.documentos)
                    {
                        var aux_doc = documentosAux.Find(x => x.tipo == doc.tipo);
                        if (aux_doc == null)
                        {
                            documentosAux.Add(doc);
                        }
                        else
                        {
                            if (aux_doc.version < doc.version)
                            {
                                documentosAux.Remove(aux_doc);
                                documentosAux.Add(doc);
                            }
                        }
                    }
                    solicitud.documentos = documentosAux;
                } else {
                    solicitud.grupoNombre = "La solicitud con el id " + _ID + " no existe en la FSDB.\r\nVuelva a cargar la página desde la bandeja, si no se muestra información de la solicitud vuelva a cargar los datos de la bandeja";//Auxiliar para mostrar un mensaje de error
                }
            } catch (Exception ex) {
                solicitud.grupoNombre = ex.Message;//Auxiliar para mostrar un mensaje de error
                Log.Information("*****Error Exception GetSolicitudFromFireStore: {0}", ex.Message);
            }
            return solicitud;
        }

        public static async Task<Renovacion> GetRenovacionFromFireStore(string _ID) {
            Renovacion solicitud = new Renovacion();
            try
            {
                FirestoreDb db = conexionDB();
                CollectionReference collection = db.Collection("Renovaciones");
                DocumentReference docRef = collection.Document(_ID);
                DocumentSnapshot document = await docRef.GetSnapshotAsync();
                if (document.Exists)
                {
                    solicitud = document.ConvertTo<Renovacion>();
                    solicitud.solicitudID = _ID;
                }
                else
                {
                    solicitud.grupoNombre = "La solicitud con el id " + _ID + " no existe en la FSDB.\r\nVuelva a cargar la página desde la bandeja, si no se muestra información de la solicitud vuelva a cargar los datos de la bandeja";
                }
            }
            catch(Exception ex)
            {
                solicitud.grupoNombre = ex.Message;//Auxiliar para mostrar un mensaje de error
                Log.Information("*****Error Exception GetRenovacionFromFireStore: {0}", ex.Message);
            }
            return solicitud;
        }

        //public static async Task<List<Solicitud>> GetGrupoFromFireStore(string grupoID){
        public static async Task<GrupoDetalle> GetGrupoFromFireStore(string grupoID)
        {
            GrupoDetalle grupoDetalle = new GrupoDetalle();
            List<Solicitud> solicitudes = new List<Solicitud>();
            try{
                FirestoreDb db = conexionDB();

                CollectionReference collection = db.Collection("Grupos");
                DocumentReference docRef = collection.Document(grupoID);
                DocumentSnapshot documentGpo = await docRef.GetSnapshotAsync();
                if (documentGpo.Exists)
                {
                    grupoDetalle.grupo = documentGpo.ConvertTo<Grupo>();
                }

                Query capitalQuery = db.Collection("Solicitudes").WhereEqualTo("grupoID", grupoID);
                QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
                foreach (DocumentSnapshot document in capitalQuerySnapshot.Documents){
                    Solicitud solicitud = document.ConvertTo<Solicitud>();
                    solicitud.solicitudID = document.Id;
                    solicitudes.Add(solicitud);
                }
            }
            catch(Exception ex){
                Log.Information("*****Error Exception GetGrupoFromFireStore: {0}", ex.Message);
            }
            grupoDetalle.solicitudes = solicitudes;
            return grupoDetalle;
        }

        public static async Task<GrupoDetalle> GetRenovacionGrupoFromFireStore(string grupoID)
        {
            GrupoDetalle grupoDetalle = new GrupoDetalle();
            List<Solicitud> solicitudes = new List<Solicitud>();
            try
            {
                FirestoreDb db = conexionDB();

                CollectionReference collection = db.Collection("GruposRenovacion");
                DocumentReference docRef = collection.Document(grupoID);
                DocumentSnapshot documentGpo = await docRef.GetSnapshotAsync();
                if (documentGpo.Exists)
                {
                    grupoDetalle.grupo = documentGpo.ConvertTo<Grupo>();
                }

                Query capitalQuery = db.Collection("Renovaciones").WhereEqualTo("grupoID", grupoID);
                QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
                foreach (DocumentSnapshot document in capitalQuerySnapshot.Documents)
                {
                    if (document.ContainsField("clienteID"))
                    {
                        Solicitud solicitud = new Solicitud
                        {
                            renovacion = true,
                            fechaCaputra = document.GetValue<DateTime>("fechaCaptura"),
                            grupoID = document.GetValue<String>("grupoID"),
                            grupoNombre = document.GetValue<String>("grupoNombre"),
                            importe = document.GetValue<double>("importe"),
                            status = document.GetValue<int>("status"),
                            tipoContrato = document.GetValue<int>("tipoContrato"),
                            userID = document.GetValue<String>("userID"),
                            importeHistorico = document.GetValue<int>("importeHistorico")
                        };
                        solicitud.persona = new Persona {
                            nombre = document.GetValue<string>("nombre"),
                            nombreSegundo = "",
                            apellido = "",
                            apellidoSegundo = ""
                        };
                        try { solicitud.dictamen = document.GetValue<bool>("dictamen"); } catch (Exception e) { }
                        try
                        {
                            solicitud.mesaControlID = document.GetValue<string>("mesaControlID");
                            solicitud.mesaControlUsuario = document.GetValue<string>("mesaControlUsuario");
                        }
                        catch (Exception e) { }

                        solicitud.solicitudID = document.Id;
                        solicitudes.Add(solicitud);
                    }
                    else
                    {
                        Solicitud solicitud = document.ConvertTo<Solicitud>();
                        solicitud.solicitudID = document.Id;
                        solicitudes.Add(solicitud);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception GetGrupoFromFireStore: {0}", ex.Message);
            }
            grupoDetalle.solicitudes = solicitudes;
            return grupoDetalle;
        }

        public static async Task<bool> SetControlId(string _ID, string controlID, string controlUsuario, bool grupo){
            bool result = false;
            try
            {
                FirestoreDb db = conexionDB();
                DocumentReference documentoRef;
                documentoRef = grupo ? db.Collection("Grupos").Document(_ID) : db.Collection("Solicitudes").Document(_ID);
                await db.RunTransactionAsync(async transaction =>
                {
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(documentoRef);
                    Dictionary<string, object> updates = new Dictionary<string, object>{
                        {"mesaControlID", controlID },
                        {"mesaControlUsuario", controlUsuario },
                        {"fechaAsignacion", DateTime.UtcNow}
                    };
                    transaction.Update(documentoRef, updates);

                    if (grupo)
                    {
                        Query capitalQuery = db.Collection("Solicitudes").WhereEqualTo("grupoID", _ID);
                        QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
                        foreach (DocumentSnapshot document in capitalQuerySnapshot.Documents)
                        {
                            Solicitud solicitud = document.ConvertTo<Solicitud>();
                            if (controlID == null && solicitud.documentos.Where(doc => doc.version != 1).Count() > 0) { throw new Exception("Solicitud validada"); }
                            if (controlID == null && solicitud.status != 1) { throw new Exception("Grupo con integrantes validados"); }
                            DocumentReference solicitudAux = db.Collection("Solicitudes").Document(document.Id);
                            transaction.Update(solicitudAux, updates);
                        }
                    }
                    else
                    {
                        Solicitud solicitudAux = snapshot.ConvertTo<Solicitud>();
                        if (controlID == null && solicitudAux.documentos.Where(doc => doc.version != 1).Count() > 0) { throw new Exception("Solicitud validada"); }
                        if (controlID == null && solicitudAux.status !=  1) { throw new Exception("Solicitud validada"); }
                    }
                });
                result = true;
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception SetControlId: {0}", ex.Message);
                result = false;
            }
            return result;
        }

        public static async Task<bool> SetRenovacionControlId(string _ID, string controlID, string controlUsuario, bool grupo)
        {
            bool result = false;
            try
            {
                FirestoreDb db = conexionDB();
                DocumentReference documentoRef;
                documentoRef = grupo ? db.Collection("GruposRenovacion").Document(_ID) : db.Collection("Renovaciones").Document(_ID);
                await db.RunTransactionAsync(async transaction =>
                {
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(documentoRef);
                    Dictionary<string, object> updates = new Dictionary<string, object>{
                        {"mesaControlID", controlID },
                        {"mesaControlUsuario", controlUsuario },
                        {"fechaAsignacion", DateTime.UtcNow}
                    };
                    transaction.Update(documentoRef, updates);

                    if (grupo)
                    {
                        Query capitalQuery = db.Collection("Renovaciones").WhereEqualTo("grupoID", _ID);
                        QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
                        foreach (DocumentSnapshot document in capitalQuerySnapshot.Documents)
                        {
                            Solicitud solicitud = document.ConvertTo<Solicitud>();
                            if (controlID == null && solicitud.documentos.Where(doc => doc.version != 1).Count() > 0) { throw new Exception("Solicitud validada"); }
                            if (controlID == null && solicitud.status != 1) { throw new Exception("Grupo con integrantes validados"); }
                            DocumentReference solicitudAux = db.Collection("Renovaciones").Document(document.Id);
                            transaction.Update(solicitudAux, updates);
                        }
                    }
                    else
                    {
                        Solicitud solicitudAux = snapshot.ConvertTo<Solicitud>();
                        if (controlID == null && solicitudAux.documentos.Where(doc => doc.version != 1).Count() > 0) { throw new Exception("Solicitud validada"); }
                        if (controlID == null && solicitudAux.status != 1) { throw new Exception("Solicitud validada"); }
                    }
                });
                result = true;
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception SetControlId: {0}", ex.Message);
                result = false;
            }
            return result;
        }

        public static async Task<List<catDocumento>> GetCatDocumentosFromFirestore() {
            List<catDocumento> catDocumentos = new List<catDocumento>();
            try{
                FirestoreDb db = conexionDB();
                CollectionReference collection = db.Collection("catDocumentos");
                QuerySnapshot allCatDocuemntos = await collection.GetSnapshotAsync();
                foreach (DocumentSnapshot document in allCatDocuemntos.Documents)
                {
                    catDocumento catDocumento = document.ConvertTo<catDocumento>();
                    catDocumentos.Add(catDocumento);
                }
            }
            catch(Exception ex){
                Log.Information("*****Error Exception GetCatDocumentosFromFirestore: {0}", ex.Message);
            }
            return catDocumentos;
        }

        public static async Task<bool> ActualizaIdentificacion(ActualizaInformacion actualizaInformacion) {
            bool result = false;
            try
            {
                FirestoreDb db = conexionDB();
                DocumentReference solicitud = db.Collection("Solicitudes").Document(actualizaInformacion.idDocumento);
                await db.RunTransactionAsync(async transaction => {
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(solicitud);
                    if (!snapshot.Exists)
                    {
                        solicitud = db.Collection("Renovaciones").Document(actualizaInformacion.idDocumento);
                        snapshot = await transaction.GetSnapshotAsync(solicitud);
                    }
                    if (snapshot.ConvertTo<Solicitud>().mesaControlID == null) { throw new Exception("Solicitud no Asignada"); }
                    Dictionary<string, object> updates = new Dictionary<string, object>();
                    Dictionary<string, object> datos = new Dictionary<string, object> {
                        {"nombre", actualizaInformacion.pNombre == null ? "" : actualizaInformacion.pNombre},
                        {"nombreSegundo", actualizaInformacion.sNombre == null ? "" : actualizaInformacion.sNombre },
                        {"apellido", actualizaInformacion.pApellido == null ? "" : actualizaInformacion.pApellido },
                        {"apellidoSegundo", actualizaInformacion.sApellido == null ? "" : actualizaInformacion.sApellido },
                        {"curp", actualizaInformacion.curp == null ? "" : actualizaInformacion.curp },
                        {"rfc", actualizaInformacion.rfc == null ? "" : actualizaInformacion.rfc },
                        {"fechaNacimiento", DateTime.SpecifyKind(actualizaInformacion.fNacimiento, DateTimeKind.Utc) },
                        {"telefono", actualizaInformacion.telefono == null ? "" : actualizaInformacion.telefono }
                    };
                    updates.Add("persona", datos);
                    transaction.Update(solicitud, updates);
                });
                result = true;
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception ActualizaIdentificacion: {0}", ex.Message);
                result = false;
            }
            return result;
        }

        public static async Task<bool> ActualizaUbicacion(ActualizaUbicacion actualizaUbicacion) {
            bool result = false;
            try
            {
                FirestoreDb db = conexionDB();
                DocumentReference solicitud = db.Collection("Solicitudes").Document(actualizaUbicacion.idDocumento);
                await db.RunTransactionAsync(async transaction =>{
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(solicitud);
                    if (!snapshot.Exists) {
                        solicitud = db.Collection("Renovaciones").Document(actualizaUbicacion.idDocumento);
                        snapshot = await transaction.GetSnapshotAsync(solicitud);
                    }
                    if (snapshot.ConvertTo<Solicitud>().mesaControlID == null) { throw new Exception("Solicitud no Asignada"); }
                    Dictionary<string, object> updates = new Dictionary<string, object>();
                    Dictionary<string, object> datos = new Dictionary<string, object>{
                        {"direccion1", actualizaUbicacion.calle == null ? "" : actualizaUbicacion.calle},
                        {"coloniaPoblacion", actualizaUbicacion.colonia == null ? "" : actualizaUbicacion.colonia},
                        {"delegacionMunicipio", actualizaUbicacion.municipio == null ? "" : actualizaUbicacion.municipio},
                        {"ciudad", actualizaUbicacion.ciudad == null ? "" : actualizaUbicacion.ciudad},
                        {"estado", actualizaUbicacion.estado == null ? "" : actualizaUbicacion.estado},
                        {"cp", int.Parse(actualizaUbicacion.cp)},
                        {"pais", actualizaUbicacion.pais == null ? "" : actualizaUbicacion.pais}
                    };
                    updates.Add("direccion", datos);
                    transaction.Update(solicitud, updates);
                });
                result = true;
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception ActualizaUbicacion: {0}", ex.Message);
                result = false;
            }
            return result;
        }

        /*public static async Task<RequestResult> ConsultaBuro(string _ID, string CveCli, int idXRB)
        {
            RequestResult result = new RequestResult { error = 1 };
            try
            {
                FirestoreDb db = conexionDB();
                DocumentReference solicitud = db.Collection("Solicitudes").Document(_ID);
                await db.RunTransactionAsync(async transaction => {
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(solicitud);
                    if (!snapshot.Exists)
                    {
                        solicitud = db.Collection("Renovaciones").Document(_ID);
                        snapshot = await transaction.GetSnapshotAsync(solicitud);
                    }
                    Dictionary<string, object> updates = new Dictionary<string, object> {
                        {"CveCli", CveCli },
                        {"idXRB", idXRB }
                    };
                    transaction.Update(solicitud, updates);
                });
                result.error = 0;
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception CambioEstado: {0}", ex.Message);
                result.error = 1;
                result.result = ex.Message;
            }
            return result;
        }*/

        public static async Task<RequestResult> CambioEstado(string _ID, int status, string grupo, double monto, string motivoRechazo) {
            RequestResult result = new RequestResult { error = 1};
            try
            {
                if (!(status == 7 || status == 2 || status == 3 || status == 6)) { throw new Exception("Status no válido"); }
                FirestoreDb db = conexionDB();
                DocumentReference solicitud = db.Collection("Solicitudes").Document(_ID);
                DocumentReference grupoRef = grupo == null  ? null : db.Collection("Grupos").Document(grupo);
                await db.RunTransactionAsync(async transaction => {
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(solicitud);
                    if (!snapshot.Exists)
                    {
                        solicitud = db.Collection("Renovaciones").Document(_ID);
                        snapshot = await transaction.GetSnapshotAsync(solicitud);
                    }
                    DocumentSnapshot snapshotGpo = grupo == null ? null : await transaction.GetSnapshotAsync(grupoRef);
                    if (snapshotGpo != null && !snapshotGpo.Exists)
                    {
                        grupoRef = db.Collection("GruposRenovacion").Document(grupo);
                        snapshotGpo = await transaction.GetSnapshotAsync(grupoRef);
                    }
                    Dictionary<string, object> updates = new Dictionary<string, object>();
                    if (status == 7 && (snapshot.ConvertTo<Solicitud>().status != 1 && snapshot.ConvertTo<Solicitud>().status != 10)) { throw new Exception("cambio de Status no permitido"); }
                    if(status == 7)
                    {
                        Solicitud solicitud1 = snapshot.ConvertTo<Solicitud>();
                        solicitud1.solicitudID = _ID;
                        RequestResult result1 = await RegistroSolicitudConsultaBuro(solicitud1);
                        if (result1.error == 1) { throw new Exception(result1.result);  }
                        updates.Add("CB_CveCli", claveCli);
                        updates.Add("CB_idXRB", id_xrb);
                    }
                    if (status == 2 && snapshot.ConvertTo<Solicitud>().status != 9) { throw new Exception("cambio de Status no permitido"); }
                    if (status == 3 && snapshot.ConvertTo<Solicitud>().status != 9) { throw new Exception("cambio de Status no permitido"); }
                    int newStatus = status;
                    bool dictamen = false;
                    if (status == 2) { dictamen = true; } else { dictamen = false; }
                    updates.Add("status", newStatus);
                    /*Dictionary<string, object> updates = new Dictionary<string, object> {
                        {"status", newStatus },
                        //{"dictamen", dictamen }
                    };*/
                    if ((status == 2 || status == 3) && grupo == null){ updates.Add("dictamen", dictamen); }//agregar si es o no individual
                    if (status == 2 || status == 3){ updates.Add("importeSolicitado", snapshot.ConvertTo<Solicitud>().importe ); }
                    if (status == 2 || status == 3) { updates.Add("fechaDictamen", DateTime.UtcNow); }
                    //if (status == 2) { updates.Add("importe", monto); }
                    if (status == 3) { updates.Add("motivoRechazo", motivoRechazo); }
                    if (snapshot.ConvertTo<Solicitud>().mesaControlID == null) { throw new Exception("Solicitud no Asignada"); }

                    if(status == 2 && snapshot.ConvertTo<Solicitud>().importe > monto)
                    {
                        updates.Add("importe", monto);
                        if (snapshotGpo != null)
                        {
                            double diferencia = snapshot.ConvertTo<Solicitud>().importe - monto;
                            double importeGpo = snapshotGpo.ConvertTo<Grupo>().importe - diferencia;
                            Dictionary<string, object> updatesGpo = new Dictionary<string, object> {
                                {"importe", importeGpo },
                                //{"dictamen", dictamen }
                            };
                            transaction.Update(grupoRef, updatesGpo);
                        }
                    }
                    transaction.Update(solicitud, updates);
                });
                result.error = 0;
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception CambioEstado: {0}", ex.Message);
                result.error = 1;
                result.result = ex.Message;
            }
            return result;
        }

        public static async Task<bool> DictamenGrupo(string _ID, int aut, string motivo) {
            bool result = false, renov = false;
            try
            {
                FirestoreDb db = conexionDB();
                DocumentReference grupo = db.Collection("Grupos").Document(_ID);
                await db.RunTransactionAsync(async transaction => {
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(grupo);
                    if (!snapshot.Exists)
                    {
                        grupo = db.Collection("GruposRenovacion").Document(_ID);
                        snapshot = await transaction.GetSnapshotAsync(grupo);
                    }
                    int newStatus = 3;
                    bool dictamen = aut == 0 ? false : true;
                    Dictionary<string, object> updates = new Dictionary<string, object> {
                        {"status", newStatus },
                        {"dictamen", dictamen },
                        {"fechaDictamen", DateTime.UtcNow }
                    };
                    if (aut == 0) { updates.Add("motivoRechazo", motivo); }
                    if (snapshot.ConvertTo<Grupo>().mesaControlID == null) { throw new Exception("Grupo no Asignado"); }
                    if (snapshot.ConvertTo<Grupo>().status == 3) { throw new Exception("cambio de Status no permitido"); }
                    transaction.Update(grupo, updates);

                    Query capitalQuery = db.Collection("Solicitudes").WhereEqualTo("grupoID", _ID);
                    QuerySnapshot capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
                    if(capitalQuerySnapshot.Documents.Count() == 0){
                        capitalQuery = db.Collection("Renovaciones").WhereEqualTo("grupoID", _ID);
                        capitalQuerySnapshot = await capitalQuery.GetSnapshotAsync();
                        renov = capitalQuerySnapshot.Documents.Count() == 0 ? false : true;
                    }
                    foreach (DocumentSnapshot document in capitalQuerySnapshot.Documents)
                    {
                        //Solicitud solicitud = document.ConvertTo<Solicitud>();
                        //solicitud.solicitudID = document.Id;
                        DocumentReference solicitudAux;
                        if (!renov) {
                            solicitudAux = db.Collection("Solicitudes").Document(document.Id);
                        } else{
                            solicitudAux = db.Collection("Renovaciones").Document(document.Id);
                        }
                        Dictionary<string, object> updatesSol = new Dictionary<string, object> {
                            {"dictamen", dictamen }
                        };
                        transaction.Update(solicitudAux, updatesSol);
                    }
                });

                //List<Solicitud> solicitudes = await GetGrupoFromFireStore(_ID);
                /*GrupoDetalle grupoDetalle = await GetGrupoFromFireStore(_ID);
                foreach (Solicitud solicitud in grupoDetalle.solicitudes)
                {
                    DocumentReference solicitudAux = db.Collection("Solicitudes").Document(solicitud.solicitudID);
                    await db.RunTransactionAsync(async transaction => {
                        DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(solicitudAux);
                        bool dictamen = aut == 0 ? false : true;
                        Dictionary<string, object> updates = new Dictionary<string, object> {
                            {"dictamen", dictamen }
                        };
                        transaction.Update(solicitudAux, updates);
                    });
                }*/
                result = true;
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception CambioEstado: {0}", ex.Message);
                result = false;
            }
            return result;
        }

        public static async Task<bool> solicitarCambioDoc(CambioDoc cambioDoc) {
            bool result = false;
            Solicitud solicitud = new Solicitud();
            try
            {

                FirestoreDb db = conexionDB();
                CollectionReference collection = db.Collection("Solicitudes");
                DocumentReference docRef = collection.Document(cambioDoc.idDocumento);
                DocumentSnapshot document = await docRef.GetSnapshotAsync();
                if (!document.Exists)
                {
                    collection = db.Collection("Renovaciones");
                    docRef = collection.Document(cambioDoc.idDocumento);
                    document = await docRef.GetSnapshotAsync();
                }
                if (document.Exists)
                {
                    solicitud = document.ConvertTo<Solicitud>();
                    if (solicitud.mesaControlID == null) { throw new Exception("Solicitud no Asignada"); }
                    if (solicitud.status != 1 && solicitud.status != 6 && solicitud.status != 10) { throw new Exception("cambio de Status no permitido"); }
                    solicitud.solicitudID = cambioDoc.idDocumento;
                    var docEditar = solicitud.documentos.Where(doc => doc.tipo == int.Parse(cambioDoc.tipo) && doc.version == int.Parse(cambioDoc.version)).FirstOrDefault();
                    if (docEditar != null)
                    {
                        if (docEditar.solicitudCambio == true) { throw new Exception("Solicitud de cambio ya realizado previamente."); }
                        docEditar.observacion = cambioDoc.observacion;
                        docEditar.solicitudCambio = true;
                        Dictionary<string, object> updates = new Dictionary<string, object>();
                        ArrayList arregloDocumentos = new ArrayList();
                        foreach (Documento doc in solicitud.documentos)
                        {
                            Dictionary<string, object> objetoDocumento = new Dictionary<string, object>
                            {
                                { "documento", doc.documento },
                                { "tipo", doc.tipo },
                                { "version", doc.version },
                            };
                            if (doc.solicitudCambio)
                            {
                                objetoDocumento.Add("solicitudCambio", doc.solicitudCambio);
                                objetoDocumento.Add("observacion", doc.observacion);
                            }
                            arregloDocumentos.Add(objetoDocumento);
                        }
                        updates.Add("documentos", arregloDocumentos);
                        updates.Add("status", 6);

                        await db.RunTransactionAsync(async transaction => {
                            DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(docRef);
                            
                            transaction.Update(docRef, updates);
                        });

                        result = true;
                    }
                    else
                    {
                        throw new Exception("Ha ocurrido un error al encontrar el documento con el tipo " + cambioDoc.tipo + " y la versión "+ cambioDoc.version+" de la solicitud con el ID " + cambioDoc.idDocumento);
                    }
                }
                else
                {
                    throw new Exception("Solicitud con el ID "+ cambioDoc.idDocumento + " No Encotrada");
                }
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception GetSolicitudFromFireStore: {0}", ex.Message);
            }
            return result;
        }

        //
        static HttpClient client = new HttpClient();
        
        public static async Task<RequestResult> RegistroSolicitudConsultaBuro(Solicitud solicitud) {
            RequestResult result1 = new RequestResult();
            result1.error = 1;
            string url = "http://192.168.0.33:4000/registro/cliente_buro";
            Cliente cliente = new Cliente {
                sistema = solicitud.sistema,
                usuarioRegistra = int.Parse(solicitud.mesaControlID),
                userID = solicitud.userID,
                solicitudID = solicitud.solicitudID,
                nombre = solicitud.persona.nombre,
                apellidoPat = solicitud.persona.apellido,
                apellidoMat = solicitud.persona.apellidoSegundo,
                TelCel = solicitud.persona.telefono,
                rfc = solicitud.persona.rfc,
                fechaNac = solicitud.persona.fechaNacimiento.ToString("dd/MM/yy"),
                nombreVialidad = solicitud.direccion.direccion1,
                curp = solicitud.persona.curp,
                cp = solicitud.direccion.cp.ToString(),
                nombreAdicional = solicitud.persona.nombreSegundo,
                estado = solicitud.direccion.estado,
                municipio = solicitud.direccion.delegacionMunicipio,
                colonia = solicitud.direccion.coloniaPoblacion,
                ciudad = solicitud.direccion.ciudad
            };
            try 
            {
                //client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("x-api-key", "doCLjcd9FIABAzXhF49AMDTPJqo608M5Wau");
                using (var content = new StringContent(JsonConvert.SerializeObject(cliente), System.Text.Encoding.UTF8, "application/json"))
                {
                    var result = await client.PostAsync($"{url}", content);
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        result1.error = 0;
                        string resultContent = await result.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(resultContent);
                        claveCli = json["CveCli"].ToString();
                        id_xrb = int.Parse(json["idXRB"].ToString());
                        /*RequestResult result2 = await ConsultaBuro(solicitud.solicitudID, json["CveCli"].ToString(), int.Parse(json["idXRB"].ToString()));
                        if(result2.error == 1)
                        {
                            throw new Exception(result2.result);
                        }*/
                    }
                    else
                    {
                        string resultContent = await result.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(resultContent);
                        result1.result = "ws --> "+json["resultDesc"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Information("*****Error Exception CambioEstado: {0}", ex.Message);
                result1.result = ex.Message;
            }
            
            return result1;
        }
    }
}
