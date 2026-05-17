using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
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

            Precargar();
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
            p.Validar();
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
            i.Validar();
            _incidentes.Add(i);
        }

        public void AltaActivo(Activo a)
        {
            if(a is null)
            {
                throw new Exception("Debe ingresar un incidente");
            }
            a.Validar();
            _activos.Add(a);
        }

        public List<Activo> GetActivosSinBackup()
        {
            List<Activo> _activosSinBackUp = new List<Activo>();

            foreach (Activo a in _activos)
            {
                if (!a.Backup)
                {
                    _activosSinBackUp.Add(a);
                }
            }
            return _activosSinBackUp;

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
            throw new Exception("No existe una persona con esa cedula");


        }

        public List<Incidente> ListarIncidentesPorPersona(string ci)
        {
            if (string.IsNullOrEmpty(ci))
            {
                throw new Exception("La cedula no puede estar vacia");
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
                throw new Exception("No existe una persona con esa cedula");
            }

            List<Incidente> listaRetorno = new List<Incidente>();
            foreach (Incidente i in _incidentes)
            {
                if (i.ActivoAfectado.Cuenta.Titular.Cedula == ci)
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



        //Precarga de datos hecho con Gemini

        private void Precargar()

        {

            //ALTA PERSONA

            Persona p1 = new Persona("1234", "Juan", "51232100", "099888777", "juan123@gmail.com");
            AltaPersona(p1);

            Persona p2 = new Persona("Pass.123", "María García", "45671234", "26001234", "mgarcia@gmail.com");
            AltaPersona(p2);

            Persona p3 = new Persona("Carlos!99", "Carlos Rodríguez", "32145678", "27105566", "crodriguez@outlook.com");
            AltaPersona(p3);

            Persona p4 = new Persona("Ana_2024", "Ana López", "19876543", "29009988", "alopez@vera.com.uy");
            AltaPersona(p4);

            Persona p5 = new Persona("SosaSecure", "Roberto Sosa", "51234321", "24018877", "rsosa@empresa.com");
            AltaPersona(p5);

            Persona p6 = new Persona("Elena*789", "Elena Martínez", "28765432", "25004433", "emartinez@gmail.com");
            AltaPersona(p6);

            Persona p7 = new Persona("DiegoP88", "Diego Pereira", "43215678", "26107788", "dpereira@hotmail.com");
            AltaPersona(p7);

            Persona p8 = new Persona("Sofia#55", "Sofía Silva", "39871234", "27003322", "ssilva@yahoo.com");
            AltaPersona(p8);

            Persona p9 = new Persona("Javi_Ort", "Javier González", "12345678", "29106677", "jgonzalez@ort.edu.uy");
            AltaPersona(p9);

            Persona p10 = new Persona("Vale.Diaz", "Valentina Díaz", "54321876", "24052211", "vdiaz@empresa.com.uy");
            AltaPersona(p10);

            Persona p11 = new Persona("Andres_Pwd", "Andrés Morales", "21234567", "25021100", "amorales@gmail.com");
            AltaPersona(p11);

            //ALTAS DE CUENTA

            Cuenta c1 = new Cuenta(true, p1, new DateTime(2023, 10, 15));
            AltaCuenta(c1);

            Cuenta c2 = new Cuenta(false, p2, new DateTime(2024, 01, 20));
            AltaCuenta(c2);

            Cuenta c3 = new Cuenta(true, p3, new DateTime(2023, 11, 05));
            AltaCuenta(c3);

            Cuenta c4 = new Cuenta(true, p4, new DateTime(2024, 02, 10));
            AltaCuenta(c4);

            Cuenta c5 = new Cuenta(false, p5, new DateTime(2023, 09, 30));
            AltaCuenta(c5);

            Cuenta c6 = new Cuenta(true, p6, new DateTime(2023, 12, 12));
            AltaCuenta(c6);

            Cuenta c7 = new Cuenta(false, p7, new DateTime(2024, 03, 01));
            AltaCuenta(c7);

            Cuenta c8 = new Cuenta(true, p8, new DateTime(2023, 08, 25));
            AltaCuenta(c8);

            Cuenta c9 = new Cuenta(true, p9, new DateTime(2024, 01, 05));
            AltaCuenta(c9);

            Cuenta c10 = new Cuenta(false, p10, new DateTime(2023, 07, 14));
            AltaCuenta(c10);

            Cuenta c11 = new Cuenta(true, p11, new DateTime(2024, 02, 28));
            AltaCuenta(c11);

            Cuenta c12 = new Cuenta(true, p1, new DateTime(2024, 03, 15));
            AltaCuenta(c12);

            //ALTAS DE ACTIVO

            Activo a1 = new Activo(c1, TipoActivo.PC, 4, "Laptop Desarrollo", true);
            AltaActivo(a1);

            Activo a2 = new Activo(c2, TipoActivo.SERVER, 5, "Servidor Web 01", true);
            AltaActivo(a2);

            Activo a3 = new Activo(c3, TipoActivo.MOVIL, 3,"iPhone Gerencia", false);
            AltaActivo(a3);

            Activo a4 = new Activo(c4, TipoActivo.PC, 2, "PC Recepción", true);
            AltaActivo(a4);

            Activo a5 = new Activo(c5, TipoActivo.SERVER, 5, "Servidor Base Datos", true);
            AltaActivo(a5);

            Activo a6 = new Activo(c6, TipoActivo.MOVIL, 1, "Tablet Depósito", false);
            AltaActivo(a6);

            Activo a7 = new Activo(c7, TipoActivo.PC, 4, "Workstation Diseño", true);
            AltaActivo(a7);

            Activo a8 = new Activo(c8, TipoActivo.SERVER, 5, "Servidor Correo", true);
            AltaActivo(a8);

            Activo a9 = new Activo(c9, TipoActivo.MOVIL, 2, "Android Ventas", false);
            AltaActivo(a9);

            Activo a10 = new Activo(c10, TipoActivo.PC, 3,  "PC RRHH", true);
            AltaActivo(a10);

            Activo a11 = new Activo(c11, TipoActivo.SERVER, 5,  "Servidor Backup", false);
            AltaActivo(a11);

            Activo a12 = new Activo(c12, TipoActivo.PC, 3,  "Laptop Soporte", true);
            AltaActivo(a12);

            Activo a13 = new Activo(c1, TipoActivo.MOVIL, 4,  "iPad Directivo", false);
            AltaActivo(a13);

            Activo a14 = new Activo(c2, TipoActivo.PC, 1,  "PC Pasante", true);
            AltaActivo(a14);

            Activo a15 = new Activo(c3, TipoActivo.SERVER, 5, "Servidor VPN", true);
            AltaActivo(a15);

            //ALTA INCIDENTE


            //---PHISHING ---


            Incidente i1 = new Phishing(Estado.ABIERTO, "Correo sospechoso", 3, a1, new DateTime(2026, 04, 01), 3, "Email", false, false);
            AltaIncidente(i1);

            Incidente i2 = new Phishing(Estado.EN_ANALISIS, "SMS con link bancario", 4, a3, new DateTime(2026, 04, 02), 4, "SMS", true, false);
            AltaIncidente(i2);

            Incidente i3 = new Phishing(Estado.CERRADO, "Mensaje de WhatsApp directivo", 2, a4, new DateTime(2026, 04, 03), 2, "WhatsApp", false, false);
            AltaIncidente(i3);

            Incidente i4 = new Phishing(Estado.CONTENIDO, "Falso soporte técnico", 3, a7, new DateTime(2026, 04, 05), 3, "Llamada", true, true);
            AltaIncidente(i4);

            Incidente i5 = new Phishing(Estado.ABIERTO, "Promoción redes sociales", 1, a9, new DateTime(2026, 04, 07), 1, "Redes Sociales", false, false);
            AltaIncidente(i5);

            Incidente i6 = new Phishing(Estado.EN_ANALISIS, "Factura pendiente adjunta", 4, a10, new DateTime(2026, 04, 10), 4, "Email", true, false);
            AltaIncidente(i6);

            Incidente i7 = new Phishing(Estado.CERRADO, "Actualización de seguridad", 2, a12, new DateTime(2026, 04, 12), 2, "Email", false, false);
            AltaIncidente(i7);

            Incidente i8 = new Phishing(Estado.ABIERTO, "Sorteo institucional", 1, a13, new DateTime(2026, 04, 15), 1, "Email", false, false);
            AltaIncidente(i8);

            Incidente i9 = new Phishing(Estado.CONTENIDO, "Encuesta de clima laboral", 3, a14, new DateTime(2026, 04, 18), 3, "Email", true, false);
            AltaIncidente(i9);

            Incidente i10 = new Phishing(Estado.EN_ANALISIS, "Acceso VPN bloqueado", 5, a15, new DateTime(2026, 04, 20), 5, "Email", true, true);
            AltaIncidente(i10);

            Incidente i11 = new Phishing(Estado.CERRADO, "Cupón de descuento", 1, a1, new DateTime(2026, 04, 22), 1, "Redes Sociales", false, false);
            AltaIncidente(i11);

            Incidente i12 = new Phishing(Estado.ABIERTO, "Alerta de paquete", 2, a3, new DateTime(2026, 04, 25), 2, "SMS", false, false);
            AltaIncidente(i12);

            Incidente i13 = new Phishing(Estado.EN_ANALISIS, "Cambio de contraseña urgente", 4, a4, new DateTime(2026, 04, 28), 4, "Email", true, false);
            AltaIncidente(i13);

            Incidente i14 = new Phishing(Estado.CERRADO, "Invitación a evento", 2, a7, new DateTime(2026, 04, 30), 2, "WhatsApp", false, false);
            AltaIncidente(i14);

            Incidente i15 = new Phishing(Estado.CONTENIDO, "Aviso de seguridad Gmail", 3, a9, new DateTime(2026, 05, 01), 3, "Email", true, false);
            AltaIncidente(i15);


            // --- RANSOMWARE ---

            Incidente i16 = new Ransomware(Estado.ABIERTO, "Ataque servidor web principal", 5, a2, new DateTime(2026, 05, 02), 5, true, true);
            AltaIncidente(i16);

            Incidente i17 = new Ransomware(Estado.EN_ANALISIS, "Bloqueo base de datos clientes", 5, a5, new DateTime(2026, 05, 03), 5, true, false);
            AltaIncidente(i17);

            Incidente i18 = new Ransomware(Estado.CONTENIDO, "Encriptación servidor correo", 4, a8, new DateTime(2026, 05, 04), 4, true, true);
            AltaIncidente(i18);

            Incidente i19 = new Ransomware(Estado.ABIERTO, "Ataque a repositorio backups", 5, a11, new DateTime(2026, 05, 05), 5, true, false);
            AltaIncidente(i19);

            Incidente i20 = new Ransomware(Estado.CERRADO, "Secuestro de archivos VPN", 4, a15, new DateTime(2026, 05, 06), 4, false, false);
            AltaIncidente(i20);

            Incidente i21 = new Ransomware(Estado.CERRADO, "Intento de intrusión fallido", 5, a2, new DateTime(2026, 05, 07), 5, false, false);
            AltaIncidente(i21);

            Incidente i22 = new Ransomware(Estado.ABIERTO, "Variante WannaCry detectada", 5, a5, new DateTime(2026, 05, 08), 5, true, true);
            AltaIncidente(i22);

            Incidente i23 = new Ransomware(Estado.EN_ANALISIS, "Cifrado de logs de auditoría", 4, a8, new DateTime(2026, 05, 09), 4, true, false);
            AltaIncidente(i23);

            Incidente i24 = new Ransomware(Estado.CONTENIDO, "Petición rescate en cripto", 5, a11, new DateTime(2026, 05, 10), 5, true, true);
            AltaIncidente(i24);

            Incidente i25 = new Ransomware(Estado.ABIERTO, "Cifrado parcial archivos config", 3, a15, new DateTime(2026, 05, 11), 3, true, false);
            AltaIncidente(i25);

            Incidente i26 = new Ransomware(Estado.EN_ANALISIS, "Fuga de datos sensible", 5, a2, new DateTime(2026, 05, 12), 5, false, true);
            AltaIncidente(i26);

            Incidente i27 = new Ransomware(Estado.CERRADO, "Ransomware en entorno testing", 3, a5, new DateTime(2026, 05, 13), 3, true, false);
            AltaIncidente(i27);

            Incidente i28 = new Ransomware(Estado.ABIERTO, "Ataque masivo fin de semana", 4, a8, new DateTime(2026, 05, 14), 4, true, true);
            AltaIncidente(i28);

            Incidente i29 = new Ransomware(Estado.CERRADO, "Eliminación de payload", 2, a11, new DateTime(2026, 05, 15), 2, false, false);
            AltaIncidente(i29);

            Incidente i30 = new Ransomware(Estado.CONTENIDO, "Secuestro de certificados SSL", 3, a15, new DateTime(2026, 05, 16), 3, true, false);
            AltaIncidente(i30);




        }






    }
}
