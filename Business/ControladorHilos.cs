using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ControladorHilos
    {
        public List<Hilo> hilos = new List<Hilo>();

        ServicioDirectorio SD = new ServicioDirectorio();
        ServicioFichero SI = new ServicioFichero();

        public static int count;

        public ControladorHilos()
        {
            this.hilos = new List<Hilo>();
        }

        public enum Type
        {
            Dir,
            Fich
        }

        public Hilo GenerarHilo(IServicio tipo)
        {
            count++;
            return new Hilo { id = count, ser = tipo };
        }

        public void CrearHiloDirectorio()
        {
            if (SD.activo == true)
            {
                SD.Parar();
            }
            else
            {
                var hilo = GenerarHilo(SD);
                hilo.Start();
                hilos.Add(hilo);
                SD.activo = true;
            }

        }

        public void Turnar(int id)
        {
            Hilo h = DevuelveHilo(id);
            h.Turnar();
        }

        public void CrearHiloFichero()
        {
            if (SI.activo == true)
            {
                SI.Parar();
            }
            else
            {
                var hilo = GenerarHilo(SI);
                hilo.Start();
                hilos.Add(hilo);
                SI.activo = true;
            }
        }

        public void Cambiar(Type tipo, string ruta)
        {
            if (tipo == Type.Fich)
            {
                SI.DefinirRuta(ruta);
            }
            if(tipo == Type.Dir)
            {
                SD.DefinirRuta(ruta);
            }
        }

        public void Delay(Type tipo,int delay)
        {
            if (tipo == Type.Fich)
            {
                SI.Duerme(delay);
            }
            if (tipo == Type.Dir)
            {
                SD.Duerme(delay);
            }
        }


        public void LineasMax(int lineas)
        {
            SI.DefineNumLineas(lineas);
        }

        public void Mostrar()
        {
            foreach (Hilo h in hilos)
            {
                Console.WriteLine("[" + h.id  + "] " + " -> " + h.DameTipo() + " -> ¿Activo? " + h.activo);
            }
        }

        public void ArrancarHilo(Type type,string ruta, int lineas)
        {
            if(type == Type.Fich)
            {
                SI.Arrancar("",0);
            }

            if (type == Type.Dir)
            {
                SD.Arrancar("",0);
            }
        }

        public Hilo BuscarHilo(int id)
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

        public Hilo DevuelveHilo(int id)
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

        public void BorrarHilo(int hiloid)
        {
            Hilo hilin = DevuelveHilo(hiloid);
            hilos.Remove(hilin);
        }

        public bool EscribirFichero(string ruta)
        {
            SD.EscribirFichero(ruta);
            return true;
        }

        public bool GuardarConf(Hilo h)
        {
            return h.ser.GuardarConf(h);
        }

        public string DevolverInfo(Hilo h, string fichero)
        {
            return h.ser.DevolverConf(fichero);
        }

    }
}
