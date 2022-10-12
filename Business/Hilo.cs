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

    public void Start()
    {   
        Thread miHilo = new Thread(ser.Arrancar);
        miHilo.Start();
    }
}
}
