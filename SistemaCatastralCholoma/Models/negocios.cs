using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Negocios
    {
        public int idnegocios { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string tipo { get; set; }
        public double deuda { get; set; }
        public string cofundadores { get; set; }
        public string fechaFundacion { get; set; }
        public string idclavecatastral_n { get; set; }

        public Negocios() { }

        public Negocios(int idnegocios, string n, string d, string t, double de, string cof, string fech, string clave)
        {
            this.idnegocios = idnegocios;
            this.nombre = n;
            this.direccion = d;
            this.tipo = t;
            this.deuda =de;
            this.cofundadores = cof;
            this.fechaFundacion = fech;
            this.idclavecatastral_n = clave;
        }
    }
}