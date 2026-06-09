using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cuenta : IValidar //SE ASOCIA CLASE DE INTERFAZ
    {
        private static int UltimoId { get; set; } = 1;

        public int Id { get; set; }
        public bool MFA { get; set; }
        public Persona Titular { get; set; }
        public DateTime? FechaUltCambioPass { get; set; }

        public Cuenta(bool mFA, Persona titular, DateTime fechaUltCambioPass)
        {
            Id = UltimoId++;
            MFA = mFA;
            Titular = titular;
            FechaUltCambioPass = fechaUltCambioPass;
        }

        //METODO DE IVALIDAR APLICADO A CUENTA
        public void Validar()
        {
            if (Titular is null)
            {
                throw new Exception("Debe ingresar una persona como titular");
            }
            if (FechaUltCambioPass > DateTime.Now)
            {
                throw new Exception("La fecha no puede ser posterior al dia de hoy");
            }
        }



    }
}
