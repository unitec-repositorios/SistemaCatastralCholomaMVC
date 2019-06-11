using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Fraccion
    {
        public int idfraccion { get; set; }
        public double Valor { get; set; }
        public double Area { get; set; }
        public double parecelaTipica { get; set; }
        public double factorModificado { get; set; }
        public double Frente { get; set; }
        public int idAvaluoUrbano { get; set; }

        public Fraccion() { }

        public Fraccion(int idFraccion, double valor, double area, double parecelaTipica,
            double factorModificado, double frente, int idAvaluoUrbano)
        {
            this.idfraccion = idFraccion;
            this.Valor = valor;
            this.Area = area;
            this.parecelaTipica = parecelaTipica;
            this.factorModificado = factorModificado;
            this.Frente = frente;
            this.idAvaluoUrbano = idAvaluoUrbano;
        }
    }
}