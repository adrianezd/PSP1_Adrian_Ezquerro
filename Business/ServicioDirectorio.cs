using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class ServicioDirectorio : IServicio
    {
        public int IdHilo { get; set; }
        public static BusinessLog log { get; set; } = new BusinessLog();
        public Data.ServicioDirectorio Dir = new Data.ServicioDirectorio();

        public string DameTipo()
        {
            return "ServicioDirectorio";
        }
        public void Comprobar(Hilo h)
        {
            while (h.activo == true)
            {
                DateTime dt = Directory.GetLastWriteTime(h.quecomprueba);
                DateTime fecha = DateTime.Parse(GetLastWrite("conf.txt"));
                    if (fecha < dt)
                    {
                        log.EscribirFichero("El directorio " + h.quecomprueba + " ha sido sobreescrito con fecha de " + DateTime.Now);
                        File.WriteAllText("conf.txt","lastWrite=" + dt.ToString());
                        h.activo= false;
                    }
                h.Duerme();
            }
        }

        public string GetLastWrite(string fichero)
        {
            using (StreamReader r = new StreamReader(fichero))
            {
                string texto = r.ReadToEnd();
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                string[] items = texto.TrimEnd(';').Split(';');
                foreach (string item in items)
                {
                    string[] keyValue = item.Split('=');
                    dictionary.Add(keyValue[0], keyValue[1]);
                }
                r.Close();
                return (dictionary["lastWrite"]);

            }
        }


        public void BorrarFichero(string archivo)
        {
            Dir.BorrarFichero(archivo);
        }

        public void SobreEscribirFichero(string archivo, IEnumerable<string> contenido)
        {
            Dir.SobreEscribirFichero(archivo, contenido);
        }

        public void Arrancar(int id) {
            Comprobar(ControladorHilos.DevuelveHilo(id));
        }

        public bool GuardarConf(Hilo h)
        {
            using (StreamWriter f = new StreamWriter(h.archivoconf))
            {
                f.WriteLine(h.ToString());
                f.Close();
                return true;
            }

        }
        public string DevolverConf(string arch)
        {
            return Dir.DevolverConf(arch);
        }

    }
}
