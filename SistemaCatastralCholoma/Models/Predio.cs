using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Predio
    {
        public string idpropietario { get; set; }
        public string barrio { get; set; }
        public string caserio { get; set; }
        public string uso { get; set; }
        public string subUso { get; set; }
        public string sitio { get; set; }

        public Predio()
        {

        }

        public Predio(string id, string barr, string caser, string use, string subUse, string site)
        {
            idpropietario = id;
            barrio = barr;
            caserio = caser;
            uso = use;
            subUso = subUse;
            sitio = site;
        }
    }
}