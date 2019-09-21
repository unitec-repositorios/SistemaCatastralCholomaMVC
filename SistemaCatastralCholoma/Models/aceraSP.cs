using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class aceraSP
    {
        public string tipo { get; set; }

        public aceraSP() { }

        public aceraSP(string tipo)
        {
            this.tipo = tipo;
        }
    }
}