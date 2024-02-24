using GestiónDevoluciones.Entities.DEVINGIN;
using GestiónDevoluciones.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestiónDevoluciones.Tools.DEVINGIN
{
    public class DEVINGINConstructorTextoRSLArchivoTributario
    {

        public DEVINGINRSLArchivoDevinginEntity Entity { get; set; }
        public string Texto { get; set; }
        string path = "DEVINGIN/TRIBUTARIO";

        public DEVINGINConstructorTextoRSLArchivoTributario(DEVINGINRSLArchivoDevinginEntity entity)
        {
            Entity = entity;
            Texto = construirEncabezado();
            Texto += "\n\n";
            Texto += construirAntecedentes();
            Texto += "\n\n";
            Texto += construirFundamentosDeDerecho();
            Texto += "\n";
            Texto += construirResuelve();
            Texto += "\n";
            Texto += construirPie();
        }

        private string construirEncabezado()
        {
            string texto = "";

            texto += $"                    RESOLUCIÓN DE ARHIVO POR NO ATENDER A REQUERIMIENTO";
            texto += "\n\n";
            texto += $"Visto el expediente de devolución de ingresos indebidos {Entity.RUE}";
            if (Entity.Representante)
            {
                texto += $", tramitado a favor de {Entity.NombreSujetoPasivo} ";
            }
            else
            {
                texto += $", tramitado a su nombre ";
            }
            texto += $"y considerando para su resolución expresa los siguientes antecedentes y fundamentos de derecho.";
            texto += "\n";

            return texto;

        }

        private string construirAntecedentes()
        {
            string texto = string.Empty;

            texto += $"                              ANTECEDENTES";
            texto += "\n\n";
            texto += $"El pasado {Entity.FechaNotificacionRequerimiento} se le requiere para que subsane los siguientes defectos de su solicitud de devolución ";
            texto += $" que impiden su adecuada resolución:";

            texto += "\n\n";
            int contador = 0;

            if (Entity.DocumentacionAcreditativa)
            {
                contador++;
                texto += $"{contador}.- Documentación acreditativa del derecho a la devolución.";
                texto += "\n";
            }
            if (Entity.DecretoFirmeza)
            {
                contador++;
                texto += $"{contador}.- Decreto de firmeza de la Sentencia o Resolución de la Reclamación Económica Administrativa que le concede el derecho a la devolución.";
                texto += "\n";
            }
            if (Entity.CertificadoEmpadronamiento)
            {
                contador++;
                texto += $"{contador}.- Certificado de empadronamiento del Obligado Tributario.";
                texto += "\n";
            }
            if (Entity.AcreditacionRepresentacion)
            {
                contador++;
                texto += $"{contador}.- Acreditación de la representación.";
                texto += "\n";
            }
            if (Entity.CesionDeCredito)
            {
                contador++;
                texto += $"{contador}.- Documentación que acredite la cesión de crédito.";
                texto += "\n";
            }
            if (Entity.CuentaCorriente)
            {
                contador++;
                texto += $"{contador}.- La comunicación de la cuenta corriente, dada de alta en el sistema GIRO, de titularidad del Obligado Tributario ";
                texto += $"o en su caso, de titularidad de la persona a la que se le haya cedido el crédito, en la que efectuar la devolución.";
                texto += "\n";
            }
            if (Entity.OtroRequerimiento && !string.IsNullOrEmpty(Entity.OtroRequerimientoTexto))
            {
                contador++;
                texto += $"{contador}.- {Entity.OtroRequerimientoTexto}";
                texto += "\n";
            }
            texto += "\n";
            texto += "Ni dentro, ni fuera del plazo concedido, se ha contestado adecuadamente al requerimiento.";


            return texto;
        }


        private string construirFundamentosDeDerecho()
        {
            string texto = string.Empty;

            texto += $"                              FUNDAMENTOS DE DERECHO";
            texto += "\n\n";

            string fileName = "FundamentoDerechoPrimero.txt";
            string textFromFile = GetTextFromFile.getTexto(fileName);

            if (string.IsNullOrEmpty(textFromFile))
            {
                MessageBox.Show($"No se ha recuperado adecuadamente el texto del fichero {fileName}. El texto generado no es válido y hay que modificarlo manualmente.", "GetTextFromFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            texto += $"PRIMERO.- {textFromFile}";
            texto += "\n\n";

            fileName = "DEVINGINRLSArchivoFundamentoDerechoSegundo.txt";
            textFromFile = GetTextFromFile.getTexto(fileName);

            if (string.IsNullOrEmpty(textFromFile))
            {
                MessageBox.Show($"No se ha recuperado adecuadamente el texto del fichero {fileName}. El texto generado no es válido y hay que modificarlo manualmente.", "GetTextFromFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            texto += $"SEGUNDO.- {textFromFile}";
            texto += "\n\n";

            fileName = "DEVINGINRSLArchivoFundamentoDerechoTercero.txt";
            textFromFile = GetTextFromFile.getTexto(fileName);

            if (string.IsNullOrEmpty(textFromFile))
            {
                MessageBox.Show($"No se ha recuperado adecuadamente el texto del fichero {fileName}. El texto generado no es válido y hay que modificarlo manualmente.", "GetTextFromFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            texto += $"TERCERO.- {textFromFile}";
            texto += "\n\n";




            return texto;
        }

        private string construirResuelve()
        {
            string texto = string.Empty;

            string fileName = "DEVINGINRSLArchivoResuelve.txt";
            string textFromFile = GetTextFromFile.getTexto(fileName);

            if (string.IsNullOrEmpty(textFromFile))
            {
                MessageBox.Show($"No se ha recuperado adecuadamente el texto del fichero {fileName}. El texto generado no es válido y hay que modificarlo manualmente.", "GetTextFromFile", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            texto += textFromFile;
            texto += "\n";









            return texto;
        }

        private string construirPie()
        {

            string fileName = "PieDeRecursoReposicionYTEARA.txt";

            if (Entity.PieDeRecursoTEARA)
            {
                fileName = "PieDeRecursoReposicionYTEARA.txt";
            }
            else
            {
                fileName = "PieDeRecursoReposicionYTEAJA";
            }

            string texto = GetTextFromFile.getTexto(fileName);

            //MessageBox.Show($"El texto del Pie de recurso es: {texto}");

            return texto;

        }




    }
}
