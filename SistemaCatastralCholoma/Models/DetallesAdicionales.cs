using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class DetallesAdicionales
    {
        public DetallesAdicionales() { }
        public DetallesAdicionales(int idDetallesAdicionales, string codigo, int codEdificacion, double area, double porcentaje, double costoUnitario, string comentario, double valorDetallesAdicionales, string idClaveCatastral)
        {
            this.idDetallesAdicionales = idDetallesAdicionales;
            this.codigo = codigo;
            this.codEdificacion = codEdificacion;
            this.area = area;
            this.porcentaje = porcentaje;
            this.costoUnitario = costoUnitario;
            this.comentario = comentario;
            this.valorDetallesAdicionales = valorDetallesAdicionales;
            this.idClaveCatastral = idClaveCatastral;
        }

        public int idDetallesAdicionales { get; set; }
        public string codigo { get; set; }
        public int codEdificacion { get; set; }
        public double area { get; set; }
        public double porcentaje { get; set; }
        public double costoUnitario { get; set; }
        public string comentario { get; set; }
        public double valorDetallesAdicionales { get; set; }
        public string idClaveCatastral { get; set; }


    }
}