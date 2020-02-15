using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    [FirestoreData]
    public class Renovacion
    {
        public string solicitudID { get; set; }
        [FirestoreProperty]
        public bool? dictamen { get; set; }
        [FirestoreProperty]
        public DateTime fechaCaptura { get; set; }
        [FirestoreProperty]
        public double capital { get; set; }
        [FirestoreProperty]
        public int clienteID { get; set; }
        [FirestoreProperty]
        public int creditoID { get; set; }
        [FirestoreProperty]
        public int diasAtraso { get; set; }
        [FirestoreProperty]
        public string grupoID { get; set; }
        [FirestoreProperty]
        public string grupoNombre { get; set; }
        [FirestoreProperty]
        public int grupo_Id { get; set; }
        [FirestoreProperty]
        public double importe { get; set; }
        [FirestoreProperty]
        public string mesaControlID { get; set; }
        [FirestoreProperty]
        public string mesaControlUsuario { get; set; }
        [FirestoreProperty]
        public string nombre { get; set; }
        [FirestoreProperty]
        public int status { get; set; }
        [FirestoreProperty]
        public string ticket { get; set; }
        [FirestoreProperty]
        public int tipoContrato { get; set; }

        [FirestoreProperty]
        public double importeHistorico { get; set; }
    }
}
