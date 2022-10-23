﻿using Data;
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
        public static BusinessLog log { get; set; } = new BusinessLog();

        public Data.ServicioFichero Fich = new Data.ServicioFichero();
        public int IdHilo { get; set; }

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
                        h.activo = false;
                        int resta = i - lineas;
                        log.EscribirFichero("El numero de lineas "  + resta.ToString() + " ha sido sobrepasado con fecha de " + DateTime.Now);
                        r.Close();
                        NuevasLineas(h.quecomprueba, resta);
                        //string contenido = GuardadoLineas(fichero);
                        //Console.WriteLine("tu contenido es " + contenido);
                        //string[] newContent = BorrarLineas(contenido, lineas);
                        //Console.WriteLine("el new content es " +  newContent);
                        //r.Close();
                        //File.WriteAllLines(fichero, newContent.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray());


                    }
                    h.Duerme();
                }

            }
        }
        public void NuevasLineas(string fichero,int lineas)
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
                //Console.WriteLine("cont -->" + cont);
            }

        }
        public string DevolverConf(string arch)
        {
            using (StreamReader r = new StreamReader(arch))
            {
                string texto = r.ReadToEnd();
                //Console.WriteLine("Texto es " + texto);
                //Console.WriteLine("cont -->" + cont);
                return texto;
            }

        }
    }
}
