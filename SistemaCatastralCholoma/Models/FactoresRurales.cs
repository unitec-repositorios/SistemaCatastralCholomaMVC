using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class FactoresRurales
    {
        public int idFactoresRurales { get; set; }
        public double area { get; set; }
        public double ubicacion { get; set; }
        public double servicios { get; set; }
        public double acceso { get; set; }
        public double agua { get; set; }

        public FactoresRurales() { }

        public FactoresRurales(int idFactoresRurales, double area, double ubicacion, double servicios,
            double acceso, double agua)
        {
            this.idFactoresRurales = idFactoresRurales;
            this.area = area;
            this.ubicacion = ubicacion;
            this.servicios = servicios;
            this.acceso = acceso;
            this.agua = agua;
        }
    }
}