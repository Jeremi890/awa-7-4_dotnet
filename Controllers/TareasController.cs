using Microsoft.AspNetCore.Mvc; //funcionalidades de controladores y respuestas
using TaskFlowApi.Models;

namespace TaskFlowApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private static List<Tarea> tareas = new List<Tarea>
        {
            //Crear objetos Tareas y se agregan a la lista
            new Tarea { Id = 1, Titulo = "Estudiar Angular", Descripcion= "Repasar componentes", Completada = true},
            new Tarea { Id = 2, Titulo = "Estudiar .NET", Descripcion= "Repasar apis", Completada = false}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
            {
                return NotFound();
            }

            return Ok(tarea);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea nuevaTarea)
        {
            //el servidor recibe JSON y lo transforma automaticamente en un objeto de C#
            nuevaTarea.Id = tareas.Count + 1;
            tareas.Add(nuevaTarea);

            //uri -> indica la dirección url donde se puede encontrar el recurso creado
            return Created("", nuevaTarea);

        }
    }




}