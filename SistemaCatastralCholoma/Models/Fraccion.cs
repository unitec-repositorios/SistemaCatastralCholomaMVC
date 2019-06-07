using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Fraccion
    {
        public int idFraccion { get; set; }
        public double valor { get; set; }
        public double area { get; set; }
        public double parecelaTipica { get; set; }
        public double factorModificado { get; set; }
        public double frente { get; set; }
        public int idAvaluoUrbano { get; set; }

        public Fraccion() { }

        public Fraccion(int idFraccion, double valor, double area, double parecelaTipica,
            double factorModificado, double frente, int idAvaluoUrbano)
        {
            this.idFraccion = idFraccion;
            this.valor = valor;
            this.area = area;
            this.parecelaTipica = parecelaTipica;
            this.factorModificado = factorModificado;
            this.frente = frente;
            this.idAvaluoUrbano = idAvaluoUrbano;
        }
    }
}