using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class alumPubSP
    {
        public string tipo { get; set; }

        public alumPubSP() { }

        public alumPubSP(string tipo)
        {
            this.tipo = tipo;
        }
    }
}