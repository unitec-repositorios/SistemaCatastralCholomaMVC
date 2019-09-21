using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class drenajeSP
    {
        public string tipo { get; set; }

        public drenajeSP() { }

        public drenajeSP(string tipo)
        {
            this.tipo = tipo;
        }
    }
}