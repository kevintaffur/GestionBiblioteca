
using GestionBiblioteca.Entities;
using GestionBiblioteca.Services;

LibroService libroService = new LibroService();
UsuariosService usuarioService = new UsuariosService();
PrestamoService prestamoService = new PrestamoService();

Console.WriteLine("Sistema de Gestión de Biblioteca Digital");

while (true)
{
    Console.WriteLine("1. Agregar Usuario");
    Console.WriteLine("2. Modificar Usuario");
    Console.WriteLine("3. Eliminar Usuario");
    Console.WriteLine("4. Listar Usuarios");
    Console.WriteLine("5. Agregar Libro");
    Console.WriteLine("6. Modificar Libro");
    Console.WriteLine("7. Eliminar Libro");
    Console.WriteLine("8. Listar Libros");
    Console.WriteLine("9. Agregar Prestamo de Libro");
    Console.WriteLine("10. Listar Prestamos");
    Console.WriteLine("11. Salir");

    Console.Write("Ingrese una opción: ");
    try
    {
        int opcion = int.Parse(Console.ReadLine());

        if (opcion == 11)
        {
            break;
        }

        switch (opcion)
        {
            case 1:
                AgregarUsuario();
                break;
            case 2:
                ModificarUsuario();
                break;
            case 3:
                EliminarUsuario();
                break;
            case 4:
                ListarUsuarios();
                break;
            case 5:
                AgregarLibro();
                break;
            case 6:
                ModificarLibro();
                break;
            case 7:
                EliminarLibro();
                break;
            case 8:
                ListarLibros();
                break;
            case 9:
                AgregarPrestamo();
                break;
            case 10:
                ListarPrestamos();
                break;
            default:
                Console.WriteLine("Opción no válida");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}

void ListarPrestamos()
{
    List<Prestamo> prestamos = prestamoService.ObtenerPrestamos();
    if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay prestamos registrados");
        return;
    }
    foreach (Prestamo prestamo in prestamos)
    {
        Console.WriteLine(prestamo.ToString());
    }
}

void AgregarUsuario()
{
    string nombreUsuario = "";
    do
    {
        Console.Write("Ingrese el nombre del usuario: ");
        nombreUsuario = Console.ReadLine();
    } while (nombreUsuario.Trim().Equals(""));

    string correoUsuario = "";
    do
    {
        Console.Write("Ingrese el correo del usuario: ");
        correoUsuario = Console.ReadLine();
    } while (correoUsuario.Trim().Equals(""));

    string telefonoUsuario = "";
    do
    {
        Console.Write("Ingrese el teléfono del usuario: ");
        telefonoUsuario = Console.ReadLine();
    } while (telefonoUsuario.Trim().Equals(""));

    usuarioService.AgregarUsuario(new Usuario(nombreUsuario, correoUsuario, telefonoUsuario));
}

bool ListarUsuarios()
{
    List<Usuario> usuarios = usuarioService.ObtenerUsuarios();

    if (usuarios.Count == 0)
    {
        Console.WriteLine("No hay usuarios registrados");
        return false;
    }

    foreach (Usuario usuario in usuarios)
    {
        Console.WriteLine(usuario.ToString());
    }
    return true;
}

void ModificarUsuario()
{
    if (!ListarUsuarios())
    {
        return;
    }

    Console.Write("Ingrese el id del usuario a modificar: ");
    try
    {
        int idUsuario = int.Parse(Console.ReadLine());
        Usuario usuarioExistente = usuarioService.ObtenerUsuarioPorId(idUsuario);
        if (usuarioExistente == null)
        {
            Console.WriteLine("El usuario no existe");
            return;
        }
        string nombreUsuario = "";
        do
        {
            Console.Write("Ingrese el nombre del usuario: ");
            nombreUsuario = Console.ReadLine();
        } while (nombreUsuario.Trim().Equals(""));
        usuarioExistente.Nombre = nombreUsuario;
        string correoUsuario = "";
        do
        {
            Console.Write("Ingrese el correo del usuario: ");
            correoUsuario = Console.ReadLine();
        } while (correoUsuario.Trim().Equals(""));
        usuarioExistente.Correo = correoUsuario;
        string telefonoUsuario = "";
        do
        {
            Console.Write("Ingrese el teléfono del usuario: ");
            telefonoUsuario = Console.ReadLine();
        } while (telefonoUsuario.Trim().Equals(""));
        usuarioExistente.Telefono = telefonoUsuario;
        Usuario usuarioModificado = new Usuario(nombreUsuario, correoUsuario, telefonoUsuario);
        usuarioService.ModificarUsuario(idUsuario, usuarioModificado);
        Console.WriteLine("Usuario modificado correctamente");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);

    }
}

