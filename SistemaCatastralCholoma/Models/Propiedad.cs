using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Propiedad
    {
        public string claveCatastral { get; set; }
        public string mapa {get; set;}
        public string bloque {get;set;}
        public string predio {get;set;}
        public string propietarioPrincipal {get;set;}
        public List<string> propietarios {get;set;}
        public bool informacionLegalPredio {get;set;}
        public bool caracteristicasPredio {get;set;}
        public bool datosComplementarios {get;set;}
        public double terreno {get;set;}
        public string terrenoId {get;set;}
        public double edificaciones {get;set;}
        public string edificacionesId {get;set;}
        public double detallesAdicionales {get;set;}
        public double cultivosPermanentes {get;set;}
        public double valorDeclarado {get;set;}
        public double avaluoTotal {get;set;}
        public double exencion {get;set;}
        public double valorGrabable {get;set;}
        public double impuesto {get;set;}
        public ESTADO_PREDIO estadoPredio {get;set;}

        public Propiedad()
        {
        }

        public Propiedad(string claveCatastral, string mapa, string bloque, string predio, string propietarioPrincipal, List<string> propietarios,
                         bool informacionLegalPredio, bool caracteristicasPredio, bool datosComplementarios,
                         double terreno, string terrenoId, double edificaciones, string edificacionesId,
                         double detallesAdicionales, double cultivosPermanentes, double valorDeclarado,
                         double avaluoTotal, double exencion, double valorGrabable, double impuesto,
                         ESTADO_PREDIO estadoPredio)
        {
            this.claveCatastral = claveCatastral;
            this.mapa = mapa;
            this.bloque = bloque;
            this.predio = predio;
            this.propietarioPrincipal = propietarioPrincipal;
            this.propietarios = propietarios;
            this.informacionLegalPredio = informacionLegalPredio;
            this.caracteristicasPredio = caracteristicasPredio;
            this.datosComplementarios = datosComplementarios;
            this.terreno = terreno;
            this.terrenoId = terrenoId;
            this.edificaciones = edificaciones;
            this.edificacionesId = edificacionesId;
            this.detallesAdicionales = detallesAdicionales;
            this.cultivosPermanentes = cultivosPermanentes;
            this.valorDeclarado = valorDeclarado;
            this.avaluoTotal = avaluoTotal;
            this.exencion = exencion;
            this.valorGrabable = valorGrabable;
            this.impuesto = impuesto;
            this.estadoPredio = estadoPredio;
        }
    }
}