using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class telefonoSP
    {
        public string tipo { get; set; }

        public telefonoSP() { }

        public telefonoSP(string tipo)
        {
            this.tipo = tipo;
        }
    }
}