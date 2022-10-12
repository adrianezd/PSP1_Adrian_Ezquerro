using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IServicio
    {
        void Comprobar(int lineas);

        bool RutaExiste(string fichero);

        void BorrarFichero(string archivo);

        void SobreEscribirFichero(string archivo, IEnumerable<string> contenido);

        void DefineNumLineas(int lineas);
        void Duerme(int numero);

        void Arrancar();

        void Parar();

        void DefinirRuta(string ruta);

        string AnadirRuta(string ruta);

    }
}
