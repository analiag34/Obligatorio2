using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Incidente : IValidar
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

        public abstract override string ToString();
       
       public abstract void Validar();

           
       /* public virtual void Validar()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripción no puede ser vacía");
            }

            if (Probabilidad < 1 || Probabilidad > 5)
            {
                throw new Exception("La probabilidad debe ser entre 1 y 5");
            }

            if (Impacto < 1 || Impacto > 5)
            {
                throw new Exception("El impacto debe ser entre 1 y 5");
            }

            if (ActivoAfectado == null)
            {
                throw new Exception("Debe existir un activo afectado");
            }
        }*/

    }
}
