using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class claseDominio
    {
        public string tipoDominio { get; set; }

        public claseDominio() { }

        public claseDominio(string tipoDominio)
        {
            this.tipoDominio = tipoDominio;
        }
    }
}