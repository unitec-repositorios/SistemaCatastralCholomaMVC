using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class calleSP
    {
        public string tipo { get; set; }

        public calleSP() { }

        public calleSP(string tipo)
        {
            this.tipo = tipo;
        }
    }
}