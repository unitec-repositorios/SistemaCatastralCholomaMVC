using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Propietario
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string teledono { get; set; }
        public string rtn { get; set; }
        public char sexo { get; set; }
        public string nacionalidad { get; set; }
    }
}