using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ingresar_datos_archivo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream Archivo;
            StreamReader Leer;
            StreamWriter grabar;
            string nomb;
            int dni;
            char opcion;
            string resp;
            resp = "s";
            string cadena;
            string dir;
            string[] vec;
            int busdni;
            int ban;
            ban = 0;

            Console.WriteLine("Ingrese Opcion (1-Ingreso de datos 2-Listar datos 3-Buscar Dni  ):");
            opcion = Console.ReadKey().KeyChar;

            switch (opcion)
            {
                case '1':
                    {
                        while (resp == "s")
                        {
                            Console.WriteLine("ingreso de datos");
                            Console.WriteLine ("ingrese su nombre y apellido: ");
                      
                            nomb = Console.ReadLine();
                            Console.WriteLine("Ingrese su direccion:");
                            dir = Console.ReadLine();
                            Console.WriteLine("ingrese sin puntos ni comas, su dni");
                            if (int.TryParse(Console.ReadLine(), out dni))
                            {
                                Archivo = new FileStream("datos.txt", FileMode.Append);
                                grabar = new StreamWriter(Archivo);
                                grabar.Write(nomb);
                                grabar.Write(";");
                                grabar.Write(dni);
                                grabar.Write(";");
                                grabar.Write(dir);
                                grabar.Write("/n");
                                grabar.Close();
                                Archivo.Close();
                            }
                            else
                            {
                                Console.WriteLine("dato incorrecto");
                            }
                            Console.WriteLine("Ingresar otros datos? s/n: ");
                            resp = Console.ReadLine();
                        }
                        break;
                    }
                case '2':
                    {
                        if (File.Exists("datos.txt"))
                        {
                            Console.WriteLine("\nContenido del Archivo:");
                            Archivo = new FileStream("datos.txt", FileMode.Open);
                            Leer = new StreamReader(Archivo);
                            while (Leer.EndOfStream == false)
                            {
                                cadena = Leer.ReadLine();
                                vec=cadena.Split(';');
                                Console.WriteLine("Nombre y apellido: "+vec[0]);
                                Console.WriteLine("Direccion: "+vec[2]);
                                Console.WriteLine("DNI: " + vec[1]);
                                Console.WriteLine();
                            }
                            Leer.Close();
                            Archivo.Close();
                        }
                        else
                        {
                            Console.WriteLine("\nEl archivo no existe.");
                        }
                        break;
                    }
                case '3':
                    {
                        Console.Write("Ingrese Dni a buscar : ");
                        if (int.TryParse(Console.ReadLine(), out busdni))
                        {
                            Archivo = new FileStream("datos.txt", FileMode.Open);
                            Leer = new StreamReader(Archivo);
                            while (Leer.EndOfStream == false)
                            {
                                cadena = Leer.ReadLine();
                                vec = cadena.Split(';');

                                if (busdni.ToString() == vec[1])
                                {
                                    Console.WriteLine("Nombre y Apellido: " + vec[0]);
                                    Console.WriteLine("Dni: " + vec[1]);
                                    Console.WriteLine("DIreccion: " + vec[2]);
                                    ban = 1;
                                }
                            }
                            if (ban == 0)
                            {
                                Console.WriteLine("//////usuario no registrado///////");
                            }

                        }
                            break;
                    }
                                   }
            Console.ReadKey();
        }
    }
}
