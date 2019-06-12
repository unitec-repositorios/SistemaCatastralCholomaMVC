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
        public string tipo { get; set; }
        public ESTADO_PREDIO estadoPredio {get;set;}

        public Propiedad()
        {
        }

        public Propiedad(string claveCatastral, string mapa, string bloque, string predio, string propietarioPrincipal, List<string> propietarios,
<<<<<<< HEAD
                         string tipo, ESTADO_PREDIO estadoPredio)
=======
                         string tip,
                         ESTADO_PREDIO estadoPredio)
>>>>>>> develop
        {
            this.claveCatastral = claveCatastral;
            this.mapa = mapa;
            this.bloque = bloque;
            this.predio = predio;
            this.propietarioPrincipal = propietarioPrincipal;
            this.propietarios = propietarios;
<<<<<<< HEAD
            this.tipo = tipo;
=======
            this.tipo = tip;
>>>>>>> develop
            this.estadoPredio = estadoPredio;
        }
    }
}