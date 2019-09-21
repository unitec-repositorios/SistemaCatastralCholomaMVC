using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class aguaSP
    {
        public string tipo { get; set; }

        public aguaSP() { }

        public aguaSP(string tipo)
        {
            this.tipo = tipo;
        }
    }
}