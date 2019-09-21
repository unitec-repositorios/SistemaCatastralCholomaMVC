using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class electricidadSP
    {
        public string tipo { get; set; }

        public electricidadSP() { }
        
        public electricidadSP(string tipo)
        {
            this.tipo = tipo;
        }
    }
}