using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class AvaluoRural
    {
        public string idavaluorural { get; set; }
        public double valorTerrenoRural { get; set; }

        public AvaluoRural() { }

        public AvaluoRural(string id, double valor)
        {
            this->idavaluorural = id;
            this->valorTerrenoRural = valor;
        }
    }
}