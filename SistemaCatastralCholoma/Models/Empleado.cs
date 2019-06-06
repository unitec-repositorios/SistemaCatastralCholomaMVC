using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma
{
    public class Empleado
    {
        public string nombre { get; set; }
        public string password { get; set; }
        public TIPO_EMPLEADO tipo { get; set; }

        public Empleado(){}

        public Empleado(string  nombre, string password, TIPO_EMPLEADO tipo)
        {
            this.nombre = nombre;
            this.password = password;
            this.tipo = tipo;
        }
    }
}