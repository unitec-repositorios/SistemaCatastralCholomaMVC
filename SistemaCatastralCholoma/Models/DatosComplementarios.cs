using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaCatastralCholoma.Models
{
    public class DatosComplementarios
    {
        public string idClaveCatastral { get; set; }
        public DateTime adquisicion { get; set; }
        public double montoTransaccion { get; set; }
        public string claseTransaccion { get; set; }
        public string maquinaria { get; set; }
        public string delineador { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
        public string ocupante { get; set; }
        public string uso { get; set; }//enum
        public string clase { get; set; }//enum
        public double bueno { get; set; }
        public string observacion { get; set; }
        public double rentaMensual { get; set; }
        public int idServiciosPublicos { get; set; }
        public double valorDatosComplementarios { get; set; }

        public DatosComplementarios() { }

        public DatosComplementarios(string id, DateTime adq, double monto,
                                    string claseTrans, string maquinaria, string delineador,
                                    DateTime fecha, string observaciones, string ocupante,
                                    string uso, string clase, double bueno, string observacion,
                                    double renta, int idSP, double valor)
        {
            this.idClaveCatastral = id;
            this.adquisicion = adq;
            this.montoTransaccion = monto;
            this.claseTransaccion = claseTrans;
            this.maquinaria = maquinaria;
            this.delineador = delineador;
            this.fecha = fecha;
            this.observaciones = observaciones;
            this.ocupante = ocupante;
            this.uso = uso;
            this.clase = clase;
            this.bueno = bueno;
            this.observacion = observacion;
            this.rentaMensual = renta;
            this.idServiciosPublicos = idSP;
            this.valorDatosComplementarios = valor;
        }
    }
}