using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónDevoluciones.Entities.DEVINEJE
{
    public class DevinejeRSLCaducidadEntity
    {
        public string FechaNotificacionRSLQueGeneraElDerecho { get; set; }
        public string FechaNotificacionRequerimiento { get; set; }

        public string RUE { get; set; }
        public bool Representante { get; set; }
        //public string NombreRepresentante { get; set; }
        public string NombreSujetoPasivo { get; set; }
        public string OtroRequerimientoTexto { get; set; }
        public bool DocumentacionAcreditativa { get; set; }
        public bool DecretoFirmeza { get; set; }
        public bool CertificadoEmpadronamiento { get; set; }
        public bool AcreditacionRepresentacion { get; set; }
        public bool CuentaCorriente { get; set; }
        public bool CesionDeCredito { get; set; }
        public bool OtroRequerimiento { get; set; }
        public bool PieDeRecursoTEARA { get; set; }
    }
}
