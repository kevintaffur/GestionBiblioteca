
using GestionBiblioteca.Entities;

namespace GestionBiblioteca.Services
{
    internal class PrestamoService
    {
        private List<Prestamo> prestamos;

        public PrestamoService()
        {
            prestamos = new List<Prestamo>();
        }

        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
        }

        public Prestamo ObtenerPrestamoPorId(int id)
        {
            return prestamos.FirstOrDefault(prestamo => prestamo.Id == id);
        }

        public void EliminarPrestamo(int id)
        {
            Prestamo prestamoExistente = ObtenerPrestamoPorId(id);
            if (prestamoExistente == null)
            {
                throw new Exception("El prestamo no existe");
            }
            prestamos.Remove(prestamoExistente);
        }

        public List<Prestamo> ObtenerPrestamos()
        {
            return prestamos;
        }

        public void ModificarPrestamo(int id, Prestamo prestamo)
        {
            Prestamo prestamoExistente = ObtenerPrestamoPorId(id);
            if (prestamoExistente == null)
            {
                throw new Exception("El prestamo no existe");
            }
            prestamoExistente.Usuario = prestamo.Usuario;
            prestamoExistente.Libro = prestamo.Libro;
            prestamoExistente.FechaPrestamo = prestamo.FechaPrestamo;
            prestamoExistente.FechaDevolucion = prestamo.FechaDevolucion;
            prestamoExistente.Estado = prestamo.Estado;
        }
    }
}
