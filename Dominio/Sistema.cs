using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sistema
    {

        private List<Persona> _personas = new List<Persona>();
        private List<Incidente> _incidentes = new List<Incidente>();
        private List<Cuenta> _cuentas = new List<Cuenta>();
        private List<Activo> _activos = new List<Activo>();


        public List<Persona> GetPersonas()
        {
            return _personas;
        }

        public List<Incidente> GetIncidentes()
        {
            return _incidentes;
        }

        public List<Cuenta> GetCuentas()
        {
            return _cuentas;
        }

        public List<Activo> GetActivos()
        {
            return _activos;
        }
        //cédula de una persona dada es única,
        //el nombre no puede ser vacío y el email debe contener el símbolo “@”.
        public void AltaPersona(Persona p)
        {
            p.ValidarPersona();
            if (_personas.Contains(p))
            {
                throw new Exception("ya existe");
            }
            _personas.Add(p);
        }

        public void AltaCuenta(Cuenta c)
        {
            _cuentas.Add(c);
        }

        public void AltaIncidente(Incidente i)
        {
            _incidentes.Add(i);
        }

        public void AltaActivo(Activo a)
        {
            _activos.Add(a);
        }







    }
}
