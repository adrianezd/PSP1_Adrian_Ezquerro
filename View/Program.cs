using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace View
{
    public class Program
    {
        static ControladorHilos c = new ControladorHilos();

        static void Main(string[] args)
        {
            Menu();
           
        }

        static void SBMenuF()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("COMPROBAR LINEAS DE FICHERO");
            Console.WriteLine("1 - ARRANCAR / PARAR "); //cnd detecte que se han pasado, escribe en log y conf y para hilo
            Console.WriteLine("2 - Fichero a comprobar ");
            Console.WriteLine("3 - Numero límite de lineas ");
            Console.WriteLine("4 - Delay ");
            Console.WriteLine("0 - Salir al menú principal ");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                c.CrearHiloDirectorio();
            }
            if (opcion == 2)
            {
                Console.WriteLine("Introduce tu fichero");
                string fichero = Console.ReadLine();
                c.Cambiar(ControladorHilos.Type.Dir, fichero);

            }

            if (opcion == 3)
            {
                Console.WriteLine("Numero limite de lineas");
                int lineas = int.Parse(Console.ReadLine());
                c.LineasMax(lineas);

            }

            if (opcion == 4)
            {
                Console.WriteLine("De cuantos segundos es el delay");
                int delay = int.Parse(Console.ReadLine()) * 1000;
                c.Delay(ControladorHilos.Type.Dir, delay);
            }
            if (opcion == 0) { }
        }

        static void SBMenuD()
        {

            Console.WriteLine("***************************************************");
            Console.WriteLine("COMPROBAR MODIFIACIÓN DE DIRECTORIO");
            Console.WriteLine("1 - ARRANCAR / PARAR");
            Console.WriteLine("2 - Fichero a comprobar ");
            Console.WriteLine("3 - Delay ");
            Console.WriteLine("0 - Salir al menú principal ");
            Console.WriteLine("***************************************************");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                c.CrearHiloDirectorio();
            }
            if (op == 2)
            {
                Console.WriteLine("Introduce tu fichero");
                string fichero = Console.ReadLine();
                c.Cambiar(ControladorHilos.Type.Dir, fichero);

            }
            if (op == 3)
            {
                Console.WriteLine("De cuantos segundos es el delay");
                int delay = int.Parse(Console.ReadLine()) * 1000;
                c.Delay(ControladorHilos.Type.Dir, delay);
            }
            if (op == 0) {
                op=5;}

        }

        static void SBMenuH()
        {

            Console.WriteLine("***************************************************");
            Console.WriteLine("MENU DE HILOS");
            Console.WriteLine("1 - Crear hilo");
            Console.WriteLine("2 - Modificar Hilo");
            Console.WriteLine("0 - Salir al menú principal ");
            Console.WriteLine("***************************************************");
            int op = int.Parse(Console.ReadLine());

        }

        static void Menu()
        {

            int op = -1;
            while (op != 5)
            {
                Console.WriteLine("***************************************************");
                Console.WriteLine("Servicios Asincronos");
                Console.WriteLine("Introduce la opción que desea realizar");
                Console.WriteLine("0 - Cerrar programa ");
                Console.WriteLine("1 - Comprobar Modificacion de directorio "); //cnd detecte que se han pasado, escribe en log y conf y para hilo
                Console.WriteLine("2 - Comprobar Lineas de Fichero ");
                Console.WriteLine("3 - MenuHilos ");
                Console.WriteLine("***************************************************");

                op = int.Parse(Console.ReadLine());
                if (op == 1) {
                    SBMenuD();
                }
                if (op == 2)
                {
                    SBMenuF();
                }
                if (op == 3)
                {
                    SBMenuH();
                }
                else { Environment.Exit(0); }
            }
        }   
    }
}
