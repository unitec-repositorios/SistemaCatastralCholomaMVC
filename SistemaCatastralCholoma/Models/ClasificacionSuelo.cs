using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class ClasificacionSuelo
    {
        public string idclasificacionsuelo { get; set; }
        public double fRiego { get; set; }
        public int codigo { get; set; }
        public double area { get; set; }
        public string idClaveCatastral { get; set; }

        public ClasificacionSuelo() { }

        public ClasificacionSuelo(string id, double friego, int cod, double area, string idcc)
        {
            this.idclasificacionsuelo = id;
            this.fRiego = friego;
            this.codigo = cod;
            this.area = area;
            this.idClaveCatastral = idcc;
        }
    }
}