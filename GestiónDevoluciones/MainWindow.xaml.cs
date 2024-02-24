using GestiónDevoluciones.Pages;
using GestiónDevoluciones.Pages.SHARED;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestiónDevoluciones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HomePage homePage;
        private RequerimientoDevinginPage requerimientoDevinginPage;
        private RequerimientoIniciadoOficioPage requerimientoIniciadoOficioPage;
        private ArchivoDevinginPage archivoDevinginPage;
        private DevinejeRSLCaducidadPage devinejeRSLCaducidadPage;
        public MainWindow()
        {
            InitializeComponent();
            txtEstado.Text = "Barra de estado que contendrá información sobre lo que está haciendo la aplicación";
            this.homePage = new HomePage();           //this.requerimientoSolicitudInteresado = new RequerimientoSolicitudInteresado();
            //this.requerimientoIniciadoOficio = new RequerimientoIniciadoOficio();
            frame.NavigationService.Navigate(homePage);
        }

        private void menuSalir_Click(object sender, RoutedEventArgs e)
        {
            
            txtEstado.Text = "Saliendo...";
            Application.Current.Shutdown(0);
        }

        

        private void menuRequerimientoInicioOficio_Click(object sender, RoutedEventArgs e)
        {
            this.requerimientoIniciadoOficioPage = new RequerimientoIniciadoOficioPage();
            txtEstado.Text = "Página para realizar un requerimiento en un procedimiento iniciado de oficio...";
            frame.NavigationService.Navigate(requerimientoIniciadoOficioPage);
        }

        private void menuInicio_Click(object sender, RoutedEventArgs e)
        {
            txtEstado.Text = "Barra de estado que contendrá información sobre lo que está haciendo la aplicación";
            frame.NavigationService.Navigate(homePage);
        }

       

       

        private void menuResolucionCaducidad_Click(object sender, RoutedEventArgs e)
        {
            this.devinejeRSLCaducidadPage = new DevinejeRSLCaducidadPage();
            txtEstado.Text = "Página para realizar una RSL de Caducidad del procedimiento por no atender el requerimiento en 6 meses.";
            frame.NavigationService.Navigate(devinejeRSLCaducidadPage);
        }

        private void menuRequerimientoInicioSolicitudInteresadoNoTributario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuResolucionArchivoNoTributario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuRequerimientoInicioOficioNoTributaria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuResolucionCaducidadNoTributaria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuRequerimientoDevinginTributario_Click(object sender, RoutedEventArgs e)
        {
            this.requerimientoDevinginPage = new RequerimientoDevinginPage();
            txtEstado.Text = "Página para realizar un requerimiento de subsanación de la solicitud, en un DEVINGIN Tributario.";
            frame.NavigationService.Navigate(requerimientoDevinginPage);
        }

        private void menuResolucionArchivoDevinginTributario_Click(object sender, RoutedEventArgs e)
        {
            this.archivoDevinginPage = new ArchivoDevinginPage();
            txtEstado.Text = "Página para realizar una RSL de Archivo de la solicitud por no atender el requerimiento en un DEVINGIN Tributario.";
            frame.NavigationService.Navigate(archivoDevinginPage);
        }

        private void menuRequerimientoDevinginNoTributario_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuResolucionArchivoDevinginNoTributario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}