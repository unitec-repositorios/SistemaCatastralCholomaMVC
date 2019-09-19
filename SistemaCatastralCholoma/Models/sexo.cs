using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class sexo
    {
        public string tipo { get; set; }

        public sexo() { }

        public sexo(string sexo)
        {
            this.tipo = sexo;
        }

    }
}