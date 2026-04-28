namespace Dominio
{
    public class Activo
    {

        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public Cuenta Cuenta { get; set; }
        public TipoActivo Tipo { get; set; }
        public int Criticidad { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Backup { get; set; }

        public Activo(Cuenta cuenta, TipoActivo tipo, int criticidad, string codigo, string nombre, bool backup)
        {
            Id = UltimoId++;
            Cuenta = cuenta;
            Tipo = tipo;
            Criticidad = criticidad;
            Codigo = codigo;
            Nombre = nombre;
            Backup = backup;
        }



    }
}
