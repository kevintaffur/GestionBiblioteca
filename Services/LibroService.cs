using GestionBiblioteca.Entities;

namespace GestionBiblioteca.Services
{
    internal class LibroService
    {
        private List<Libro> libros;

        public LibroService()
        {
            libros = new List<Libro>();
        }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public Libro ObtenerLibroPorIsbm(string isbn)
        {
            return libros.FirstOrDefault(libro => libro.ISBN == isbn);
        }

        public Libro ObtenerLibroPorId(int id)
        {
            return libros.FirstOrDefault(libro => libro.Id == id);
        }

        public void EliminarLibro(int id)
        {
            Libro libroExistente = ObtenerLibroPorId(id);
            if (libroExistente == null)
            {
                throw new Exception("El libro no existe");
            }
            libros.Remove(libroExistente);
        }

        public List<Libro> ObtenerLibros()
        {
            return libros;
        }

        public void ModificarLibro(int id, Libro libro)
        {
            Libro libroExistente = ObtenerLibroPorId(id);
            if (libroExistente == null)
            {
                throw new Exception("El libro no existe");
            }
            libroExistente.Titulo = libro.Titulo;
            libroExistente.Autor = libro.Autor;
            libroExistente.ISBN = libro.ISBN;
            libroExistente.PublicacionYear = libro.PublicacionYear;
            libroExistente.Disponibe = libro.Disponibe;
        }
    }
}
