using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    [FirestoreData]
    public class Persona
    {
        [FirestoreProperty]
        public string apellido { get; set; }
        [FirestoreProperty]
        public string apellidoSegundo { get; set; }
        [FirestoreProperty]
        public string nombre { get; set; }
        [FirestoreProperty]
        public string nombreSegundo { get; set; }
        [FirestoreProperty]
        public string curp { get; set; }
        [FirestoreProperty]
        public DateTime fechaNacimiento { get; set; }
        [FirestoreProperty]
        public string rfc { get; set; }
        [FirestoreProperty]
        public string telefono { get; set; }
    }
}
