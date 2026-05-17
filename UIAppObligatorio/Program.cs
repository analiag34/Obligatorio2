using Dominio;

namespace UIAppObligatorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();

            
                int op = -1;
                while (op != 0)
                {
                    Console.WriteLine("1 - Listar todas las personas con sus respectivos activos");
                    Console.WriteLine("2 - Listar los incidentes de una persona");
                    Console.WriteLine("3 - Alta de cedctivos que carecen de backup ");
                    Console.WriteLine("0 - Salir");

                    op = int.Parse(Console.ReadLine());

                    if (op == 1)
                    {
                        try
                        {
                            foreach (Persona p in sistema.GetPersonas())
                            {
                                Console.WriteLine($"{p.Nombre} - {p.Cedula}");

                                List<Activo> activosPersona = sistema.ObtenerActivosPorPersona(p);

                                if (activosPersona.Count == 0)
                                {
                                    Console.WriteLine("sin activos");
                                }

                                foreach (Activo a in activosPersona)
                                {
                                    Console.WriteLine(a);
                                }


                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error:" + e.Message);
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
                                Console.WriteLine(i);
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
    }
}
