using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ControladorHilos
    {
        public static List<Hilo> hilos = new List<Hilo>();

        public enum Tipo{
            SD,
            SI
        }

        public static int count;

        public static Hilo GenerarHilo(Tipo tipo)
        {
            count++;
            if(tipo == Tipo.SI) {
                return new Hilo { id = count, ser = new ServicioFichero() { IdHilo=count} };
            }
            if (tipo == Tipo.SD) {
                return new Hilo { id = count, ser = new ServicioDirectorio() { IdHilo = count } };
            }
            return null;
        }

        public static void CrearHiloDirectorio()
        {
            var hilo = GenerarHilo(Tipo.SD);
            hilos.Add(hilo);
            hilo.Start();
        }

        public static void Turnar(int id)
        {
            Hilo h = DevuelveHilo(id);
            h.Turnar();
        }

        public static void CrearHiloFichero()
        {
            var hilo = GenerarHilo(Tipo.SI);
            hilos.Add(hilo);
            hilo.Start();
        }

        public static void Mostrar()
        {
            foreach (Hilo h in hilos)
            {
                Console.WriteLine("[" + h.id  + "] " + " -> " + h.DameTipo() + " -> ¿Activo? " + h.activo);
            }
        }

        public static Hilo BuscarHilo(int id)
        {
            foreach(Hilo hilin in hilos)
            {
                if (hilin.id == id)
                {
                    return hilin;
                }
            }
            return null;
        }

        public static Hilo DevuelveHilo(int id)
        {
            foreach (Hilo hilin in hilos)
            {
                if (hilin.id == id)
                {
                    return hilin;
                }
            }
            return null;
        }

        public static void BorrarHilo(int hiloid)
        {
            Hilo hilin = DevuelveHilo(hiloid);
            hilos.Remove(hilin);
        }

        public static bool GuardarConf(Hilo h)
        {
            return h.ser.GuardarConf(h);
        }

        public static string DevolverInfo(Hilo h, string fichero)
        {
            string datos = h.ser.DevolverConf(fichero);
            Console.WriteLine("datos->" + datos);
            return datos;
        }

    }
}
