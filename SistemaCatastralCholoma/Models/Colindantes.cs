using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Colindantes
    {
        public int idcolindantes { get; set; }
        public string Norte { get; set; }
        public string Sur { get; set; }
        public string Este { get; set; }
        public string Oeste { get; set; }
        public string idDatosComplementarios { get; set; }

        public Colindantes() { }

        public Colindantes(int id, string n, string s, string e, string o, string idDC)
        {
            this.idcolindantes = id;
            this.Norte = n;
            this.Sur = s;
            this.Este = e;
            this.Oeste = o;
            this.idDatosComplementarios = idDC;
        }
    }
}