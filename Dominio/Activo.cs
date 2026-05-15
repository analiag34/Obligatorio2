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

        public Activo(Cuenta cuenta, TipoActivo tipo, int criticidad, string nombre, bool backup)
        {
            Id = UltimoId++;
            Cuenta = cuenta;
            Tipo = tipo;
            Criticidad = criticidad;
            Codigo = tipo.ToString().ToUpper() + Id.ToString("D4");
            Nombre = nombre;
            Backup = backup;
        }


        public override string ToString()
        {
            return $"{Nombre}, {Tipo}, {Codigo} ";
        }

        public void ValidarActivo()
        {
            if (Cuenta is null)
            {
                throw new Exception("La cuenta no puede ser vacía");
            }
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre no puede ser vacío");
            }
            if (Criticidad < 1 || Criticidad > 5)
            {
                throw new Exception("La criticidad debe ser un valor entre 1 y 5");
            }
        }



    }
}
