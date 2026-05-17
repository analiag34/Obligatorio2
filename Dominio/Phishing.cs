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

        public override void Validar()

        {
            base.Validar();
            if (string.IsNullOrEmpty(CanalUsado))
            {
                throw new Exception("El canal usado no puede ser vacío");
            }
        }





    }
}
