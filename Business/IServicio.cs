using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IServicio
    {
        void Comprobar(Hilo h);
        void BorrarFichero(string archivo);
        void SobreEscribirFichero(string archivo, IEnumerable<string> contenido);
        void Arrancar(int id);
        string DameTipo();
        bool GuardarConf(Hilo h);
        string DevolverConf(string arch);

    }
}
