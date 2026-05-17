using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Phishing : Incidente
    {


        public string CanalUsado { get; set; }
        public bool EntregoCredenciales { get; set; }
        public bool TransferenciaDatos { get; set; }

        public Phishing(Estado estado, string descripcion, int probabilidad, Activo activoAfectado, DateTime fechaReportado, int impacto, string canalUsado, bool entregoCredenciales, bool transferenciaDatos) : base(estado, descripcion, probabilidad, activoAfectado, fechaReportado, impacto)
        {
            CanalUsado = canalUsado;
            EntregoCredenciales = entregoCredenciales;
            TransferenciaDatos = transferenciaDatos;
        }

<<<<<<< HEAD
        public override void Validar()

        {
            base.Validar();
=======
        public override string ToString()
        {
             return $"Incidente Phishing: \n- Activo Afectado: {ActivoAfectado}\n - Estado: {Estado}\n- Descripcion: {Descripcion}\n- Fecha de reporte: {FechaReportado}\n- Canal Usado: {CanalUsado}\n- Transferencia de Datos: {TransferenciaDatos}\n- Entregó Credenciales: {EntregoCredenciales}";
        }

        public override void ValidarIncidente()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripción no puede ser vacía");
            }
>>>>>>> 80bf87d29c89ac8e929b24dcaab86d01c1ea3e54
            if (string.IsNullOrEmpty(CanalUsado))
            {
                throw new Exception("El canal usado no puede ser vacío");
            }
<<<<<<< HEAD
        }

=======
            if(Probabilidad < 1 || Probabilidad > 5)
            {
                throw new Exception("La probabilidad debe ser un valor entre 1 y 5");
            }
             if(Impacto < 1 || Impacto > 5)
            {
                throw new Exception("El impacto debe ser un valor entre 1 y 5");
            }
            if(ActivoAfectado is null)
            {
                 throw new Exception("Debe ingresar un activo adectado");
            }

        }
>>>>>>> 80bf87d29c89ac8e929b24dcaab86d01c1ea3e54




    }
}
