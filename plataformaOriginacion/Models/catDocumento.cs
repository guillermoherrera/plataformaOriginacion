using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    [FirestoreData]
    public class catDocumento
    {
        [FirestoreProperty]
        public string descDocumento { get; set; }
        [FirestoreProperty]
        public int tipo { get; set; }
    }
}
