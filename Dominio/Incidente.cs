using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Incidente
    {

        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; } = UltimoId++;
        public Estado Estado { get; set; }
        public string Descripcion { get; set; }
        public int Probabilidad { get; set; }
        public Activo ActivoAfectado { get; set; }
        public DateTime FechaReportado { get; set; }
        public int Impacto { get; set; }

        protected Incidente(Estado estado, string descripcion, int probabilidad, Activo activoAfectado, DateTime fechaReportado, int impacto)
        {
            Id = UltimoId++;
            Estado = estado;
            Descripcion = descripcion;
            Probabilidad = probabilidad;
            ActivoAfectado = activoAfectado;
            FechaReportado = fechaReportado;
            Impacto = impacto;
        }
    }
}
