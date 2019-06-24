using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class AvaluoUrbano
    {
        public string idavaluourbano { get; set; }
        public double Esquina { get; set; }
        public double Topografia { get; set; }

        public AvaluoUrbano() { }

        public AvaluoUrbano(string id, double esquina, double topografia)
        {
            this.idavaluourbano = id;
            this.Esquina = esquina;
            this.Topografia = topografia;
        }
    }
}