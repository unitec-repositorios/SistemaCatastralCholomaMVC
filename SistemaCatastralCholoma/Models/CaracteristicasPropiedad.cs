using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class CaracteristicasPropiedad
    {
        public string idcaracRural { get; set; }
        public double area { get; set; }
        public string explotacion { get; set; }
        public string topografia { get; set; }
        public string caudal { get; set; }
        public string pozo { get; set; }
        public string viasComunicacion { get; set; }

        public CaracteristicasPropiedad() { }

        public CaracteristicasPropiedad(string id, double area, string explotacion, string topografia, string caudal, string poza, string viasComunicacion)
        {
            this.idcaracRural = id;
            this.area = area;
            this.explotacion = explotacion;
            this.topografia = topografia;
            this.caudal = caudal;
            this.pozo = poza;
            this.viasComunicacion = viasComunicacion;
        }
    }
}