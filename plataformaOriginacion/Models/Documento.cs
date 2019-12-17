using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    [FirestoreData]
    public class Documento
    {
        [FirestoreProperty]
        public int tipo { get; set; }
        [FirestoreProperty]
        public string documento { get; set; }
        [FirestoreProperty]
        public int version { get; set; }
        [FirestoreProperty]
        public bool solicitudCambio { get; set; }
        [FirestoreProperty]
        public string observacion { get; set; }
    }
}
