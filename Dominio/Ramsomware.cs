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

        public override void Validar()
        {
            base.Validar();
        }
    }
}
