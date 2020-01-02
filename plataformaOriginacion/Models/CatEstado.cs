using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plataformaOriginacion.Models
{
    public class CatEstado
    {
        public string clave { get; set; }
        public string estado { get; set; }

        public static List<CatEstado> fillEstados() {
            List<CatEstado> catEstados = new List<CatEstado>(); 
            CatEstado catEstado = new CatEstado{clave = "TAM", estado = "TAMAULIPAS" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "CHS", estado = "CHIAPAS" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "TLAX", estado = "TLAXCALA" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "GTO", estado = "GUANAJUATO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "COL", estado = "COLIMA" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "CDMX", estado = "CIUDAD DE MÉXICO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "NL", estado = "NUEVO LEÓN" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "TAB", estado = "TABASCO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "CHI", estado = "CHIHUAHUA" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "BCN", estado = "BAJA CALIFORNIA NORTE" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "ZAC", estado = "ZACATECAS" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "PUE", estado = "PUEBLA" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "MICH", estado = "MICHOACÁN" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "SIN", estado = "SINALOA" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "COA", estado = "COAHUILA" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "JAL", estado = "JALISCO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "YUC", estado = "YUCATÁN" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "SLP", estado = "SAN LUIS POTOSÍ" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "GRO", estado = "GUERRERO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "EM", estado = "ESTADO DE MÉXICO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "SON", estado = "SONORA" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "QR", estado = "QUINTANA ROO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "VER", estado = "VERACRUZ" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "QRO", estado = "QUERETARO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "OAX", estado = "OAXACA" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "NAY", estado = "NAYARIT" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "CAM", estado = "CAMPECHE" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "DUR", estado = "DURANGO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "HGO", estado = "HIDALGO" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "MOR", estado = "MORELOS" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "BCS", estado = "BAJA CALIFORNIA SUR" };
            catEstados.Add(catEstado);
            catEstado = new CatEstado { clave = "AGS", estado = "AGUASCALIENTES" };
            catEstados.Add(catEstado);
            catEstados.Sort((p, q) => p.clave.CompareTo(q.clave));
            return catEstados;
        }
    }
}
