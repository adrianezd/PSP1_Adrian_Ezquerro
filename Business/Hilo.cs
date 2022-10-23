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
            Thread miHilo = new Thread(() => ser.Arrancar(id));
            miHilo.Start();
        }

    }

        public void Turnar()
        {
            if (activo == false)
            {
                activo = true;
                Start();
            }
            else
            {
                activo = false;
            }
        }
        
        public override String ToString()
        {

            return "id:" + this.id + Environment.NewLine + "confanalizar:" + this.quecomprueba + Environment.NewLine + "activo:" + this.activo + Environment.NewLine  + "lineas:" + this.lineas  + Environment.NewLine  + "delay:" + this.delay + Environment.NewLine + "archivoconf:" + this.archivoconf + Environment.NewLine + "tipo:" + DameTipo()+ Environment.NewLine;
        }
        public String Escribir()
        {
            return "id-" + this.id + ";confanalizar-" + this.quecomprueba + ";activo-" + this.activo + ";lineas-" + this.lineas + ";delay-" + this.delay + ";archivoconf-" + this.archivoconf + ";tipo-" + DameTipo();
        }
        public void Mostrar()
        {
            Console.WriteLine(ToString());
        }

        public string DameTipo()
        {
            return ser.DameTipo();
        }

        public void Duerme()
        {
            Thread.Sleep(delay * 1000);
        }
}
}
