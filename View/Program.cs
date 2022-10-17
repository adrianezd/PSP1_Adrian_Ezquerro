using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace View
{
    public class Program
    {
        static ControladorHilos c = new ControladorHilos();
        static string directory = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            Menu();
           
        }

        static void SBMenuF()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("COMPROBAR LINEAS DE FICHERO");
            Console.WriteLine("1 - ARRANCAR "); 
            Console.WriteLine("2 - PARAR ");
            Console.WriteLine("3 - Fichero a comprobar ");
            Console.WriteLine("4 - Numero límite de lineas ");
            Console.WriteLine("5 - Delay ");
            Console.WriteLine("0 - Salir al menú principal ");
            Console.WriteLine("***************************************************");
            int opcion = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                c.CrearHiloDirectorio();
                SBMenuF();
            }

            if (opcion == 2)
            {
                c.CrearHiloDirectorio();
                SBMenuF();
            }
            if (opcion == 3)
            {
                //Console.WriteLine("Introduce tu fichero");
                //string fichero = Console.ReadLine();
                c.Cambiar(ControladorHilos.Type.Dir, directory);
                SBMenuF();

            }

            if (opcion == 4)
            {
                Console.WriteLine("Numero limite de lineas");
                int lineas = int.Parse(Console.ReadLine());
                c.LineasMax(lineas);
                SBMenuF();

            }

            if (opcion == 5)
            {
                Console.WriteLine("De cuantos segundos es el delay");
                int delay = int.Parse(Console.ReadLine()) * 1000;
                c.Delay(ControladorHilos.Type.Dir, delay);
                SBMenuF();
            }
            if (opcion == 0) {
               Menu();
            }
        }

        static void SBMenuD()
        {

            Console.WriteLine("***************************************************");
            Console.WriteLine("COMPROBAR MODIFIACIÓN DE DIRECTORIO");
            Console.WriteLine("1 - ARRANCAR ");
            Console.WriteLine("2 - PARAR ");
            Console.WriteLine("3 - Fichero a comprobar ");
            Console.WriteLine("4 - Delay ");
            Console.WriteLine("0 - Salir al menú principal ");
            Console.WriteLine("***************************************************");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                c.CrearHiloDirectorio();
                SBMenuD();
            }

            if (op == 2)
            {
                c.CrearHiloDirectorio();
                SBMenuD();
            }

            if (op == 3)
            {
                Console.WriteLine(directory);
                //string fichero = Console.ReadLine();
                c.ComprobarDirectorio(directory);
                SBMenuD();

            }
            if (op == 4)
            {
                Console.WriteLine("De cuantos segundos es el delay");
                int delay = int.Parse(Console.ReadLine()) * 1000;
                c.Delay(ControladorHilos.Type.Dir, delay);
                SBMenuD();
            }
            if (op == 0) { Menu(); }

        }

        static void SBMenuH()
        {
            c.Mostrar();
            Console.WriteLine("***************************************************");
            Console.WriteLine("MENU DE HILOS");
            Console.WriteLine("1 - Crear hilo");
            Console.WriteLine("2 - Modificar Hilo");
            Console.WriteLine("0 - Salir al menú principal ");
            Console.WriteLine("***************************************************");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                SBMenuH();
            }

            if (op == 2)
            {
                SBMenuH();
            }

            if (op == 3)
            {
                SBMenuH();

            }
            if (op == 4)
            {
                SBMenuH();
            }
            if (op == 0) { Menu(); }

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
