using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class unidadArea
    {
        public string area { get; set; }

        public unidadArea() { }

        public unidadArea(string area)
        {
            this.area = area;
        }
    }
}