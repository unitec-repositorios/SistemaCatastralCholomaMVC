using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models.RequestModels
{
    public class DatosLegalesRequestModel
    {
        public string idclaveCatastral { get; set; }
        public string propiedad { get; set; }
        public string tomo { get; set; }
        public string folio { get; set; }
        public string asiento { get; set; }
        public string inscripcion { get; set; }
        public string matricula { get; set; }
        public string linea { get; set; }
        public string foto { get; set; }
        public string predio { get; set; }
        public string naturalezaJuridica { get; set; }
        public string tipoDocumento { get; set; }
        public double area { get; set; }
        public string unidadArea { get; set; }
        public string tipoMedida { get; set; }

        public DatosLegalesRequestModel() { }

        public DatosLegalesRequestModel(string id, string propiedad, string tomo, string folio,
                            string asiento, string inscripcion, string matricula,
                            string linea, string foto, string predio, string naturaleza,
                            string tipo, double area, string unidad)
        {
            idclaveCatastral = id;
            this.propiedad = propiedad;
            this.tomo = tomo;
            this.folio = folio;
            this.asiento = asiento;
            this.inscripcion = inscripcion;
            this.matricula = matricula;
            this.linea = linea;
            this.foto = foto;
            this.predio = predio;
            this.naturalezaJuridica = naturaleza;
            this.tipoDocumento = tipo;
            this.area = area;
            this.unidadArea = unidad;
            this.tipoMedida = tipo;
        }
    }

    
}