using TaskFlowApi.Models;

namespace TaskFlowApi.Services
{
    public class LibroService
    {
        private readonly List<Libro> libros = new()
        {
            new Libro{ Id = 1, Titulo = "Clean Code", Autor = "Robert Martin", Disponible = true},
            new Libro{ Id = 2, Titulo = "The pragmatic Programmer", Autor = "Andrew Hunt", Disponible = false},
        };

        public List<Libro> ObtenerTodos()
        {
            return libros;
        }

        public Libro? ObtenerPorId(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }
        public Libro Agregar(Libro nuevoLibro)
        {
            nuevoLibro.Id = libros.Count > 0
                ? libros.Max(l => l.Id) + 1
                : 1;

            libros.Add(nuevoLibro);

            return nuevoLibro;
        }

        public Libro? Actualizar(int id, Libro libroActualizado)
        {
            var libro = ObtenerPorId(id);

            if (libro == null)
            {
                return null;
            }

            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;
            libro.Disponible = libroActualizado.Disponible;

            return libro;
        }

        public bool Eliminar(int id)
        {
            var libro = ObtenerPorId(id);

            if (libro == null)
            {
                return false;
            }

            libros.Remove(libro);

            return true;
        }
    }
}