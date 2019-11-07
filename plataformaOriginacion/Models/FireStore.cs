using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using Serilog;
using System;
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
                    if (solicitud.grupoID == null)
                    {
                        solicitudes.Add(solicitud);
                    }
                    else
                    {
                        var res = solicitudes.Find(s => s.grupoID == solicitud.grupoID);
                        if (res == null)
                        {
                            solicitudes.Add(solicitud);
                        }
                        else
                        {
                            double importe = solicitudes.Find(s => s.grupoID == solicitud.grupoID).importe;
                            solicitudes.Find(s => s.grupoID == solicitud.grupoID).importe = importe + solicitud.importe;
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
                } else {
                    solicitud.grupoNombre = "La solicitud con el id " + _ID + " no existe en la FSBD.\r\nVuelva a cargar la página desde la bandeja, si no se muestra información es probable que el asesor haya cancelado su sincronización";//Auxiliar para mostrar un mensaje de error
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
    }
}
