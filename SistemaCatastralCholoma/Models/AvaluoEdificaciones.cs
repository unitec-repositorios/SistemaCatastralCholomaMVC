﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class AvaluoEdificaciones
    {
        public string idavaluoedificaciones { get; set; }
        public double totalEdificaciones { get; set; }
        public double edificaciones { get; set; }

        public AvaluoEdificaciones() { }

        public AvaluoEdificaciones(string id, double total, double edificaciones)
        {
            this.idavaluoedificaciones = id;
            this.totalEdificaciones = total;
            this.edificaciones = edificaciones;
        }

    }
}