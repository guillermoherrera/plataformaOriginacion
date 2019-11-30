using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    [FirestoreData]
    public class Direccion
    {
        [FirestoreProperty]
        public string ciudad { get; set; }
        [FirestoreProperty]
        public string coloniaPoblacion { get; set; }
        [FirestoreProperty]
        public int cp { get; set; }
        [FirestoreProperty]
        public string delegacionMunicipio { get; set; }
        [FirestoreProperty]
        public string direccion1 { get; set; }
        [FirestoreProperty]
        public string estado { get; set; }
        [FirestoreProperty]
        public string pais { get; set; }
    }
}
