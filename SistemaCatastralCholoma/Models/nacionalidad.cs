using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class nacionalidad
    {
        public string pais { get; set; }

        public nacionalidad() { }

        public nacionalidad(string pais)
        {
            this.pais = pais;
        }
    }
}