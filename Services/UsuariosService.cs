using GestionBiblioteca.Entities;

namespace GestionBiblioteca.Services
{
    internal class UsuariosService
    {
        private List<Usuario> usuarios;

        public UsuariosService()
        {
            usuarios = new List<Usuario>();
        }

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return usuarios.FirstOrDefault(usuario => usuario.Id == id);
        }

        public void EliminarUsuario(int id)
        {
            Usuario usuarioExistente = ObtenerUsuarioPorId(id);
            if (usuarioExistente == null)
            {
                throw new Exception("El usuario no existe");
            }
            usuarios.Remove(usuarioExistente);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public void ModificarUsuario(int id, Usuario usuario)
        {
            Usuario usuarioExistente = ObtenerUsuarioPorId(id);
            if (usuarioExistente == null)
            {
                throw new Exception("El usuario no existe");
            }
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Correo = usuario.Correo;
            usuarioExistente.Telefono = usuario.Telefono;
        }
    }
}
