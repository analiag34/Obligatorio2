using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Persona
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


        public void ValidarPersona()
        {
            if (string.IsNullOrEmpty(Nombre)){
                throw new Exception("Nombre vacio");
            }
            if (!Email.Contains("@")){
                throw new Exception("mail invalido");
            }
             
        }

        public override bool Equals(object? obj)
        {
            return obj is Persona persona &&
                   Cedula == persona.Cedula;
        }
    }
}
