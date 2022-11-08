using Data;
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
        public static BusinessLog log { get; set; } = new BusinessLog();

        public Data.ServicioFichero Fich = new Data.ServicioFichero();
        public int IdHilo { get; set; }

        private DelegadoSaludo delegSaludo;

        public ServicioFichero(DelegadoSaludo delegSaludo)
        {
            this.delegSaludo = delegSaludo;
        }

        public string DameTipo() {
            return "ServicioFichero";
        }
        public void Comprobar(Hilo h)
        {
            int lineas = h.lineas;
            while (h.activo == true) { 
                string fichero = h.quecomprueba;
                using (StreamReader r = new StreamReader(fichero))
                {
                    int i = 0;
                    while (r.ReadLine() != null) { i++; } 
                    if (i > lineas)
                    {
                        //Console.WriteLine("Saltó el delegado");
                        h.activo = false;
                        int resta = i - lineas;
                        log.EscribirFichero("El numero de lineas "  + resta.ToString() + " ha sido sobrepasado con fecha de " + DateTime.Now);
                        delegSaludo("id");
                        NuevasLineas(h.quecomprueba, resta);

                    }
                    h.Duerme();
                }
            }
        }
        public void NuevasLineas(string fichero,int lineas)
        {
            Fich.NuevasLineas(fichero, lineas);
        }
        public bool RutaExiste(string fichero)
        {
            return Fich.RutaExiste(fichero);
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

        public void Arrancar(int idhilo)
        {
            Comprobar(ControladorHilos.DevuelveHilo(idhilo));
        }
        public string[] BorrarLineas(string input, int linesToSkip)
        {
            return Fich.BorrarLineas(input,linesToSkip);
        }

        public void BorrarFichero(string archivo)
        {
            Fich.BorrarFichero(archivo);
        }

        public void SobreEscribirFichero(string archivo, IEnumerable<string> contenido)
        {
            File.WriteAllLines(archivo, contenido);
        }

        public void DefinirRuta(string ruta)
        {
            if (RutaExiste(ruta))
            {
                Directory.SetCurrentDirectory(ruta);
            }
        }

        public bool GuardarConf(Hilo h)
        {
            using (StreamWriter f = new StreamWriter(h.archivoconf))
            {
                f.WriteLine(h.Escribir());
                f.Close();
                return true;
            }

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
