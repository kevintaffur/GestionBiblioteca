namespace GestionBiblioteca.Entities
{
    internal class Usuario
    {
        private static int contador = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public Usuario(string nombre, string correo, string telefono)
        {
            Id = contador;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            contador++;
        }

        public override string ToString()
        {
            return $"------------------------------------------------" + "\n" +
                   $"Id: {Id}" + "\n" +
                   $"Nombre: {Nombre}" + "\n" +
                   $"Correo: {Correo}" + "\n" +
                   $"Telefono: {Telefono}" + "\n" +
                   $"------------------------------------------------";
        }
    }
}
