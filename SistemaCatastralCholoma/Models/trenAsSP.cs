using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class trenAsSP
    {
        public string tipo { get; set; }

        public trenAsSP() { }

        public trenAsSP(string tipo)
        {
            this.tipo = tipo;
        }
    }
}