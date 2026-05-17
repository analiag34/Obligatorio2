using System;
using System.Collections.Generic;
using System.Text;

<<<<<<< HEAD

namespace Dominio
{
    public class Persona : IValidar
=======
namespace Dominio
{
    public class Persona
>>>>>>> 80bf87d29c89ac8e929b24dcaab86d01c1ea3e54
    {


        private static int UltimoId { get; set; } = 1;
        public int id { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Persona(string password, string nombre, string cedula, string telefono, string email)
        {
            id = UltimoId++;
            Password = password;
            Nombre = nombre;
            Cedula = cedula;
            Telefono = telefono;
            Email = email;
        }

<<<<<<< HEAD
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre vacio");
            }
            if (string.IsNullOrEmpty(Email) || !Email.Contains("@"))
            {
                throw new Exception("mail vacio o invalido");
            }

        }




=======

        public void ValidarPersona()
        {
            if (string.IsNullOrEmpty(Nombre)){
                throw new Exception("Nombre vacio");
            }
            if (!Email.Contains("@")){
                throw new Exception("mail invalido");
            }
             
        }

>>>>>>> 80bf87d29c89ac8e929b24dcaab86d01c1ea3e54
        public override bool Equals(object? obj)
        {
            return obj is Persona persona &&
                   Cedula == persona.Cedula;
        }
<<<<<<< HEAD
=======

       
>>>>>>> 80bf87d29c89ac8e929b24dcaab86d01c1ea3e54
    }
}
