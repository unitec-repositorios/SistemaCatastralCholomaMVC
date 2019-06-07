using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class CaracteristicasVecindad
    {
        public string idcaracteristicasvecindad {get; set;}
        public string Iglesia { get; set; }
        public string Escuela { get; set; }
        public double sitioEmbarque { get; set; }
        public double mercadoCercano { get; set; }

        public CaracteristicasVecindad() { }

        public CaracteristicasVecindad(string id, string iglesia, string escuela, double sitio, double mercado)
        {
            this.idcaracteristicasvecindad = id;
            this.Iglesia = iglesia;
            this.Escuela = escuela;
            this.sitioEmbarque = sitio;
            this.mercadoCercano = mercado;
        }

    }
}