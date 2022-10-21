using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class Hilo
    {
        public Thread miHilo;
        public int id;
        public IServicio ser;
        public bool activo = false;
        public int delay;
        public string archivoconf;
        public string quecomprueba;
        public string tipo;
        public int lineas=0;

    public void Start()
    {
        if (activo == true)
        {
            Thread miHilo = new Thread(() => ser.Arrancar(archivoconf, lineas));
            miHilo.Start();
        }

    }

        public void Turnar()
        {
            if (activo == false)
            {
                activo = true;
            }
            else
            {
                activo = false;
            }
        }
        
        public override String ToString()
        {

            return "id -> " + this.id + Environment.NewLine + "¿activo? -> " + this.activo + Environment.NewLine + "delay -> " + this.delay + Environment.NewLine + "su archivo conf es -> " + this.archivoconf + Environment.NewLine + "tipo -> " + DameTipo()+ Environment.NewLine;
        }
        public void Mostrar()
        {
            Console.WriteLine(ToString());
        }

        public string DameTipo()
        {
            return ser.DameTipo();
        }
}
}
