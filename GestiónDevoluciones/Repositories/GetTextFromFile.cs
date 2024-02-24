using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GestiónDevoluciones.Repositories
{
    public static class GetTextFromFile
    {
        public static string getTexto(string nombreArchivo)
        {
            try
            {
                string directorioActual = Directory.GetCurrentDirectory();
                string path = $"{directorioActual}\\TextosPredefinidos\\{nombreArchivo}";
                string texto = File.ReadAllText(path);
                //MessageBox.Show(texto,"GetTextFromFile",MessageBoxButton.OK,MessageBoxImage.Information);
                return texto;
            }
            catch (Exception)
            {

                return String.Empty;
            }
        }
    }
}
