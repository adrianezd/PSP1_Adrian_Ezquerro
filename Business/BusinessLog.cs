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
        string rutaC;
        string nombreArchivo;
        bool estado;
        string dato2 = "";
        string dato3 = "";
        public void EscribirFichero(string rutaC, string nombreArchivo, bool estado, string dato2, string dato3)
        {
            DateTime utcDate = DateTime.UtcNow;
            string rutatotal = rutaC + nombreArchivo;
            string contenido = utcDate.ToString() + " -> " + dato2 + " " + dato3 + " " + estado.ToString();
            File.WriteAllText(rutatotal, contenido);
        }

    }
}
