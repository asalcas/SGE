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
                    salida = NotFound("No se encontró registro con ese ID"); // Ahora mismo llega un ClsJugador = Null
                }

            }catch(Exception ex)
            {
                salida = BadRequest();
            }

            return salida;
        }

        // POST api/<JugadoresController>
        [HttpPost]
        public IActionResult Post([FromBody] ClsJugador jugador)
        {
            IActionResult salida;
            int numeroInserciones;
            try
            {
                numeroInserciones = BL.ManjeadoraClsJugador.insertarJugadorBL(jugador);
                if(numeroInserciones > 0)
                {
                    salida = Ok(numeroInserciones);
                }
                else
                {
                    
                    salida = NotFound();
                }

            }catch(Exception ex)
            {
                salida = BadRequest();
            }
            return salida;
        }

        // PUT api/<JugadoresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClsJugador jugador)
        {
            // HECHO PARA PRACTICAR

            IActionResult salida;
            ClsJugador jugadorActualizado;
            int numFilasAfectadas = 0;
            try
            {
                jugadorActualizado = new ClsJugador(id);
                jugadorActualizado.NombreJugador = jugador.NombreJugador;
                jugadorActualizado.PuntuacionJugador = jugador.PuntuacionJugador;
                numFilasAfectadas = BL.ManjeadoraClsJugador.updateJugadorBL(jugadorActualizado);

                if(numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok(numFilasAfectadas);
                }

            }catch(Exception ex)
            {
                salida = BadRequest();
            }

            return salida;

        }

        // DELETE api/<JugadoresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // HECHO PARA PRACTICAR
            IActionResult salida;
            int numFilasAfectadas = 0;
            try
            {
                numFilasAfectadas = BL.ManjeadoraClsJugador.borrarJugadorBL(id);
                if (numFilasAfectadas > 0)
                {
                    salida = Ok(numFilasAfectadas);
                }
                else
                {
                    salida = NotFound();
                }


            }catch(Exception ex)
            {
                salida = BadRequest();
            }
            return salida;
        }
    }
}
