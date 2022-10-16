using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Business
{
    public class ServicioFichero : IServicio
    {
        string ruta;
        public int numLineasServicio { get; set; }
        public bool activo { get; set; }
        public int delay { get; set; }
        public BusinessConf conf { get; set; }
        public BusinessLog log { get; set; }

        //public ServicioFichero F1 = new ServicioFichero();

        public void Comprobar(int lineas)
        {
            string fichero = "leer.txt";
            //if (RutaExiste(fichero))
            //    fichero = "@C:\\" + fichero;
            FileStream fsR = new FileStream(fichero, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fsR);
            string dep = sr.ReadToEnd();
            Console.WriteLine("Tu dep es -->", dep);
            using (StreamReader r = new StreamReader(fichero))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                Console.WriteLine("contenido antes de comparar lineas ---> ", i);

                //Console.WriteLine(lineCount.ToString(), "<-- es tu linecount");
                if (i > lineas)
                {
                    Console.WriteLine("Hay " + i + " lineas" +  " y quieres borrar las " + lineas +  " primeras");

                    string contenido = GuardadoLineas(fichero);
                    Console.WriteLine(" tu contenido ---> ", contenido);
                    BorrarLineas(contenido, lineas);
                    Console.WriteLine("acabe");
                    //Escribir en file?
                    Console.ReadLine();
                }
                else { Console.WriteLine("No existe el fichero"); }
            }
        }
        public bool RutaExiste(string fichero)
        {
            bool isPath = false;
            if (File.Exists(fichero)) isPath = true;
            return isPath;
        }

        public string GuardadoLineas(string fichero)
        {
            string lineasTotales = "";
            string[] basurilla = new string[10];
            using (StreamReader r = new StreamReader(fichero))
            {
                string cont = r.ReadToEnd();
                Console.WriteLine("cont -->", cont);
            }
            return "";
        }

        public string BorrarLineas(string input, int linesToSkip)
        {

            string[] lines = input
            .Split(Environment.NewLine.ToCharArray())
            .Skip(linesToSkip)
            .ToArray();

            string output = string.Join(Environment.NewLine, lines);
            Console.WriteLine("tu output ----> ", output);
            return output;

            //int startIndex = 0;
            //for (int i = 0; i < linesToSkip; ++i)
            //    startIndex = input.IndexOf('\n', startIndex) + 1;
            //return input.Substring(startIndex);
        }

        public void GuardarContenidoNuevo(string fichero, string contenido)
        {
            using (StreamWriter w = new StreamWriter(fichero))
            {
                
            }
        }


        public void BorrarFichero(string archivo)
        {
            File.WriteAllText(archivo, "");
        }

        public void SobreEscribirFichero(string archivo, IEnumerable<string> contenido)
        {
            File.WriteAllLines(archivo,contenido);
        }

        public void Arrancar() { activo = true; }

        public void Parar() { activo = false; }

        public void DefineNumLineas(int lineas)
        {
            Comprobar(lineas);
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
