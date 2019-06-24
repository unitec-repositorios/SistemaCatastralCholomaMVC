using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class UsoTierra
    {
        public int idusotierra { get; set; }
        public string uso { get; set; }
        public string codigo { get; set; }
        public int idCaracRural { get; set; }

        public UsoTierra() { }

        public UsoTierra(int idusotierra, string uso, string codigo, int idCaracRural)
        {
            this.idusotierra = idusotierra;
            this.uso = uso;
            this.codigo = codigo;
            this.idCaracRural = idCaracRural;
        }
    }
}