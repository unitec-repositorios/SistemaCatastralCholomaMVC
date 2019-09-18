using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class naturalezaJuridica
    {
        public string tipoNaturaleza { get; set; }

        public naturalezaJuridica() { }

        public naturalezaJuridica(string tipo)
        {
            this.tipoNaturaleza = tipo;
        }
    }
}