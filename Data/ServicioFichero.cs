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

        public void DefinirRuta(string ruta)
        {
            Directory.SetCurrentDirectory(ruta);
        }
    }
}
