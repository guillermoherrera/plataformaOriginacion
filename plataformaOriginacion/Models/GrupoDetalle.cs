using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    [FirestoreData]
    public class GrupoDetalle
    {
        public Grupo grupo { get; set; }
        public List<Solicitud> solicitudes { get; set; }
    }
}
