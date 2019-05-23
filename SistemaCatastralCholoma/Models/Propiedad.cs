using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class Propiedad
    {
        public string claveCatastral { get; set; }
        public string propietario { get; set; }
        public string tipoPropiedad { get; set; }


        public Propiedad()
        {

        }
        public Propiedad(string claveCatastral,string propietario, string tipoPropiedad)
        {
            this.claveCatastral = claveCatastral;
            this.propietario = propietario;
            this.tipoPropiedad = tipoPropiedad;
        }
    }
}