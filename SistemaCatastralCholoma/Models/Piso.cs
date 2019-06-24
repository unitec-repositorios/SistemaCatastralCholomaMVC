using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Piso
    {
        public int idpiso { get; set; }
        public int num { get; set; }
        public double area { get; set; }
        public int uso { get; set; }
        public string clase { get; set; }
        public string calidad { get; set; }
        public double costo { get; set; }
        public string bueno { get; set; }
        public string idAvaluoEdificaciones { get; set; }

        public Piso() { }

        public Piso(int idpiso, int num, double area, int uso, string clase, string calidad,
            double costo, string bueno, string idAvaluo)
        {
            this.idpiso = idpiso;
            this.num = num;
            this.area = area;
            this.uso = uso;
            this.clase = clase;
            this.calidad = calidad;
            this.costo = costo;
            this.bueno = bueno;
            this.idAvaluoEdificaciones = idAvaluo;
        }
    }
}