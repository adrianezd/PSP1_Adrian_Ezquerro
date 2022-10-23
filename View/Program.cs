using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business;
using static System.Net.Mime.MediaTypeNames;

namespace View
{
    public class Program
    {
        static string directory = Directory.GetCurrentDirectory();

        static void Main(string[] args)
        {
            Menu();
        }

        static void SBMenuF(int hiloid)
        {
            Hilo hilito = ControladorHilos.DevuelveHilo(hiloid);

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

            if (opcion == 1)
            {
                if(String.IsNullOrEmpty(hilito.quecomprueba) && hilito.delay == 0) {
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
                ControladorHilos.Turnar(hiloid);
                Console.Clear();
                SBMenuF(hiloid);
                //Console.WriteLine("");

            }

            if (opcion == 2)
            {
                Console.WriteLine("Introduce tu fichero | directorio. (Si es ruta default, pon def)");
                string fichero = Console.ReadLine();
                if (fichero == "def")
                {
                    string tipo = hilito.DameTipo();
                    if (tipo == "ServicioDirectorio")
                    {
                        hilito.quecomprueba = Directory.GetCurrentDirectory();
                        Console.Clear();
                        SBMenuF(hiloid);
                    }
                    else
                    {
                        hilito.quecomprueba = Directory.GetCurrentDirectory() + @"\leer.txt";
                        Console.Clear();
                        SBMenuF(hiloid);
                    }

                }
                else
                {
                    hilito.quecomprueba = fichero;
                }

                Console.Clear();
                SBMenuF(hiloid);


            }

            if (opcion == 3)
            {

                string tipo = hilito.DameTipo();
                if (tipo == "ServicioDirectorio")
                {
                    Console.Clear();
                    Console.WriteLine("No eres un servicio fichero, no puedes");
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
                ControladorHilos.BorrarHilo(hiloid);
                Console.Clear();
                Console.WriteLine("Borraste correctamente tu hilo");
                Menu();
            }


            if (opcion == 6)
            {
                if (String.IsNullOrEmpty(hilito.quecomprueba) || hilito.delay == 0)
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
                    ControladorHilos.GuardarConf(hilito);
                }
                else
                {
                    ruta = ruta + ".txt";
                    hilito.archivoconf = ruta;
                    ControladorHilos.GuardarConf(hilito);
                }
                Console.Clear();
                Menu();
            }

            if (opcion == 7)
            {
                Console.WriteLine("Dame tu fichero para recuperar tu info");
                string fichero = Console.ReadLine();
                Console.WriteLine("el fichero es ->" + fichero);
                //hilito.archivoconf = fichero;
                //Console.Clear();
                string infoFile = ControladorHilos.DevolverInfo(hilito, fichero);
                Console.WriteLine("EL INFO FILE ES -> " + infoFile);

                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                string[] items = infoFile.TrimEnd(';').Split(';');
                foreach (string item in items)
                {
                    string[] keyValue = item.Split('-');
                    dictionary.Add(keyValue[0], keyValue[1]);
                }

                Console.WriteLine(dictionary);
                if (hilito.DameTipo() != dictionary["tipo"])
                {
                    Console.WriteLine("ese fichero no deberia ser para ti... elige otro");
                }
                else
                {
                    hilito.delay = int.Parse(dictionary["delay"]);
                    hilito.archivoconf = dictionary["archivoconf"];
                    hilito.activo = bool.Parse(dictionary["activo"]);
                    hilito.quecomprueba = dictionary["confanalizar"];
                    hilito.lineas = int.Parse(dictionary["lineas"]);
                    SBMenuF(hiloid);
                }
                }


            if (opcion == 0) {
                Console.Clear();
                Menu();
            }
        }
        static void Menu()
        {

            int op = -1;
            while (op != 0)
            {
                if (ControladorHilos.hilos.Count() == 0)
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
                        Console.WriteLine("Introduce una opcion del menú");
                        Menu();
                    }
                    if (op == 1)
                    {
                        ControladorHilos.CrearHiloFichero();
                        Console.Clear();
                        Menu();
                    }
                    if (op == 2)
                    {
                        ControladorHilos.CrearHiloDirectorio();
                        Console.Clear();
                        Menu();
                    }
                    else { Console.WriteLine("Prueba de nuevo, tramposo");Menu(); }
                }
                else
                {
                    ControladorHilos.Mostrar();
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
                        ControladorHilos.CrearHiloFichero();
                        Console.Clear();
                        Menu();
                    }
                    if (op == 2)
                    {
                        ControladorHilos.CrearHiloDirectorio();
                        Console.Clear();
                        Menu();
                    }
                    if (op == 3)
                    {
                        Console.WriteLine("Dame el id del hilo que quieres modificar");
                        int hiloid = int.Parse(Console.ReadLine());
                        if (ControladorHilos.BuscarHilo(hiloid)!=null)
                        {
                            Console.Clear();
                            SBMenuF(hiloid);
                        }
                        else
                        {
                            Console.Clear();
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
