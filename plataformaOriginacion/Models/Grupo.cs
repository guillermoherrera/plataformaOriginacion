using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    [FirestoreData]
    public class Grupo
    {
        [FirestoreProperty]
        public bool? dictamen { get; set; }
        [FirestoreProperty]
        public double importe { get; set; }
        [FirestoreProperty]
        public int integrantes { get; set; }
        [FirestoreProperty]
        public string nombre { get; set; }
        [FirestoreProperty]
        public int status { get; set; }
        [FirestoreProperty]
        public string userID { get; set; }
        [FirestoreProperty]
        public string mesaControlID { get; set; }
        [FirestoreProperty]
        public string mesaControlUsuario { get; set; }
        [FirestoreProperty]
        public int sistema { get; set; }
    }
}
