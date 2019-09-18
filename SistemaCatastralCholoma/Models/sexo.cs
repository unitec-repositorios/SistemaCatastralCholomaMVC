using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class mantenimientoSexo
    {
        public string tipo { get; set; }

        public mantenimientoSexo() { }

        public mantenimientoSexo(string sexo)
        {
            this.tipo = sexo;
        }

    }
}