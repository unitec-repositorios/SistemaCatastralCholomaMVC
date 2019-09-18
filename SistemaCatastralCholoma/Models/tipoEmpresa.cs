using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class tipoEmpresa
    {
        public string empresa { get; set; }

        public tipoEmpresa() { }

        public tipoEmpresa(string empresa)
        {
            this.empresa = empresa;
        }
    }
}