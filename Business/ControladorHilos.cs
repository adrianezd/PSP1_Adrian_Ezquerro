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
            this.hilos = hilos;
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
            }

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

        public void ComprobarDirectorio(string directorio)
        {
            SD.Comprobar(directorio);
        }

        public void Mostrar()
        {
            foreach (Hilo h in hilos)
            {
                Console.WriteLine(h.ToString());
            }
        }

    }
}
