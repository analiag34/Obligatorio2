using Dominio;

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
                            }

                            foreach (Activo a in activosPersona)
                            {
                                Console.WriteLine(a);
                            }
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






                }

            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message); 
            }



        }
    }
}
