using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Propietario
    {
        public string id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string rtn { get; set; }
        public string sexo { get; set; }
        public string nacionalidad { get; set; }

        public Propietario()
        {

        }

        public Propietario(string id, string nombres, string apellidos, string telefono, string rtn, char sexo, string nacionalidad)
        {
            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.rtn = rtn;
            this.sexo = sexo;
            this.nacionalidad = nacionalidad;
        }
    }
}