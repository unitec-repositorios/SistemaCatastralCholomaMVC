using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class EdificacionesEspeciales
    {
        public int idEdificacionesEspeciales { get; set; }
        public string nivel { get; set; }
        public double area { get; set; }
        public double costo { get; set; }
        public int idDatosComplementarios { get; set; }

        public EdificacionesEspeciales() { }

        public EdificacionesEspeciales(int idEdificacionesEspeciales, string nivel, double area, double costo,
            int idDatosComplementarios)
        {
            this.idEdificacionesEspeciales = idEdificacionesEspeciales;
            this.nivel = nivel;
            this.area = area;
            this.costo = costo;
            this.idDatosComplementarios = idDatosComplementarios;
        }
    }

    
}