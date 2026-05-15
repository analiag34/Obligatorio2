using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Dominio
{
    public class Sistema
    {

        private List<Persona> _personas = new List<Persona>();
        private List<Incidente> _incidentes = new List<Incidente>();
        private List<Cuenta> _cuentas = new List<Cuenta>();
        private List<Activo> _activos = new List<Activo>();


        public Sistema()
        {
            PrecargarDatos();
        }

        public void PrecargarDatos()
        {
            Persona p1 = new Persona("ame123", "america", "61566899", "098768765", "ame223@gmail.com");
            AltaPersona(p1);
            Persona p2 = new Persona("jose22", "jose perez", "8920009", "098768763", "jose@gmail.com");
            AltaPersona(p2);
            Cuenta cuenta1 = new Cuenta(true, p1, new DateTime(2026, 05, 10));
            AltaCuenta(cuenta1);
            Activo activo1 = new Activo(cuenta1, TipoActivo.PC, 4,"dell", false);
            AltaActivo(activo1);
            Activo activo2 = new Activo(cuenta1, TipoActivo.MOVIL, 4, "appple", false);
            AltaActivo(activo2);
            Incidente incidente1 = new Phishing(Estado.EN_ANALISIS, "hubo un hacker", 4, activo1, new DateTime(2025, 12, 30), 3, "canal usado", true, true);
            AltaIncidente(incidente1);
             Incidente incidente2 = new Ransomware(Estado.CERRADO, "hubo un hacker", 4, activo2, new DateTime(2025, 12, 30), 4, false, true);
            AltaIncidente(incidente2);


        }

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
            if(p is null)
            {
                throw new Exception("Debe ingresar una persona");
            }
            p.ValidarPersona();
            if (_personas.Contains(p))
            {
                throw new Exception("ya existe");
            }
            _personas.Add(p);
        }

        public void AltaCuenta(Cuenta c)
        {
            if(c is null)
            {
                   throw new Exception("Debe ingresar una cuenta");
            }
            c.Validar();
            _cuentas.Add(c);
        }

        public void AltaIncidente(Incidente i)
        {
            if(i is null)
            {
                throw new Exception("Debe ingresar un incidente");
            }
            i.ValidarIncidente();
            _incidentes.Add(i);
        }

        public void AltaActivo(Activo a)
        {
             if(a is null)
            {
                throw new Exception("Debe ingresar un activo");
            }
            a.ValidarActivo();
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


  ///TODO IValidable


    }
}