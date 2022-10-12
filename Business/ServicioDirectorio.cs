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
        public string directorioAcomprobar { get; set; }
        public bool activo { get; set; }
        public int delay { get; set; }

        public void Comprobar(int id) { }
        public void Comprobar(string directorio)
        {
            if (RutaExiste(directorio))
            {
                directorio = "@C:\\Users\\adria\\source\\repos\\PSP1_Adrian_Ezquerro\\View\\conf.txt";
                string linea = null;
                int i = 0;
                StreamReader archivo = File.OpenText(directorio);
                while (!archivo.EndOfStream)
                {
                    //Leer la 3ra línea:
                    linea = archivo.ReadLine();
                    if (++i == 3) break;
                }
                linea = linea.Split('=')[1].ToString();
                int antiguoCount = 0;
                antiguoCount = Convert.ToInt32(linea);
                string[] contador = Directory.GetFileSystemEntries(directorio, "*", SearchOption.AllDirectories);
                if (contador.Length != antiguoCount) { Console.WriteLine("Ha habido modificacion"); }
            }
            else { Console.WriteLine("No existe el directorio"); }

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
            File.AppendAllLines(archivo, contenido);
        }

        public void Arrancar() { activo = true; }

        public void Parar() { activo = false; }

        public void DefineNumLineas(int lineas)
        {
            
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
