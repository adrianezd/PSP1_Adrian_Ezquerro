using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ServicioFichero : IServicio
    {
        static string ruta;
        public string directorioAcomprobar { get; set; }
        public bool activo { get; set; }
        public int delay { get; set; }

        
        
        public void Comprobar(int lineas)
        {
            string fichero = "";
            if (RutaExiste(fichero))
                fichero = "@C:\\" + fichero;

            int lineCount = File.ReadAllLines(fichero).Length;
            if (lineCount > lineas)
            {
                //Escribir en log
                //Escribir en file?
                Console.WriteLine("Te has pasado de lineas");
            }
            else { Console.WriteLine("No existe el fichero"); }
        }
        public bool RutaExiste(string fichero)
        {
            bool isPath = false;
            if (File.Exists(fichero)) isPath = true;
            return isPath;
        }


        public void BorrarFichero(string archivo)
        {
            File.WriteAllText(archivo, "");
        }

        public void SobreEscribirFichero(string archivo, IEnumerable<string> contenido)
        {
            File.AppendAllLines(archivo,contenido);
        }

        public void Arrancar() { activo = true; }

        public void Parar() { activo = false; }

        public void DefineNumLineas(int lineas)
        {
            DefineNumLineas(lineas);
        }

        public void DefinirRuta(string ruta)
        {
            if (RutaExiste(ruta))
            {
                Directory.SetCurrentDirectory(ruta);
            }
        }
        public void Duerme(int numero)
        {
            System.Threading.Thread.Sleep(numero);
        }

        public string AnadirRuta(string ruta)
        {
            return ruta = "@C:\\ " + ruta;
        }

    }
}
