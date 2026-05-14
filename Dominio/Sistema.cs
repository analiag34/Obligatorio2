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




        public List<Incidente> ListarIncidentesPorPersona(string ci)
        {
            if (string.IsNullOrEmpty(ci))
            {
                throw new Exception("La cédula no puede ser vacía");
            }
            bool existe = false;
            foreach (Persona p in _personas)
            {
                if (p.Cedula == ci)
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                throw new Exception("No existe una persona con esa cédula");
            }
            List<Incidente> listaRetorno = new List<Incidente>();
            foreach (Incidente i in _incidentes)
            {
                if (i.ActivoAfectado.Cuenta.Titular.Cedula.Equals(ci))
                {
                    listaRetorno.Add(i);
                }

            }
            if (listaRetorno.Count == 0)
            {
                throw new Exception("La persona no tiene incidentes");
            }
            return listaRetorno;
        }



        public List<Activo> ObtenerActivosPorPersona(Persona p)
        {
            List<Activo> listaRet = new List<Activo>();
            foreach (Activo a in _activos)
            {
                if (a.Cuenta.Titular.Equals(p))
                {
                    listaRet.Add(a);
                }
            }
            return listaRet;
        }

        public Persona ObtenerPersonaPorCedula(String ci)
        {
            foreach (Persona p in _personas)
            {
                if (p.Cedula == ci)
                {
                    return p;
                }

            }
            throw new Exception("No existe una persona con esa cédula");
        }

        



    }
}