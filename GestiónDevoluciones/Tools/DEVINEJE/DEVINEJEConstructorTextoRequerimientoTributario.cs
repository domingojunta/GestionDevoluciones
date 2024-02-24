using GestiónDevoluciones.Entities.DEVINEJE;
using GestiónDevoluciones.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestiónDevoluciones.Tools.DEVINEJE
{
    public class DEVINEJEConstructorTextoRequerimientoTributario
    {
        public DEVINEJERequerimientoOficioEntity Entity { get; set; }
        
        public string Texto { get; set; }

        public DEVINEJEConstructorTextoRequerimientoTributario(DEVINEJERequerimientoOficioEntity entity)
        {
            Entity = entity;
            
            Texto = construirReferenciaRequerimiento();
            Texto += "\n\n";
            Texto += construirParrafoIntroductorio();
            Texto += "\n\n";
            Texto += construirRequerimientos();
            Texto += "\n";
            Texto += construirPie();

        }

        private string construirReferenciaRequerimiento()
        {
            string referenciaRequerimiento = "";

            referenciaRequerimiento += $"Fecha: La de la firma electrónica.";
            referenciaRequerimiento += "\n";
            referenciaRequerimiento += $"Nuestra Referencia: Equipo de devoluciones ATRIAN";
            referenciaRequerimiento += "\n";
            referenciaRequerimiento += $"Asunto: Requerimiento expediente número: {Entity.RUE}";
            referenciaRequerimiento += "\n";

            return referenciaRequerimiento;
        }

        private string construirParrafoIntroductorio()
        {
            string parrafoIntroductorio = "";


            parrafoIntroductorio += $"Con el fin de poder tramitar el expediente de devolución número {Entity.RUE}";

            if (!string.IsNullOrEmpty(Entity.FechaResolucion))
            {
                parrafoIntroductorio += $", cuyo derecho se generó por Resolución/Sentencia de fecha: {Entity.FechaResolucion}";
            }

            if (!string.IsNullOrEmpty(Entity.ProcedimientoOrigenDevolucion))
            {
                parrafoIntroductorio += $", {Entity.ProcedimientoOrigenDevolucion}";
            }

            if (Entity.Representante && !string.IsNullOrEmpty(Entity.NombreSujetoPasivo))
            {
                parrafoIntroductorio += $", presentado por Usted en nombre y representación de {Entity.NombreSujetoPasivo}";
            }

            parrafoIntroductorio += ", se le requiere para que, en el plazo de diez días hábiles";
            parrafoIntroductorio += " contados a partir del siguiente al de la notificación del presente requerimiento, ";
            parrafoIntroductorio += "aporte la siguiente documentación:";
            parrafoIntroductorio += "\n";




            return parrafoIntroductorio;
        }

        private string construirRequerimientos()
        {
            string textoRequerimientos = string.Empty;
            int contador = 0;

            if (Entity.DecretoFirmeza)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto("Requerimiento_DecretoDeFirmeza.txt");
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";
            }
            if (Entity.OtroRequerimiento && !string.IsNullOrEmpty(Entity.OtroRequerimientoTexto))
            {
                contador++;
                string documentacionAcreditativa = Entity.OtroRequerimientoTexto;
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";
            }
            if (Entity.CuentaCorriente)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto("Requerimiento_CuentaCorriente.txt");
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";

            }
            if (Entity.CesionDeCredito)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto("Requerimiento_CesionDeCredito.txt");
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";

            }
            if (Entity.AcreditacionRepresentacion)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto("Requerimiento_AcreditacionDeLaRepresentacion.txt");
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";

            }

            if (!string.IsNullOrEmpty(Entity.CuentaCorrienteGiro))
            {
                textoRequerimientos += "\n";
                contador++;
                string documentacionAcreditativa = $"Se le advierte que de no proceder a dar de alta una cuenta en el sistema GIRO y a comunicar la misma a esta Unidad, ";
                documentacionAcreditativa += $"la devolución se efectuará en la cuenta con IBAN {Entity.CuentaCorrienteGiro} ";
                documentacionAcreditativa += "que aparece dada de alta a su nombre, en nuestros Sistemas de Información.";
                textoRequerimientos += documentacionAcreditativa;
                textoRequerimientos += "\n\n";

            }

            return textoRequerimientos;

        }

        private string construirPie()
        {
            string texto = GetTextFromFile.getTexto("DEVINEJERequerimiento_Pie.txt");
            return texto;
        }







    }
}