void EliminarUsuario()
{
    if (!ListarUsuarios())
    {
        return;
    }
    Console.Write("Ingrese el id del usuario a eliminar: ");
    try
    {
        int idUsuario = int.Parse(Console.ReadLine());
        usuarioService.EliminarUsuario(idUsuario);
        Console.WriteLine("Usuario eliminado correctamente");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}

void AgregarLibro()
{
    string tituloLibro = "";
    do
    {
        Console.Write("Ingrese el título del libro: ");
        tituloLibro = Console.ReadLine();
    } while (tituloLibro.Trim().Equals(""));

    string autorLibro = "";
    do
    {
        Console.Write("Ingrese el autor del libro: ");
        autorLibro = Console.ReadLine();
    } while (autorLibro.Trim().Equals(""));

    string isbnLibro = "";
    do
    {
        Console.Write("Ingrese el ISBN del libro: ");
        isbnLibro = Console.ReadLine();
    } while (isbnLibro.Trim().Equals(""));

    int publicacionYearLibro = 0;
    do
    {
        Console.Write("Ingrese el año de publicación del libro: ");
        try
        {
            publicacionYearLibro = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ingrese un año válido.");
            publicacionYearLibro = 0;
        }
    } while (publicacionYearLibro == 0);

    libroService.AgregarLibro(new Libro(tituloLibro, autorLibro, isbnLibro, publicacionYearLibro));
}

bool ListarLibros()
{
    List<Libro> libros = libroService.ObtenerLibros();
    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros registrados");
        return false;
    }
    foreach (Libro libro in libros)
    {
        Console.WriteLine(libro.ToString());
    }
    return true;
}

void ModificarLibro()
{
}

void EliminarLibro()
{
    if (!ListarLibros())
    {
        return;
    }
    Console.Write("Ingrese el id del libro a eliminar: ");
    try
    {
        int idLibro = int.Parse(Console.ReadLine());
        libroService.EliminarLibro(idLibro);
        Console.WriteLine("Libro eliminado correctamente");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}

void AgregarPrestamo()
{
    if (!ListarUsuarios())
    {
        return;
    }

    int idUsuario = 0;
    Usuario usuario = null;
    do
    {
        Console.WriteLine("Ingrese el id del usuario: ");
        try
        {
            idUsuario = int.Parse(Console.ReadLine());
            usuario = usuarioService.ObtenerUsuarioPorId(idUsuario);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ingrese un id válido.");
            idUsuario = 0;
        }
    } while (idUsuario == 0);


    if (!ListarLibros())
    {
        return;
    }

    int idLibro = 0;
    Libro libro = null;
    do
    {
        Console.WriteLine("Ingrese el id del libro: ");
        try
        {
            idLibro = int.Parse(Console.ReadLine());
            libro = libroService.ObtenerLibroPorId(idLibro);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ingrese un id válido.");
            idLibro = 0;
        }
    } while (idLibro == 0);

    prestamoService.AgregarPrestamo(new Prestamo(usuario, libro, DateTime.Now));
}