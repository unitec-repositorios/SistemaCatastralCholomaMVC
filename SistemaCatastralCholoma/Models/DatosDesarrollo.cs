using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class DatosDesarrollo
    {
        public string iddatosdesarrollo { get; set; }
        public double area { get; set; }
        public double servicios { get; set; }
        public double topografia { get; set; }
        public double configuracion { get; set; }

        public DatosDesarrollo() { }

        public DatosDesarrollo(string id, double area, double serv, double top, double config)
        {
            this.iddatosdesarrollo = id;
            this.area = area;
            this.servicios = serv;
            this.topografia = top;
            this.configuracion = config;
        }
    }
}