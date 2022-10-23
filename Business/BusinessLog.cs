using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Business
{
    public class BusinessLog
    {
        public void EscribirFichero(string contenido)
        {
            string ficherin = "log.txt";
            FileStream fsW = new FileStream(ficherin, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsW);
            sw.WriteLine(contenido);
            sw.Close();
        }

    }
}
