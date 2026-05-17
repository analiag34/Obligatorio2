using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Ransomware : Incidente
    {
        public bool DatosEncriptados { get; set; }
        public bool Exfiltracion { get; set; }


        public Ransomware(Estado estado, string descripcion, int probabilidad, Activo activoAfectado, DateTime fechaReportado, int impacto, bool datosEncriptados, bool exfiltracion) : base(estado, descripcion, probabilidad, activoAfectado, fechaReportado, impacto)
        {
            DatosEncriptados = datosEncriptados;
            Exfiltracion = exfiltracion;
        }

        public override string ToString()
        {
             return $"Incidente Ransomware: \n- Activo Afectado: {ActivoAfectado}\n - Estado: {Estado}\n- Descripcion: {Descripcion}\n- Fecha de reporte: {FechaReportado}\n- Datos Encriptados: {DatosEncriptados}\n- Exfiltracion: {Exfiltracion}";
        }

         public override void Validar()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripción no puede ser vacía");
            }
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
    }
}
