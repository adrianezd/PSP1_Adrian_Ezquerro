using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class ServicioFichero
    {
        bool estado = false;

        public ServicioFichero()
        {
            this.estado = estado;
        }

        public void BorrarFichero(string archivo)
        {
            File.WriteAllText(archivo, "");
        }
        public void NuevasLineas(string fichero, int lineas)
        {
            bool compruebaLineas = true;
            while (compruebaLineas == true)
            {
                try
                {
                    compruebaLineas = false;
                    string[] lines = File.ReadAllLines(fichero);
                    List<string> lineasAnadir = new List<string>();
                    int cont = 0;
                    foreach (string l in lines)
                    {
                        if (cont == lineas)
                        {
                            lineasAnadir.Add(l);
                        }
                        else
                        {
                            cont++;
                        }
                    }
                    File.WriteAllLines(fichero, lineasAnadir);
                    Console.WriteLine("tu output ----> " + lineasAnadir);
                }
                catch
                {
                    compruebaLineas = true;
                }
            }

        }
        public void DefinirRuta(string ruta)
        {
            if (RutaExiste(ruta))
            {
                Directory.SetCurrentDirectory(ruta);
            }
        }

        public string[] BorrarLineas(string input, int linesToSkip)
        {

            string[] lines = input
            .Split(Environment.NewLine.ToCharArray())
            .Skip(linesToSkip)
            .ToArray();

            string output = string.Join(Environment.NewLine, lines);
            Console.WriteLine("tu output ----> " + output);
            //output = output.Replace(" ", String.Empty);
            string[] strAllLines = new[] { output };
            Console.WriteLine("las strALlLines son " + strAllLines);
            return strAllLines;
            //Selecciona las lineas que no sean null o blancas
            //Guarda las nuevas lineas en el nuevo fichero

        }
        public bool RutaExiste(string fichero)
        {
            bool isPath = false;
            if (File.Exists(fichero)) isPath = true;
            return isPath;
        }
    }
}
