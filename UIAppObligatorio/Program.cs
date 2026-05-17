using System;
using System.Collections.Generic;
using Dominio;

namespace UIAppObligatorio
{
    class Program
    {
        private static Sistema sistema;

        static void Main(string[] args)
        {
            try
            {
                sistema = new Sistema();

                int op = -1;

                while (op != 0)
                {
                    Console.Clear();
                    Console.WriteLine("1 - Mostrar personas y su activo");
                    Console.WriteLine("2 - Mostrar incidente por CI");
                    Console.WriteLine("3 - Alta persona");
                    Console.WriteLine("4 - Mostrar activos sin backup");
                    Console.WriteLine("0 - Salir");
                    Console.WriteLine("5 - Mostrar personas");





                    op = int.Parse(Console.ReadLine());
                    if (op == 5)
                    {
                        foreach (Persona p in sistema.GetPersonas())
                        {
                            Console.WriteLine(p.Nombre);
                        }
                    }

                    if (op == 0)
                    {
                        break;

                    }


                    if (op == 1)
                    {

                        foreach (Persona p in sistema.GetPersonas())
                        {

                            List<Activo> activosPersona = sistema.ObtenerActivosPorPersona(p);

                            if (activosPersona.Count == 0)
                            {
                                Console.WriteLine("Sin activos");
                            }

                            foreach (Activo a in activosPersona)
                            {
                                Console.WriteLine(a);
                            }


                        }

                    }
                    else if (op == 2)
                    {
                        try
                        {

                            Console.WriteLine("Ingrese cedula de la persona");
                            string ciPersona = Console.ReadLine();

                            List<Incidente> incidentesPersona = sistema.ListarIncidentesPorPersona(ciPersona);
                            Persona persona = sistema.ObtenerPersonaPorCedula(ciPersona);

                            Console.WriteLine($"Incidentes de {persona.Nombre}:");
                            foreach (Incidente i in incidentesPersona)
                            {
                                Console.WriteLine(i.Descripcion);
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }
                    }
                    else if (op == 3)
                    {
                        try
                        {
                            Console.WriteLine("Ingrese password");
                            string pass = Console.ReadLine();

                            Console.WriteLine("Ingrese el nombre");
                            string nom = Console.ReadLine();

                            Console.WriteLine("Ingrese cedula");
                            string cedula = Console.ReadLine();

                            Console.WriteLine("Ingrese numero de telefono");
                            string tel = Console.ReadLine();

                            Console.WriteLine("Ingrese email");
                            string mail = Console.ReadLine();

                            Persona p = new Persona(pass, nom, cedula, tel, mail);

                            sistema.AltaPersona(p);

                            Console.WriteLine("Alta exitosa");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: " + e.Message);
                        }
                    }
                    else if (op == 4)
                    {
                        List<Activo> activosSinBackUp = sistema.GetActivosSinBackup();

                        foreach (Activo act in activosSinBackUp)
                        {
                            Console.WriteLine(act.Nombre);
                        }
                    }

                    Console.ReadKey();






                }
            }


            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }
        }
    }
}