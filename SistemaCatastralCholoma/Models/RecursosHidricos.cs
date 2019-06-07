using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class RecursosHidricos
    {
        public int idRecursosHidricos { get; set; }
        public string fuente { get; set; }
        public string riego { get; set; }
        public string sistemaIrrigacion { get; set; }
        public double distancia { get; set; }
        public double area { get; set; }
        public int idCaracRural { get; set; }

        public RecursosHidricos() { }

        public RecursosHidricos(int idRecursosHidricos, string fuente, string riego, string sistemaIrrigacion,
            double distancia, double area, int idCaracRural)
        {
            this.idRecursosHidricos = idRecursosHidricos;
            this.fuente = fuente;
            this.riego = riego;
            this.sistemaIrrigacion = sistemaIrrigacion;
            this.distancia = distancia;
            this.area = area;
            this.idCaracRural = idCaracRural;
        }
    }
}