﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Propietario
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identidad { get; set; }
        public string rtn { get; set; }
        public string telefono { get; set; }
        public string sexo { get; set; }
        public string nacionalidad { get; set; }

        public Propietario()
        {

        }

        public Propietario(int id, string nombres, string apellidos, string iden, string rtn, string telefono, string sexo, string nacionalidad)
        {

            this.id = id;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.identidad = iden;
            this.rtn = rtn;
            this.telefono = telefono;
            this.sexo = sexo;
            this.nacionalidad = nacionalidad;
        }
    }
}