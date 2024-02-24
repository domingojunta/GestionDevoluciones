using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónDevoluciones.Entities.DEVINGIN
{
    public class DEVINGINRequerimientoEntity
    {
        public string FechaPresentacion { get; set; }
        public string Liquidacion { get; set; }
        public string RUE { get; set; }
        public bool Representante { get; set; }
        //public string NombreRepresentante { get; set; }
        public string NombreSujetoPasivo { get; set; }
        public string CuentaCorrienteSolicitud { get; set; }
        public string CuentaCorrienteGiro { get; set; }
        public string OtroRequerimientoTexto { get; set; }
        public string Expone { get; set; }
        public bool DocumentacionAcreditativa { get; set; }
        public bool DecretoFirmeza { get; set; }
        public bool CertificadoEmpadronamiento { get; set; }
        public bool AcreditacionRepresentacion { get; set; }
        public bool CuentaCorriente { get; set; }
        public bool CesionDeCredito { get; set; }
        public bool OtroRequerimiento { get; set; }
    }
}
