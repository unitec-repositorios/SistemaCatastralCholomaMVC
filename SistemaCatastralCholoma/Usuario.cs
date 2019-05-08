using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string password { get; set; }

        public Usuario(string  nomb, string pass)
        {
            nombre = nomb;
            password = pass;
        }
    }
}