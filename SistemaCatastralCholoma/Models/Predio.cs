using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{

    public class Predio
    {
        public string idPredio { get; set; }
        public string mapa { get; set; }
        public string bloque { get; set; }
        public string numeroPredio {get;set;}
        public string barrio { get; set; }
        public string caserio { get; set; }
        public int uso { get; set; }
        public int subUso { get; set; }
        public string ubicacion { get; set; }
        public string sitio { get; set; }
        public string construccion {get;set;}
        public int estatusTributario {get;set;}
        public string codigoPropietario {get;set;}
        public string codigoHabitacional {get;set;}
        public double porcentajeExencion {get;set;}
        public double tasaImpositiva {get;set;}
        public string futurasRevisiones {get;set;}
        public double porcentajeConcertacion {get;set;}
        public string observacion { get; set; }
        public string obs { get; set; }
        public string nolegalizado { get; set; }


        public Predio(string idPredio, string mapa, string bloque, string numeroPredio, string barrio, string caserio, int uso, int subUso, string sitio, string ubicacion,
                      string construccion, int estatusTributario, string codigoPropietario,
                      string codigoHabitacional, double porcentajeExencion, double tasaImpositiva, string futurasRevisiones,
                      double porcentajeConcertacion, string observacion, string obs, string noL)
        {
            this.idPredio = idPredio;
            this.barrio = barrio;
            this.bloque = bloque;
            this.numeroPredio = numeroPredio;
            this.barrio = barrio;
            this.caserio = caserio;
            this.uso = uso;
            this.subUso = subUso;
            this.ubicacion = ubicacion;
            this.sitio = sitio;
            this.construccion = construccion;
            this.estatusTributario = estatusTributario;
            this.codigoPropietario = codigoPropietario;
            this.codigoHabitacional = codigoHabitacional;
            this.porcentajeExencion = porcentajeExencion;
            this.tasaImpositiva = tasaImpositiva;
            this.futurasRevisiones = futurasRevisiones;
            this.porcentajeConcertacion = porcentajeConcertacion;
            this.observacion = observacion;
            this.obs = obs;
            this.nolegalizado = noL;
        }

        public Predio()
        {
        }
    }


}