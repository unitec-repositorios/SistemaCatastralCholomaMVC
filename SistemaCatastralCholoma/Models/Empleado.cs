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
        public int tipo { get; set; }
        public string usertype { get; set; }
        public Empleado(){}

        public Empleado(string  nombre, string password, int tipo, string UserType)
        {
            this.nombre = nombre;
            this.password = password;
            this.tipo = tipo;
            this.usertype = UserType;
        }
    }
}