using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JugadoresAPI.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        // GET: api/<JugadoresController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<ClsJugador> listadoCompleto = new List<ClsJugador>();
            try
            {
                listadoCompleto = BL.ListadoClsJugadoresBL.obtenerTodosLosJugadoresBL();
                
                if(listadoCompleto.Count == 0)
                {
                    salida = NoContent(); // La lista esta vacía por lo que NoContent()
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            
            }catch(Exception ex)
            {
                salida = BadRequest();
            }

            return salida;
        }

        // GET api/<JugadoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            ClsJugador jugador;

            try
            {
                jugador = BL.ListadoClsJugadoresBL.obtenerJugadorPorIDBL(id);
                if(jugador != null)
                {
                    salida = Ok(jugador);
                }
                else
                {
                    salida = NoContent(); // Ahora mismo llega un ClsJugador = Null
                }

            }catch(Exception ex)
            {
                salida = BadRequest();
            }

            return salida;
        }

        // POST api/<JugadoresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JugadoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JugadoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
