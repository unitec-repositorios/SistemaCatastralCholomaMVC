using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class UsoTierra
    {
        public int idUsoTierra { get; set; }
        public string uso { get; set; }
        public string codigo { get; set; }
        public int idCaracRural { get; set; }

        public UsoTierra() { }

        public UsoTierra(int idUsoTierra, string uso, string codigo, int idCaracRural)
        {
            this.idUsoTierra = idUsoTierra;
            this.uso = uso;
            this.codigo = codigo;
            this.idCaracRural = idCaracRural;
        }
    }
}