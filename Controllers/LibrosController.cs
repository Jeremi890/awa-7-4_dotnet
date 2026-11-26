using Microsoft.AspNetCore.Mvc;
using TaskFlowApi.Models;
using TaskFlowApi.Services;

namespace TaskFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly LibroService _libroService;
        //Guarda una referencia al servicio

        public LibrosController(LibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_libroService.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var libro = _libroService.ObtenerPorId(id);

            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Libro nuevoLibro)
        {
            var libroCreado = _libroService.Agregar(nuevoLibro);

            return Created("", libroCreado);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Libro libroActualizado)
        {
            var libro = _libroService.Actualizar(id, libroActualizado);

            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = _libroService.Eliminar(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return Ok(new { mensaje = "Libro eliminado correctamente" });
        }
    }
}