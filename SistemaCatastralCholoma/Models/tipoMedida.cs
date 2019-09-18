using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class tipoMedida
    {
        public string medida { get; set; }

        public tipoMedida() { }

        public tipoMedida(string medida)
        {
            this.medida = medida;
        }
    }
}