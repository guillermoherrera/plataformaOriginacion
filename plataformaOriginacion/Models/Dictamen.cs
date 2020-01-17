using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    public class Dictamen
    {
        public string idDocumento { get; set; }
        public string monto { get; set; }
        public string motivoRechazo { get; set; }
        public string status { get; set; }
        public string grupoID { get; set; }
    }
}
