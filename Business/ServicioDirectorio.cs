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
            int line_number = 1;
            int line_to_edit = 3;

            if (RutaExiste(directorio))
            {
                string conf = "conf.txt";
                //directorio = "@C:\\Users\\adria\\source\\repos\\PSP1_Adrian_Ezquerro\\View\\bin\\debug";
                string directory = Directory.GetCurrentDirectory();
                //Console.WriteLine(directory + "mi directorio es");
                string linea = null;
                IEnumerable<string> cosasDirectorio = Directory.EnumerateFileSystemEntries(directory);
                //Console.WriteLine(cosasDirectorio.Count());
                FileStream fsR = new FileStream(conf, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fsR);
                sr.Close();
                string line = File.ReadLines(conf).Skip(2).Take(1).First();
                line = line.Split('=')[1];
                int lineInt = Int32.Parse(line);
                //Console.WriteLine(line);
                if (lineInt != cosasDirectorio.Count()) { 
                    //Console.WriteLine("Ha habido modificacion");
                    lineChanger((cosasDirectorio.Count().ToString()), conf, line_to_edit);
                    //Console.ReadLine();
                }
            }
            else { Console.WriteLine("No existe el directorio"); }

        }

        public void EscribirFichero(string cont)
        {
            string conf = "conf.txt";
            int line_to_edit = 2;
            cont = "direcRuta=" + cont;
            string[] arrLine = File.ReadAllLines(conf);
            arrLine[line_to_edit - 1] = cont;
            File.WriteAllLines(conf, arrLine);
        }


        public void lineChanger(string newText, string fileName, int line_to_edit)
        {
            newText = "contenidoDirectorio=" + newText;
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        public bool RutaExiste(string fichero)
        {
            //bool isPath = false;
            //if (File.Exists(fichero)) isPath = true;
            //return isPath;
            return true;
        }


        public void BorrarFichero(string archivo)
        {
            File.WriteAllText(archivo, "");
        }

        public void SobreEscribirFichero(string archivo, IEnumerable<string> contenido)
        {
            File.AppendAllLines(archivo, contenido);
        }

        public void Arrancar(string directorio, int lineas) { 
            activo = true;
            Comprobar(directorio);
        }

        public void Parar() { activo = false; }

        public void DefineNumLineas(int lineas)
        {
            
        }

        public void GetAllFromDirectory(string directory)
        {
            IEnumerable<string> contenido = Directory.EnumerateFileSystemEntries(directory, "*", SearchOption.AllDirectories);
            Console.WriteLine("el get all from directory saca " + contenido);
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
            string newText ="";
            int line_to_edit = 1;
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
