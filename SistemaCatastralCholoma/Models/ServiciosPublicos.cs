using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class ServiciosPublicos
    {
        public int idServiciosPublicos { get; set; }
        public string agua { get; set; }
        public string telefono { get; set; }
        public string drenaje { get; set; }
        public string calle { get; set; }
        public string electricidad { get; set; }
        public string acera { get; set; }
        public string alumbrado { get; set; }

        public ServiciosPublicos() { }

        public ServiciosPublicos(int idServiciosPublicos, string agua, string telefono, string drenaje,
            string calle, string electricidad, string acera, string alumbrado)
        {
            this.idServiciosPublicos = idServiciosPublicos;
            this.agua = agua;
            this.telefono = telefono;
            this.drenaje = drenaje;
            this.calle = calle;
            this.electricidad = electricidad;
            this.acera = acera;
            this.alumbrado = alumbrado;
        }
    }
}