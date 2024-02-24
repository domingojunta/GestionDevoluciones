using GestiónDevoluciones.Entities.DEVINEJE;
using GestiónDevoluciones.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Lógica de interacción para RequerimientoIniciadoOficio.xaml
    /// </summary>
    public partial class RequerimientoIniciadoOficioPage : Page
    {
        public DEVINEJERequerimientoOficioEntity Entity { get; set; }
        public RequerimientoIniciadoOficioPage()
        {
            InitializeComponent();
            this.Entity = new DEVINEJERequerimientoOficioEntity();
            txtRUE.Focus();
            btnGenerarRequerimiento.IsEnabled= false;
        }

        private void txtRUE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                bool noCumple = estaRUEVacioONuloOCorto();
                if (!noCumple) 
                {
                    txtRUE.Text = normalizarRUE(txtRUE.Text);
                    txtCuentaCorrienteGiro.Focus();
                }
                else
                {
                    txtRUE.Focus();
                }

            }
        }

        private bool estaRUEVacioONuloOCorto()
        {

            bool resultado = false;

            if (String.IsNullOrEmpty(txtRUE.Text))
            {
                MessageBox.Show("El campo RUE no puede estar vacío");
                resultado = true;
                txtRUE.Focus();

            }
            else if (txtRUE.Text.Trim().Length < 19)
            {
                MessageBox.Show("El campo RUE debe tener al menos 19 caracteres");
                resultado = true;
            }
           
            
            return resultado;
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

        private void txtCuentaCorrienteGiro_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool noCumple = estaRUEVacioONuloOCorto();
            if (!noCumple)
            {
                txtRUE.Text = normalizarRUE(txtRUE.Text);
                txtCuentaCorrienteGiro.Focus();
            }
            else
            {
                txtRUE.Focus();
            }

        }

        
        private void checkCualquierOpcion_Checked(object sender, RoutedEventArgs e)
        {
            if (chequearOpciones())
            {
                btnGenerarRequerimiento.IsEnabled = true;
            }
            else
            {
                btnGenerarRequerimiento.IsEnabled = false;
            }
        }

        private bool chequearOpciones()
        {
            bool algunaOpcionSeleccionada = checkDecretoFirmeza.IsChecked == true ||
                                            checkCesionCredito.IsChecked == true ||
                                            checkCuentaCorriente.IsChecked == true ||
                                            checkOtroRequerimiento.IsChecked == true;
            return algunaOpcionSeleccionada;

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
                btnGenerarRequerimiento.IsEnabled = true;
            }
            else
            {
                btnGenerarRequerimiento.IsEnabled = false;
            }
        }


        private string quitarComillasYEuro(string text)
        {

            if (!string.IsNullOrEmpty(text))
            {

                text = text.Replace("\"", " -- ");
                text = text.Replace("€", " euros ");

            }
            else
            {

                text = String.Empty;
            }


            return text.ToUpper().Trim();
        }


        private string normalizarRUE(string RUESinNormalizar)
        {

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

        private void limpiarFormulario()
        {
            txtRUE.Text = "";

            datePickerFechaResolucion.Text = String.Empty;
            txtProcedimientoOrigenDerecho.Text = String.Empty;
            txtCuentaCorrienteGiro.Text = "";
            checkDecretoFirmeza.IsChecked = false;
            checkCuentaCorriente.IsChecked = false;
            checkOtroRequerimiento.IsChecked = false;
            checkCesionCredito.IsChecked = false;
            txtOtroRequerimientoTexto.Text = String.Empty;
            txtOtroRequerimientoTexto.IsEnabled = false;
            btnGenerarRequerimiento.IsEnabled = false;
            checkRepresentante.IsChecked = false;
            txtNombreInteresado.Text = String.Empty;
            txtNombreInteresado.IsEnabled = false;
            checkAcreditacionRepresentacion.IsChecked = false;
            txtRUE.Focus();
        }

       
        private DEVINEJERequerimientoOficioEntity recuperarDatosDelFormulario()
        {
            DEVINEJERequerimientoOficioEntity entity = new DEVINEJERequerimientoOficioEntity();
            string RUENormalizado = normalizarRUE(txtRUE.Text);
            entity.RUE = RUENormalizado;
            entity.FechaResolucion = datePickerFechaResolucion.Text;
            entity.CuentaCorrienteGiro = txtCuentaCorrienteGiro.Text.ToUpper();
            string textoProcedimientoOrigenDevolucionNormalizado = quitarComillasYEuro(txtProcedimientoOrigenDerecho.Text.ToUpper());
            entity.ProcedimientoOrigenDevolucion = textoProcedimientoOrigenDevolucionNormalizado.ToUpper();

            if (checkRepresentante.IsEnabled == true)
            {
                entity.Representante = true;
                entity.NombreSujetoPasivo = txtNombreInteresado.Text;

            }  else
            {
                entity.Representante = false;
                entity.NombreSujetoPasivo = String.Empty;
            }


            if (checkDecretoFirmeza.IsChecked == true)
            {
                entity.DecretoFirmeza = true;
            }
            else
            {
                entity.DecretoFirmeza = false;
            }

            if (checkCuentaCorriente.IsChecked == true)
            {
                entity.CuentaCorriente = true;
            }
            else
            {
                entity.CuentaCorriente = false;
            }

            if (checkCesionCredito.IsChecked == true)
            {
                entity.CesionDeCredito = true;
            }
            else
            {
                entity.CesionDeCredito = false;
            }

            if (checkAcreditacionRepresentacion.IsChecked == true)
            {
                entity.AcreditacionRepresentacion = true;
            }
            else
            {
                entity.AcreditacionRepresentacion = false;
            }

            if (checkOtroRequerimiento.IsChecked == true)
            {
                entity.OtroRequerimiento = true;
                string otroRequerimientoSinNormalizar = txtOtroRequerimientoTexto.Text.ToUpper();
                string requerimientoNormalizado = quitarComillasYEuro(otroRequerimientoSinNormalizar);
                entity.OtroRequerimientoTexto = requerimientoNormalizado;
            }
            else
            {
                entity.OtroRequerimiento = false;
                entity.OtroRequerimientoTexto = String.Empty;
            }


            return entity;
        }

        private void datePickerFechaResolucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrEmpty(datePickerFechaResolucion.Text))
            {
                MessageBox.Show("La fecha de la resolución que reconoce el derecho es un dato importante y no puede estar vacía.","Requerimiento Oficio Page",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                datePickerFechaResolucion.Focus();
            }
        }

        private void txtProcedimientoOrigenDerecho_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (String.IsNullOrEmpty(datePickerFechaResolucion.Text))
            {
                MessageBox.Show("La fecha de la resolución que reconoce el derecho es un dato importante y no puede estar vacía.", "Requerimiento Oficio Page",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                datePickerFechaResolucion.Focus();
            }
        }



        private void btnGenerarRequerimiento_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(txtRUE.Text))
            {
                MessageBox.Show("La RUE es imprescindible y no puede estar vacía...","Requerimiento Oficio Page",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                txtRUE.Focus();
            }
            else if (String.IsNullOrEmpty(datePickerFechaResolucion.Text))
            {
                MessageBox.Show("La fecha de inicio del procedimiento es imprescindible y no puede estar vacía...", "Requerimiento Oficio Page",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                datePickerFechaResolucion.Focus();
            }
            else
            {
                Entity = recuperarDatosDelFormulario();
                string textoRequerimiento = String.Empty;
                //textoRequerimiento = ExpedienteIniciadoDeOficio.GenerarTextoRequerimiento(Entity);
                bool resultado = false;
                //resultado = ExpedienteIniciadoDeOficio.GenerarDocumentoTexto(textoRequerimiento, Entity.RUE);
                string textoResultado = "El documento del requerimiento se ha creado satisfactoriamente.";

                if (!resultado)
                {
                    textoResultado = "No se ha podido crear el documento del requerimeinto";
                }

                MessageBox.Show(textoResultado);
                limpiarFormulario();
            }


            
        }

    }
}
