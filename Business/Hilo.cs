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

    public void Start()
    {
        string directorio = "";
        int lineas = 0;
        Thread miHilo = new Thread(()=>ser.Arrancar(directorio,lineas));
        miHilo.Start();
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
            return this.id + Environment.NewLine + this.ser + Environment.NewLine + this.activo + Environment.NewLine + this.delay + Environment.NewLine + this.archivoconf;
        }
        public void Mostrar()
        {
            Console.WriteLine(ToString());
        }
}
}
