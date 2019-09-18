using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class servicio
    {
        public string serv { get; set; }

        public servicio() { }

        public servicio(string serv)
        {
            this.serv = serv;
        }
    }
}