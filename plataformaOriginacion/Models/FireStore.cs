using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    public class FireStore
    {

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

                foreach (Solicitud solicitud in solicitudesAll)
                {
                    if (solicitud.grupoID == null)//INDIVIDUAL
                    {
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

        public static async Task<List<Solicitud>> GetGrupoFromFireStore(string grupoID){
            List<Solicitud> solicitudes = new List<Solicitud>();
            try{
                FirestoreDb db = conexionDB();
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
            return solicitudes;
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

        public static async Task<bool> CambioEstado(string _ID, int status, string grupo) {
            bool result = false;
            try
            {
                FirestoreDb db = conexionDB();
                DocumentReference solicitud = db.Collection("Solicitudes").Document(_ID);
                await db.RunTransactionAsync(async transaction => {
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(solicitud);
                    int newStatus = status;
                    bool dictamen = false;
                    if (status == 2) { dictamen = true; } else { dictamen = false; }
                    Dictionary<string, object> updates = new Dictionary<string, object> {
                        {"status", newStatus },
                        //{"dictamen", dictamen }
                    };
                    if ((status == 2 || status == 3) && grupo == null){ updates.Add("dictamen", dictamen); }//agregar si es o no individual
                    transaction.Update(solicitud, updates);
                });
                result = true;
            }
            catch (Exception ex)
            {
                Log.Information("*****Error Exception CambioEstado: {0}", ex.Message);
                result = false;
            }
            return result;
        }

        public static async Task<bool> DictamenGrupo(string _ID, int aut) {
            bool result = false;
            try
            {
                FirestoreDb db = conexionDB();
                DocumentReference grupo = db.Collection("Grupos").Document(_ID);
                await db.RunTransactionAsync(async transaction => {
                    DocumentSnapshot snapshot = await transaction.GetSnapshotAsync(grupo);
                    int newStatus = 3;
                    bool dictamen = aut == 0 ? false : true;
                    Dictionary<string, object> updates = new Dictionary<string, object> {
                        {"status", newStatus },
                        {"dictamen", dictamen }
                    };
                    transaction.Update(grupo, updates);
                });

                List<Solicitud> solicitudes = await GetGrupoFromFireStore(_ID);
                foreach (Solicitud solicitud in solicitudes)
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
                }
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
                if (document.Exists)
                {
                    solicitud = document.ConvertTo<Solicitud>();
                    solicitud.solicitudID = cambioDoc.idDocumento;
                    var docEditar = solicitud.documentos.Where(doc => doc.tipo == int.Parse(cambioDoc.tipo) && doc.version == int.Parse(cambioDoc.version)).FirstOrDefault();
                    if (docEditar != null)
                    {
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
    }
}
