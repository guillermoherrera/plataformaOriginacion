using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    public class ActualizaInformacion
    {
        public string idDocumento {get;set;}
        public string pNombre { get; set; }
        public string sNombre { get; set; }
        public string pApellido { get; set; }
        public string sApellido { get; set; }
        public string curp { get; set; }
        public string rfc { get; set; }
        public DateTime fNacimiento { get; set; }
        public string telefono { get; set; }
    }
}
