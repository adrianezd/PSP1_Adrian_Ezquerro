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
        public static BusinessLog log { get; set; } = new BusinessLog();

        public Data.ServicioFichero F1 = new Data.ServicioFichero();

        public string DameTipo() {
            return "ServicioFichero";
        }
        public void Comprobar(int lineas,Hilo h)
        {
            while (h.activo == true) { 
                string fichero = "leer.txt";
                using (StreamReader r = new StreamReader(fichero))
                {
                    int i = 0;
                    while (r.ReadLine() != null) { i++; }
                    if (i > lineas)
                    {
                        string resta = (i - lineas).ToString();
                        //Console.WriteLine(resta + "es la resta");
                        DateTime localDate = DateTime.Now;
                        log.EscribirFichero("El numero de lineas " + resta + " ha sido sobrepasado con fecha de " + localDate.ToString());
                        //Console.WriteLine("Hay " + i + " lineas" + " y quieres borrar las " + lineas + " primeras");

                        string contenido = GuardadoLineas(fichero);
                        //Console.WriteLine(" tu contenido ---> " + contenido);
                        string newContent = BorrarLineas(contenido, lineas);
                        //Console.WriteLine("acabe");
                        newContent = newContent.Replace(" ", String.Empty);
                        //Console.WriteLine(newContent + "mi nuevo contenido");
                        r.Close();
                        FileStream fsW = new FileStream(fichero, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fsW);
                        //sw.Write(newContent);
                        sw.Write("");
                        sw.WriteLine(newContent);
                        sw.Close();
                    }
                    else { Console.WriteLine("No existe el fichero"); }
                }
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
            string cont;
            using (StreamReader r = new StreamReader(fichero))
            {
                cont = r.ReadToEnd();
                //Console.WriteLine("cont -->" + cont);
            }
            return cont;
        }

        public void Arrancar(string directorio, int lineas)
        {
            //activo = true;
            //Comprobar(lineas);
        }
        public string BorrarLineas(string input, int linesToSkip)
        {

            string[] lines = input
            .Split(Environment.NewLine.ToCharArray())
            .Skip(linesToSkip + 1)
            .ToArray();

            string output = string.Join(Environment.NewLine, lines);
            //Console.WriteLine("tu output ----> " + output);
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
                F1.Arrancar();
            }
        }


        public void BorrarFichero(string archivo)
        {
            File.WriteAllText(archivo, "");
        }

        public void SobreEscribirFichero(string archivo, IEnumerable<string> contenido)
        {
            File.WriteAllLines(archivo, contenido);
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
            string conf = "conf.txt";
            string newText = "";
            int line_to_edit = 4;
            newText = "direcDelay=" + numero;
            string[] arrLine = File.ReadAllLines(conf);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(conf, arrLine);

            System.Threading.Thread.Sleep(numero * 1000);
        }

        public string AnadirRuta(string ruta)
        {
            return ruta = "@C:\\ " + ruta;
        }

    }
}
