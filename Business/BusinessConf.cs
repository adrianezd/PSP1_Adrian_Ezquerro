using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Business
{
    public class BusinessConf
    {
        public int id=0;

        public BusinessConf(int id)
        {
            this.id = id++;
        }

        public void EscribirFichero(string contenido)
        {
//            direcDelay = 4
//direcRuta = sdaddada
//contenidoDirectorio = 12
//fichDelay = 5
            string ficherin = "conf" + id  + ".txt";
            FileStream fsW = new FileStream(ficherin, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsW);
            sw.WriteLine(contenido);
            sw.Close();
        }
    }
}