using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cuenta
    {
        private static int UltimoId { get; set; } = 1;

        public int Id { get; set; }
        public bool MFA { get; set; }
        public Persona Titular { get; set; }
        public DateTime FechaUltCambioPass { get; set; }

        public Cuenta(bool mFA, Persona titular, DateTime fechaUltCambioPass)
        {
            Id = UltimoId++;
            MFA = mFA;
            Titular = titular;
            FechaUltCambioPass = fechaUltCambioPass;
        }



    }
}
