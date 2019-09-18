using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class tipoDocumento
    {
        public string tipoDoc { get; set; }

        public tipoDocumento() { }
        public tipoDocumento(string tipo)
        {
            this.tipoDoc = tipo;
        }
    }
}