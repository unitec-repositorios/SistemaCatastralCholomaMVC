using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class EdificacionesEspeciales
    {
        public int idedificacionesespeciales { get; set; }
        public string Nivel { get; set; }
        public double Area { get; set; }
        public double Costo { get; set; }
        public int idDatosComplementarios { get; set; }

        public EdificacionesEspeciales() { }

        public EdificacionesEspeciales(int idEdificacionesEspeciales, string nivel, double area, double costo,
            int idDatosComplementarios)
        {
            this.idedificacionesespeciales = idEdificacionesEspeciales;
            this.Nivel = nivel;
            this.Area = area;
            this.Costo = costo;
            this.idDatosComplementarios = idDatosComplementarios;
        }
    }

    
}