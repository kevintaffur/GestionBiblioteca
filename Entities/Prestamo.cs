namespace GestionBiblioteca.Entities
{
    internal class Prestamo
    {
        private static int contador = 1;
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaDevolucion { get; set; }
        // activo o finalizado
        public string Estado { get; set; }

        public Prestamo(Usuario usuario, Libro libro, DateTime fechaPrestamo)
        {
            Id = contador;
            Usuario = usuario;
            Libro = libro;
            FechaPrestamo = fechaPrestamo;
            FechaDevolucion = fechaPrestamo.AddDays(30);
            Estado = "activo";
            contador++;
        }

        public override string ToString()
        {
            return $"------------------------------------------------" + "\n" +
                   $"Id: {Id}" + "\n" +
                   $"Usuario: {Usuario.Nombre}" + "\n" +
                   $"Libro: {Libro.Titulo}" + "\n" +
                   $"Fecha de prestamo: {FechaPrestamo}" + "\n" +
                   $"Fecha de devolución: {FechaDevolucion}" + "\n" +
                   $"Estado: {Estado}" + "\n" +
                   $"------------------------------------------------";
        }
    }
}
