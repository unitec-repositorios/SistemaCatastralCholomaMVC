using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class ServiciosPublicos
    {
        public int idserviciospublicos { get; set; }
        public string Agua { get; set; }
        public string Telefono { get; set; }
        public string Drenaje { get; set; }
        public string Calle { get; set; }
        public string Electricidad { get; set; }
        public string Acera { get; set; }
        public string Alumbrado { get; set; }

        public ServiciosPublicos() { }

        public ServiciosPublicos(int idServiciosPublicos, string agua, string telefono, string drenaje,
            string calle, string electricidad, string acera, string alumbrado)
        {
            this.idserviciospublicos = idServiciosPublicos;
            this.Agua = agua;
            this.Telefono = telefono;
            this.Drenaje = drenaje;
            this.Calle = calle;
            this.Electricidad = electricidad;
            this.Acera = acera;
            this.Alumbrado = alumbrado;
        }
    }
}