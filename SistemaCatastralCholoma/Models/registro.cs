using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class registro
    {
        public string tipo { get; set; }

        public registro() { }

        public registro(string tipo)
        {
            this.tipo = tipo;
        }
    }
}