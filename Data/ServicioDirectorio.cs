using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class ServicioDirectorio
    {
        static string ruta;
        public string directorioAcomprobar { get; set; }
        public bool activo { get; set; }
        public int delay { get; set; }

        public ServicioDirectorio()
        {
            this.directorioAcomprobar = directorioAcomprobar;
            this.activo = activo;
            this.delay = delay;
        }

        public bool ComprobarRuta(string directorio)
        {
            return Directory.Exists(directorio);
        }
        public string AñadirRuta(string ruta)
        {
            return ruta = "@C:\\ " + ruta;
        }
        public void DefinirRuta(string ruta)
        {
            Directory.SetCurrentDirectory(ruta);
        }

        public void BorrarFichero(string archivo)
        {
            File.WriteAllText(archivo, "");
        }

        public void SobreEscribirFichero(string archivo, IEnumerable<string> contenido)
        {
            File.AppendAllLines(archivo, contenido);
        }

        public string DevolverConf(string arch)
        {
            try
            {
                using (StreamReader r = new StreamReader(arch))
                {
                    string texto = r.ReadToEnd();
                    return texto;
                }
            }
            catch
            {
                return "";
            }

        }

    }

}   
