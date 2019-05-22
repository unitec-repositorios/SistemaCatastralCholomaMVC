using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Propiedad
    {
        public string mapa { get; set; }
        public string bloque { get; set; }
        public string predio { get; set; }
        public string propietario { get; set; }

        public Propiedad(string map, string bloq, string pred, string owner)
        {
            mapa = map;
            bloque = bloq;
            predio = pred;
            propietario = owner;
        }
    }
}