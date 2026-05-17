<<<<<<< HEAD
﻿using System;
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
=======
﻿using Dominio;

namespace UIAppObligatorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema s = new Sistema();

            try
            {
                int op = -1;
                while (op != 0)
                {
                    Console.WriteLine("1 - Listar todas las personas con sus respectivos activos");
                    Console.WriteLine("2 - Listar los incidentes de una persona");
                    Console.WriteLine("3 - Alta de persona");
                    Console.WriteLine("4 - Listar activos que carecen de backup ");
                    Console.WriteLine("0 - Salir");

                    op = int.Parse(Console.ReadLine());

                    if (op == 1)
                    {
                        foreach (Persona p in s.GetPersonas())
                        {
                            Console.WriteLine($"{p.Nombre} - {p.Cedula}");

                            List<Activo> activosPersona = s.ObtenerActivosPorPersona(p);

                            if(activosPersona.Count == 0)
                            {
                                Console.WriteLine("sin activos");
>>>>>>> 80bf87d29c89ac8e929b24dcaab86d01c1ea3e54
                            }

                            foreach (Activo a in activosPersona)
                            {
                                Console.WriteLine(a);
                            }
<<<<<<< HEAD


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

=======
                        }
                    }
                    if (op == 2)
                    {

                        //TODO obtener persona por ci asi me llega el obj completo y puedo mostrar el nombre en consola
                        Console.WriteLine("Ingrese la cedula de la persona");
                        string ciPersona = Console.ReadLine();
                        List<Incidente> incidentesPersona = s.ListarIncidentesPorPersona(ciPersona);
                        Persona persona = s.ObtenerPersonaPorCedula(ciPersona);
                        Console.WriteLine($"Incidentes de {persona.Nombre}:");
                        foreach (Incidente i in incidentesPersona)
                        {
                            Console.WriteLine(i);
                        }
                    }
                    if (op == 3)
                    {

                    }
                    if (op == 4)
                    {

                    }

>>>>>>> 80bf87d29c89ac8e929b24dcaab86d01c1ea3e54





                }
<<<<<<< HEAD
            }


            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }
        }
    }
}
=======

            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }



        }
    }
}
>>>>>>> 80bf87d29c89ac8e929b24dcaab86d01c1ea3e54
