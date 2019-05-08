using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class FichaCatastral
    {
        public String cocata { get; set; }
        public String depto { get; set; }
        public String municipio { get; set; }
        public String aldea { get; set; }
        public String mapa { get; set; }
        public String bolque { get; set; }
        public String predio { get; set; }
        public String num { get; set; }
        public String maq { get; set; }
        public String st { get; set; }
        public String codProp { get; set; }
        public String codHab { get; set; }
        public String noLinea { get; set; }
        public String noFoto { get; set; }
        public String poblacion { get; set; }
        public String identidadPropietario { get; set; }
        public String tomo { get; set; }
        public String asiento { get; set; }

        public FichaCatastral()
        {

        }

        public FichaCatastral(String cocata, String depto, String municipio, String aldea, 
            String mapa, String bolque, String predio, String num, String maq, String st, 
            String codProp, String codHab, String noLinea, String noFoto, String poblacion, 
            String identidadPropietario, String tomo, String asiento)
        {
            this.cocata = cocata;
            this.depto = depto;
            this.municipio = municipio;
            this.aldea = aldea;
            this.mapa = mapa;
            this.bolque = bolque;
            this.predio = predio;
            this.num = num;
            this.maq = maq;
            this.st = st;
            this.codProp = codProp;
            this.codHab = codHab;
            this.noLinea = noLinea;
            this.noFoto = noFoto;
            this.poblacion = poblacion;
            this.identidadPropietario = identidadPropietario;
            this.tomo = tomo;
            this.asiento = asiento;
        }

    }
}