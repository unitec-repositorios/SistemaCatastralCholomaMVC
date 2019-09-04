using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Empleado
    {
        public string nombre { get; set; }
        public string password { get; set; }
        public string tipo { get; set; }

        public Empleado(){}

        public Empleado(string  nombre, string password, string tipo)
        {
            this.nombre = nombre;
            this.password = password;
            this.tipo = tipo;
        }
    }
}