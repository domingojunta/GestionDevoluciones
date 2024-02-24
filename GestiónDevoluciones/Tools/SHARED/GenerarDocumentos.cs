using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestiónDevoluciones.Tools.SHARED
{
    public class GenerarDocumentos
    {
        public static bool GenerarDocumentoTxt(string texto, string RUE)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string rutaConDirectorio = ruta + "\\GestionDevoluciones";
                if (!Directory.Exists(rutaConDirectorio))
                {
                    Directory.CreateDirectory(rutaConDirectorio);
                }
                string rutaConDirectorioDeRequerimiento = rutaConDirectorio + $"\\{RUE.ToUpper().Trim()}";
                if (!Directory.Exists(rutaConDirectorioDeRequerimiento))
                {
                    Directory.CreateDirectory(rutaConDirectorioDeRequerimiento);
                }
                string path = rutaConDirectorioDeRequerimiento + $"\\{RUE.ToUpper().Trim()}.txt";

                File.WriteAllText(path, texto, Encoding.UTF8);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
