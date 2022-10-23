﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public class ServicioDirectorio
    {
        static string ruta;
        public string directorioAcomprobar { get; set; }
        public bool activo { get; set; }
        public int delay { get; set; }

        public ServicioDirectorio()
        {
            this.directorioAcomprobar = directorioAcomprobar;
            this.activo = activo;
            this.delay = delay;
        }

        public bool ComprobarRuta(string directorio)
        {
            return Directory.Exists(directorio);
        }
        public string AñadirRuta(string ruta)
        {
            return ruta = "@C:\\ " + ruta;
        }
        public void DefinirRuta(string ruta)
        {
            Directory.SetCurrentDirectory(ruta);
        }

        public void BorrarFichero(string archivo)
        {
            File.WriteAllText(archivo, "");
        }

        public void SobreEscribirFichero(string archivo, IEnumerable<string> contenido)
        {
            File.AppendAllLines(archivo, contenido);
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

    //fichero a comprobar
}   //añadir fichero en blanco
    //vaciar fichero
    //escribir en log, conf fichero y comprobar numeromaximode lineas
    //en data estar todas las operaciones que necesites para lidiar con los ficheros
    //si existe, escribe -> eso en business
    //clase para configuracion
    //clase para log (solo es escribir fichero (escribe splo cnd detecta cambio en el fichero))
    //hilo.servicio.delay
    //hilo.servicio.GetType == Tipo que quieres
    //coges el hilo que sea de ese -> si == ServicioFichero (dale este menu), si no, dale este otro menu
    //Environment.NewLine -> = \\n; lo mismo que poner salto de linea a mano pero mejor, te coge automatico el salto de linea del S.O dnd se ejectute
    //for(i=0,i<10,i++)
    //  contenido=linea+Environment.NewLine
    //metodo en data para escribir pisando lo que hay (writeAllText)
    //typeof(IServicio)