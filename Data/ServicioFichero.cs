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

        public void ComprobarLineas(string fichero,int lineas)
        {

        }
        public bool ComprobarRuta(string fichero){
            return File.Exists(fichero);
        }

        public void Arrancar() { 
            estado = true;
        }

        public void Parar() { estado = false; }

        public void DefineNumLineas(int lineas)
        {
            
        }
        public void Duerme(int numero)
        {
            System.Threading.Thread.Sleep(numero);
        }
        public void BorrarFichero(string archivo)
        {
            File.WriteAllText(archivo, "");
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
