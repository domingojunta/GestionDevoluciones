using GestiónDevoluciones.Entities.DEVINEJE;
using GestiónDevoluciones.Tools;
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
    public partial class DevinejeRSLCaducidadPage : Page
    {
        public DevinejeRSLCaducidadEntity entity;
        DateTime fechaNotificacionRequerimiento;
        DateTime fechaNotificacionAcuerdoInicio;

        public DevinejeRSLCaducidadPage()
        {
            InitializeComponent();

            entity = new DevinejeRSLCaducidadEntity();
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
            bool algunaOpcionSeleccionada =     checkDecretoFirmeza.IsChecked == true ||
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
                MessageBox.Show("El campo RUE no puede estar vacío","RSL de Caducidad", MessageBoxButton.OK,MessageBoxImage.Error);
                txtRUE.Focus();

            }
            else if (txtRUE.Text.Trim().Length<19)
            {
                    
                MessageBox.Show("El campo RUE debe tener al menos 19 caracteres", "RSL de Caducidad", MessageBoxButton.OK, MessageBoxImage.Error);
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
            checkRepresentante.IsChecked=false;
            checkDecretoFirmeza.IsChecked = false;
            checkAcreditacionRepresentacion.IsChecked = false;
            checkCesionCredito.IsChecked = false;
            checkCuentaCorriente.IsChecked = false;
            checkOtroRequerimiento.IsChecked = false;
            txtOtroRequerimientoTexto.Text = "";
            txtOtroRequerimientoTexto.IsEnabled = false;

            btnGenerarTexto.IsEnabled = false;
            txtRUE.Focus();
        }

        private DevinejeRSLCaducidadEntity recuperarDatosDelFormulario ()
        {

            entity = new DevinejeRSLCaducidadEntity();

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

            

            if (checkDecretoFirmeza.IsChecked == true)
            {
                entity.DecretoFirmeza = true;
            }
            else 
            {
                entity.DecretoFirmeza = false;
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
                MessageBox.Show("El campo RUE es obligatorio y no puede estar vacío","Botón Generar Texto",MessageBoxButton.OK, MessageBoxImage.Error);
                txtRUE.Focus();
            }
            else if (String.IsNullOrEmpty(datePickerFechaNotificacionRSLQueGeneraElDerecho.Text))
            {
                MessageBox.Show("La fecha de notificación del acuerdo de oficio que inicia el procedimiento no puede estar vacía.",
                    "RSL Caducidad Page", MessageBoxButton.OK, MessageBoxImage.Error);
                datePickerFechaNotificacionRSLQueGeneraElDerecho.Focus();
                
            }
            else if (String.IsNullOrEmpty(datePickerFechaNotificacionRequerimiento.Text))
            {
                MessageBox.Show("La fecha de notificación del requerimiento no puede estar vacía.",
                    "RSL Caducidad Page", MessageBoxButton.OK, MessageBoxImage.Error);
                datePickerFechaNotificacionRequerimiento.Focus();
                
            } 
            else
            {
                fechaNotificacionAcuerdoInicio = DateTime.Parse(datePickerFechaNotificacionRSLQueGeneraElDerecho.Text);
                fechaNotificacionRequerimiento = DateTime.Parse(datePickerFechaNotificacionRequerimiento.Text);

                if (fechaNotificacionRequerimiento < fechaNotificacionAcuerdoInicio)
                {

                    MessageBox.Show("La fecha del requerimiento no puede ser anterior a la fecha del Acuerdo de Inicio del procedimiento.",
                        "RSL Caducidad Page", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePickerFechaNotificacionRequerimiento.Focus();
                    return;
                }



                var opcion = (int)MessageBox.Show("\nAceptar = Reposición mas TEARA\nCancelar = Reposición mas TEAJA", "Elección de Pie de Recurso"
                , MessageBoxButton.OKCancel, MessageBoxImage.Question);

                entity = recuperarDatosDelFormulario();

                if (opcion == 1)
                {
                    entity.PieDeRecursoTEARA = true;
                }
                else
                {
                    entity.PieDeRecursoTEARA = false;
                }

                //string texto = ExpedienteIniciadoASolicitudDelInteresado.GenerarTextoRSLArchivo(entity);
                //bool resultado = ExpedienteIniciadoASolicitudDelInteresado.GenerarDocumentoTexto(texto, entity.RUE);
                string textoResultado = "El documento de la RSL de archivo se ha creado satisfactoriamente.";

                //if (!resultado)
                //{
                //    textoResultado = "No se ha podido crear el documento del requerimeinto";
                //}

                MessageBox.Show(textoResultado, "Botón Generar Texto", MessageBoxButton.OK, MessageBoxImage.Information);
                limpiarFormulario();
            }

            
        }

        private void datePickerFechaNotificacionRSLQueGeneraElDerecho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (String.IsNullOrEmpty(datePickerFechaNotificacionRSLQueGeneraElDerecho.Text))
                {
                    MessageBox.Show("La fecha de notificación del acuerdo de oficio que inicia el procedimiento no puede estar vacía.",
                        "RSL Caducidad Page", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePickerFechaNotificacionRSLQueGeneraElDerecho.Focus();
                }
            }
           
         }

        private void datePickerFechaNotificacionRequerimiento_KeyDown_1(object sender, KeyEventArgs e)
        {
            
            
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (String.IsNullOrEmpty(datePickerFechaNotificacionRSLQueGeneraElDerecho.Text))
                {
                    MessageBox.Show("La fecha de notificación del acuerdo de oficio que inicia el procedimiento no puede estar vacía.",
                        "RSL Caducidad Page", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePickerFechaNotificacionRSLQueGeneraElDerecho.Focus();
                    return;
                }
                else
                {
                    fechaNotificacionAcuerdoInicio = DateTime.Parse(datePickerFechaNotificacionRSLQueGeneraElDerecho.Text);
                }

                if (String.IsNullOrEmpty(datePickerFechaNotificacionRequerimiento.Text))
                {
                    MessageBox.Show("La fecha de notificación del requerimiento no puede estar vacía.",
                        "RSL Caducidad Page", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePickerFechaNotificacionRequerimiento.Focus();
                    return;
                }
                else
                {
                    fechaNotificacionRequerimiento = DateTime.Parse(datePickerFechaNotificacionRequerimiento.Text);
                }

                if (fechaNotificacionRequerimiento < fechaNotificacionAcuerdoInicio)
                {
                    MessageBox.Show("La fecha del requerimiento no puede ser anterior a la fecha del Acuerdo de Inicio del procedimiento.",
                        "RSL Caducidad Page", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePickerFechaNotificacionRequerimiento.Focus();
                    return;
                }
            }
            
        }
    }
}
