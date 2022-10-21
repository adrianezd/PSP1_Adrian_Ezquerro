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
        public enum Type
        {
            ServicioDirectorio,
            ServicioFichero
        }

        static void SBMenuF(int hiloid)
        {
            Hilo hilito = c.DevuelveHilo(hiloid);

            Console.WriteLine("***************************************************");
            Console.WriteLine("BIENVENIDO AL MENU DE TU HILO " + hilito.DameTipo() + " con id " + hiloid);
            hilito.Mostrar();
            Console.WriteLine("***************************************************");
            Console.WriteLine("");
            Console.WriteLine("***************************************************");
            Console.WriteLine("1 - ARRANCAR/PARAR "); 
            Console.WriteLine("2 - Fichero | Directorio a comprobar ");
            Console.WriteLine("3 - Numero límite de lineas ");
            Console.WriteLine("4 - Delay ");
            Console.WriteLine("5 - Borrar Hilo");
            Console.WriteLine("6 - Guardar Configuracion");
            Console.WriteLine("7 - Carga tu info ");
            Console.WriteLine("0 - Salir al menú principal ");
            Console.WriteLine("***************************************************");
            int opcion = int.Parse(Console.ReadLine());
            //try
            //{
            //    opcion = int.Parse(Console.ReadLine());
            //}
            //catch
            //{
            //    Console.Clear();
            //    Console.WriteLine("Introduce una opcion del menú");
            //    Menu();
            //}
            if (opcion == 1)
            {
                if(hilito.activo==false && String.IsNullOrEmpty(hilito.quecomprueba) && hilito.delay == 0 && String.IsNullOrEmpty(hilito.archivoconf)) {
                    if ((hilito.tipo == "ServicioFichero") && (hilito.lineas==0))
                    {
                        Console.Clear();
                        Console.WriteLine("Dame las lineas antes");
                        SBMenuF(hiloid);
                    }
                    Console.Clear();
                    Console.WriteLine("Debes especificar todo lo necesario antes");
                    SBMenuF(hiloid);
                }
                c.Turnar(hiloid);
                Console.Clear();
                SBMenuF(hiloid);
                //Console.WriteLine("");

            }

            if (opcion == 2)
            {
                Console.WriteLine("Introduce tu fichero | directorio");
                string fichero = Console.ReadLine();
                hilito.quecomprueba = fichero;
                Console.Clear();
                SBMenuF(hiloid);


            }

            if (opcion == 3)
            {

                string tipo = hilito.DameTipo();
                if (tipo == "ServicioFichero")
                {
                    Console.Clear();
                    Console.WriteLine("No eres un servicio directorio, no puedes");
                    SBMenuF(hiloid);
                }
                Console.WriteLine("Numero limite de lineas");
                int lineas = int.Parse(Console.ReadLine());
                hilito.lineas = lineas;
                Console.Clear();
                SBMenuF(hiloid);


            }

            if (opcion == 4)
            {
                Console.WriteLine("De cuantos segundos es el delay");
                int delay = int.Parse(Console.ReadLine());
                hilito.delay = delay;
                Console.Clear();
                SBMenuF(hiloid);
            }

            if (opcion == 5)
            {
                c.BorrarHilo(hiloid);
                Console.Clear();
                Console.WriteLine("Borraste correctamente tu hilo");
                Menu();
            }


            if (opcion == 6)
            {
                if (hilito.activo == false && String.IsNullOrEmpty(hilito.quecomprueba) && hilito.delay == 0 && String.IsNullOrEmpty(hilito.archivoconf))
                {
                    if ((hilito.tipo == "ServicioFichero") && (hilito.lineas == 0))
                    {
                        Console.Clear();
                        Console.WriteLine("Dame las lineas antes");
                        SBMenuF(hiloid);
                    }
                    Console.Clear();
                    Console.WriteLine("Debes especificar todo lo necesario antes");
                    SBMenuF(hiloid);
                }
                Console.WriteLine("Introduce tu fichero | directorio");
                string ruta = Console.ReadLine();
                if (ruta.Contains(".txt"))
                {
                    hilito.archivoconf = ruta;
                    c.GuardarConf(hilito);
                }
                else
                {
                    ruta = ruta + ".txt";
                    hilito.archivoconf = ruta;
                    c.GuardarConf(hilito);
                }
                Console.Clear();
                Menu();
            }

            if (opcion == 7)
            {
                Console.WriteLine("Dame tu fichero para recuperar tu info");
                string fichero = Console.ReadLine();
                hilito.archivoconf = fichero;
                Console.Clear();
                Console.WriteLine(c.DevolverInfo(hilito, fichero));
                SBMenuF(hiloid);
            }

            if (opcion == 0) {
               Menu();
            }
        }
        static void Menu()
        {

            int op = -1;
            while (op != 0)
            {
                if (c.hilos.Count() == 0)
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("Servicios Asincronos");
                    Console.WriteLine("Introduce la opción que desea realizar");
                    Console.WriteLine("0 - Cerrar programa ");
                    Console.WriteLine("1 - Crear Hilo Fichero ");
                    Console.WriteLine("2 - Crear Hilo Directorio ");
                    Console.WriteLine("***************************************************");
                    try
                    {
                        op = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Introduce una ocion del menú");
                        Menu();
                    }
                    if (op == 1)
                    {
                        c.CrearHiloFichero();
                        Console.Clear();
                        Menu();
                    }
                    if (op == 2)
                    {
                        c.CrearHiloDirectorio();
                        Console.Clear();
                        Menu();
                    }
                    else { Console.WriteLine("Prueba de nuevo, tramposo");Menu(); }
                }
                else
                {
                    c.Mostrar();
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("Servicios Asincronos");
                    Console.WriteLine("Introduce la opción que desea realizar");
                    Console.WriteLine("0 - Cerrar programa ");
                    Console.WriteLine("1 - Crear Hilo Fichero ");
                    Console.WriteLine("2 - Crear Hilo Directorio ");
                    Console.WriteLine("3 - Opciones hilo");
                    //Console.WriteLine("3 - Comprobar Modificacion de directorio "); //cnd detecte que se han pasado, escribe en log y conf y para hilo
                    //Console.WriteLine("4 - Comprobar Lineas de Fichero ");
                    //Console.WriteLine("3 - MenuHilos ");
                    Console.WriteLine("***************************************************");
                    try
                    {
                        op = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Introduce una opcion del menú");
                        Menu();
                    }
                    if (op == 1)
                    {
                        c.CrearHiloFichero();
                        c.CrearHiloFichero();
                        Console.Clear();
                        Menu();
                    }
                    if (op == 2)
                    {
                        c.CrearHiloDirectorio();
                        c.CrearHiloDirectorio();
                        Console.Clear();
                        Menu();
                    }
                    if (op == 3)
                    {
                        Console.WriteLine("Dame el id del hilo que quieres modificar");
                        int hiloid = int.Parse(Console.ReadLine());
                        if (c.BuscarHilo(hiloid)!=null)
                        {
                            Console.Clear();
                            SBMenuF(hiloid);
                        }
                        else
                        {
                            Console.WriteLine("No has introducido bien el id del hilo, prueba de nuevo");
                            Menu();
                        }
                    }
                    else { Environment.Exit(0); }
                }
            }
        }   
    }
}
