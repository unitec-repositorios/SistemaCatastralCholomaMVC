using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class mantenimientoPropietarios
    {
        public int id { get; set; }
        public string sexo { get; set; }
        public string nacionalidad { get; set; }

        public mantenimientoPropietarios() { }

        public mantenimientoPropietarios(int id, string sexo, string nacionalidad)
        {
            this.id = id;
            this.sexo = sexo;
            this.nacionalidad = nacionalidad;
        }

    }
}