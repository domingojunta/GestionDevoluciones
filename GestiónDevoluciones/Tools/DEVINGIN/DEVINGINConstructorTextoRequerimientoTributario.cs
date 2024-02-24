using GestiónDevoluciones.Entities.DEVINGIN;
using GestiónDevoluciones.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónDevoluciones.Tools.DEVINGIN
{
    public class DEVINGINConstructorTextoRequerimientoTributario
    {

        public DEVINGINRequerimientoEntity Entity { get; set; }
                
        public string Texto { get; set; }
        string path = "DEVINGIN/TRIBUTARIO";

        public DEVINGINConstructorTextoRequerimientoTributario(DEVINGINRequerimientoEntity entity)
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

            referenciaRequerimiento += $"Fecha: La de la firma electrónica";
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
            if (!string.IsNullOrEmpty(Entity.FechaPresentacion))
            {
                parrafoIntroductorio += $", presentado por usted el pasado {Entity.FechaPresentacion}";
            }

            if (Entity.Representante && !string.IsNullOrEmpty(Entity.NombreSujetoPasivo))
            {
                parrafoIntroductorio += $", en representación de {Entity.NombreSujetoPasivo}";
            }

            if (!string.IsNullOrEmpty(Entity.Expone))
            {
                parrafoIntroductorio += $", en el que expone: {Entity.Expone}";
            }
            parrafoIntroductorio += $", en el que solicita la devolución de ingresos realizados";
            if (!string.IsNullOrEmpty(Entity.Liquidacion))
            {
                parrafoIntroductorio += $", correspondientes a la autoliquidación/liquidación número {Entity.Liquidacion}";
            }
            if (!string.IsNullOrEmpty(Entity.CuentaCorrienteSolicitud))
            {
                parrafoIntroductorio += $", en la cuenta corriente: {Entity.CuentaCorrienteSolicitud}";
            }
            parrafoIntroductorio += ", se le requiere para que, en el plazo de diez días hábiles";
            parrafoIntroductorio += " contados a partir del siguiente al de la notificación del presente requerimiento, aporte la siguiente documentación:";
            parrafoIntroductorio += "\n";




            return parrafoIntroductorio;
        }


        private string construirRequerimientos()
        {
            string textoRequerimientos = "";
            int contador = 0;

            if (Entity.DocumentacionAcreditativa)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto($"{path}\\DevinginRequerimientoDocumentacionAcreditativa.txt");
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";
            }
            if (Entity.DecretoFirmeza)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto($"{path}\\DevinginRequerimientoDecretoDeFirmeza.txt");
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";
            }
            if (Entity.CertificadoEmpadronamiento)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto($"{path}\\DevinginRequerimientoCertificadoDeEmpadronamiento.txt");
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";
            }
            if (Entity.AcreditacionRepresentacion)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto($"{path}\\DevinginRequerimientoAcreditacionDeLaRepresentacion.txt");
                textoRequerimientos += $"{contador}.- {documentacionAcreditativa}";
                textoRequerimientos += "\n\n";
            }
            if (Entity.CesionDeCredito)
            {
                contador++;
                string documentacionAcreditativa = GetTextFromFile.getTexto("SHARED\\RequerimientoCesionDeCredito.txt");
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
                string documentacionAcreditativa = GetTextFromFile.getTexto($"{path}\\DevinginRequerimientoCuentaCorriente.txt");
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
            string texto = GetTextFromFile.getTexto($"{path}\\DevinginRequerimientoPie.txt");
            return texto;

        }


    }
}
