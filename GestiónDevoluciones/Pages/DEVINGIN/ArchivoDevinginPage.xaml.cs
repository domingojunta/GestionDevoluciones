﻿using GestiónDevoluciones.Entities.DEVINGIN;
using GestiónDevoluciones.Tools;
using GestiónDevoluciones.Tools.DEVINGIN;
using GestiónDevoluciones.Tools.SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestiónDevoluciones.Pages
{
    /// <summary>
    /// Lógica de interacción para RequerimientoSolicitudInteresado.xaml
    /// </summary>
    public partial class ArchivoDevinginPage : Page
    {
        public DEVINGINRSLArchivoDevinginEntity entity;

        public ArchivoDevinginPage()
        {
            InitializeComponent();

            entity = new DEVINGINRSLArchivoDevinginEntity();
            checkRepresentante.IsChecked = false;
            txtRUE.Focus();
            btnGenerarTexto.IsEnabled = false;
        }

        private void checkRepresentante_Checked(object sender, RoutedEventArgs e)
        {
            if (checkRepresentante.IsChecked == true)
            {
                txtNombreInteresado.IsEnabled = true;
                txtNombreInteresado.Focus();
                //txtNombreRepresentante.IsEnabled = true;

            }
            else
            {
                txtNombreInteresado.IsEnabled = false;
                //txtNombreRepresentante.IsEnabled = false;
            }
        }

        private void checkOtroRequerimiento_Checked(object sender, RoutedEventArgs e)
        {

            //Activa las casillas de texto libre
            if (checkOtroRequerimiento.IsChecked == true)
            {
                txtOtroRequerimientoTexto.IsEnabled = true;
                txtOtroRequerimientoTexto.Focus();


            }
            else
            {
                txtOtroRequerimientoTexto.IsEnabled = false;

            }

            //Comprueba Botón construir requerimiento.

            if (chequearOpciones())
            {
                btnGenerarTexto.IsEnabled = true;
            }
            else
            {
                btnGenerarTexto.IsEnabled = false;
            }
        }

        private bool chequearOpciones()
        {
            bool algunaOpcionSeleccionada = checkDocumentacionAcreditativa.IsChecked == true ||
                                                checkDecretoFirmeza.IsChecked == true ||
                                                checkCertificadoEmpadronamiento.IsChecked == true ||
                                                checkAcreditacionRepresentacion.IsChecked == true ||
                                                checkCesionCredito.IsChecked == true ||
                                                checkCuentaCorriente.IsChecked == true ||
                                                checkOtroRequerimiento.IsChecked == true;
            return algunaOpcionSeleccionada;

        }

        private void checkCualquierOpcion_Checked(object sender, RoutedEventArgs e)
        {
            if (chequearOpciones())
            {
                btnGenerarTexto.IsEnabled = true;
            }
            else
            {
                btnGenerarTexto.IsEnabled = false;
            }
        }


        private void txtRUE_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                estaRUEVacioONuloOCorto();
                txtRUE.Focus();
            }
            
        }

        private void estaRUEVacioONuloOCorto()
        {
            if (String.IsNullOrEmpty(txtRUE.Text))
            {
                MessageBox.Show("El campo RUE no puede estar vacío");
                txtRUE.Focus();

            }
            else if (txtRUE.Text.Trim().Length<19)
            {
                    MessageBox.Show("El campo RUE debe tener al menos 19 caracteres");
                    txtRUE.Focus();
            }
            else
            {
                txtRUE.Text = normalizarRUE(txtRUE.Text);
            }
        }

            
        

        private void txtLiquidacion_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            estaRUEVacioONuloOCorto();
        }

        private void txtLiquidacion_GotFocus(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtRUE.Text))
            {
                //MessageBox.Show("El campo RUE no puede estar vacío");
                txtRUE.Focus();

            }
            else
            {
                if (txtRUE.Text.Trim().Length < 19)
                {
                    //MessageBox.Show("El campo RUE debe tener al menos 19 caracteres");
                    txtRUE.Focus();
                }
            }
        }

        

        private void limpiarFormulario()
        {
            txtRUE.Text = "";
            
            datePickerFechaNotificacionRequerimiento.Text = "";
            
            checkRepresentante.IsChecked = false;
            txtNombreInteresado.Text = "";
            txtNombreInteresado.IsEnabled = false;
            checkDocumentacionAcreditativa.IsChecked = false;
            checkDecretoFirmeza.IsChecked = false;
            checkCertificadoEmpadronamiento.IsChecked = false;
            checkAcreditacionRepresentacion.IsChecked = false;
            checkCesionCredito.IsChecked = false;
            checkCuentaCorriente.IsChecked = false;
            checkOtroRequerimiento.IsChecked = false;
            txtOtroRequerimientoTexto.Text = "";
            txtOtroRequerimientoTexto.IsEnabled = false;
            btnGenerarTexto.IsEnabled = false;
            txtRUE.Focus();
        }

        private DEVINGINRSLArchivoDevinginEntity recuperarDatosDelFormulario ()
        {

            entity = new DEVINGINRSLArchivoDevinginEntity();

            string RUENormalizado = normalizarRUE(txtRUE.Text);
            entity.RUE = RUENormalizado;
            
            entity.FechaNotificacionRequerimiento = datePickerFechaNotificacionRequerimiento.Text;
            
            
            if (checkRepresentante.IsChecked == true)
            {
                entity.Representante = true;
                entity.NombreSujetoPasivo = txtNombreInteresado.Text.ToUpper().Trim();
                //entity.NombreRepresentante = txtNombreRepresentante.Text.ToUpper().Trim();

            }
            else
            {
                entity.Representante = false;
                entity.NombreSujetoPasivo = " ";
                //entity.NombreRepresentante = " ";
            }

            if (checkDocumentacionAcreditativa.IsChecked == true)
            {
                entity.DocumentacionAcreditativa = true;
            }
            else 
            {
                entity.DocumentacionAcreditativa = false;
            }

            if (checkDecretoFirmeza.IsChecked == true)
            {
                entity.DecretoFirmeza = true;
            }
            else 
            {
                entity.DecretoFirmeza = false;
            }

            if (checkCertificadoEmpadronamiento.IsChecked == true)
            {
                entity.CertificadoEmpadronamiento = true;
            }
            else 
            {
                entity.CertificadoEmpadronamiento = false;
            }

            if (checkAcreditacionRepresentacion.IsChecked == true)
            {
                entity.AcreditacionRepresentacion = true;
            }
            else
            {
                entity.AcreditacionRepresentacion= false;
            }

            if (checkCesionCredito.IsChecked == true)
            {
                entity.CesionDeCredito = true;
            }
            else
            {
                entity.CesionDeCredito = false;
            }

            if (checkCuentaCorriente.IsChecked == true)
            {
                entity.CuentaCorriente = true;
            }
            else
            {
                entity.CuentaCorriente= false;
            }

            if (checkOtroRequerimiento.IsChecked == true)
            {
                entity.OtroRequerimiento = true;
                string otroRequerimientoSinNormalizar = txtOtroRequerimientoTexto.Text;
                string requerimientoNormalizado = quitarComillasYEuro(otroRequerimientoSinNormalizar);
                entity.OtroRequerimientoTexto = requerimientoNormalizado;
            }
            else
            {
                entity.OtroRequerimiento= false;
                entity.OtroRequerimientoTexto = "";
            }



            return entity;
        }

        private string quitarComillasYEuro(string text)
        {

            if (!string.IsNullOrEmpty(text))
            {

                text = text.Replace("\"", " -- ");
                text = text.Replace("€", " euros ");

            }
            else {

                text = String.Empty;
            }

            
            return text.ToUpper();
        }

        private string normalizarRUE(string RUESinNormalizar) {

            
            RUESinNormalizar = txtRUE.Text.Replace(" ", "").ToUpper();
            RUESinNormalizar = RUESinNormalizar.Replace("/", "");
            RUESinNormalizar = RUESinNormalizar.Replace("-", "");
            RUESinNormalizar = RUESinNormalizar.Replace("\"", "");
            RUESinNormalizar = RUESinNormalizar.Replace("_", "");
            string primeraParte = RUESinNormalizar.Substring(0, 18);
            string segundaParte = RUESinNormalizar.Substring(18);

            if (segundaParte.Length > 6)
            {
                segundaParte = segundaParte.Substring(segundaParte.Length - 6);
            }

            if (RUESinNormalizar.Length < 24)
            {

                if (segundaParte.Length < 6)
                {
                    int añadirLetras = 6 - segundaParte.Length;
                    for (int i = 0; i < añadirLetras; i++)
                    {
                        segundaParte = "0" + segundaParte;
                    }
                }

            }

            string RUENormalizado = primeraParte + segundaParte;
            //MessageBox.Show($"El RUE normalizado es: {RUENormalizado}, cuya longitud es: {RUENormalizado.Length}");
            return RUENormalizado;
        }

        

        

        

        

        private void datePickerFechaNotificacionRequerimiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(datePickerFechaNotificacionRequerimiento.Text))
            {
                MessageBox.Show("La fecha de notificación del requerimiento es un dato básico y no puede estar vacía.");
                datePickerFechaNotificacionRequerimiento.Focus();
            }
        }

        private void btnGenerarTexto_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(txtRUE.Text))
            {
                MessageBox.Show("El campo RUE es obligatorio y no puede estar vacío","Página de Archivo de DEVINGIN",MessageBoxButton.OK, MessageBoxImage.Error);
                txtRUE.Focus();
            }
            else if (String.IsNullOrEmpty(datePickerFechaNotificacionRequerimiento.Text))
            {
                MessageBox.Show("El campo Fecha Notificación Requerimiento es obligatorio y no puede estar vacío", "Página de Archivo de DEVINGIN"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
                datePickerFechaNotificacionRequerimiento.Focus();
            }
            else
            {
                
                entity = recuperarDatosDelFormulario();
                entity.PieDeRecursoTEARA = true;
                string texto = new DEVINGINConstructorTextoRSLArchivoTributario(entity).Texto;
                bool resultado = GenerarDocumentos.GenerarDocumentoTxt(texto, entity.RUE);

                if (resultado)
                {
                    MessageBox.Show("El requerimiento se ha creado satisfactoriamente está en documentos/GestionDevoluciones...",
                        "Página Generar Requerimiento DEVINGIN", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarFormulario();
                }
                else
                {
                    MessageBox.Show("No se ha podido generar el documento ...",
                        "Página Generar Requerimiento DEVINGIN", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            
        }
    }
}
