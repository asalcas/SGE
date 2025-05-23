﻿using Microsoft.AspNetCore.Mvc;
using ENT;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Actividad2ASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<ClsPersona> listadoCompleto = new List<ClsPersona>();

            try
            {
                listadoCompleto = BL.ManejadoraPersonasBL.ObtenerListaPersonasCompletaBL();

                if(listadoCompleto.Count == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch (Exception ex)
            {
                salida = BadRequest();
            }
            
            return salida;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            ClsPersona personaPorID;
            try
            {
                personaPorID = BL.ManejadoraPersonasBL.ObtenerPersonaPorID(id);
                if (personaPorID != null)
                {
                    salida = Ok(personaPorID);
                }
                else
                {
                    salida = NoContent();
                }


            }
            catch (Exception ex)
            {
                salida = BadRequest();
            }


            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] ClsPersona persona)
        {
            IActionResult salida;
            Boolean insertado = false;


            try
            {
                insertado = BL.ManejadoraPersonasBL.insertarPersonaBL(persona);
                if (insertado)
                {
                    salida = Ok();
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

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClsPersona persona)
        {
            IActionResult salida;
            Boolean actualizado = false;
            ClsPersona personaNueva = new ClsPersona(id);
            try
            {

                // Peruanada, pero claro como no tengo SET en el ID de la entidad Persona, y no he querido ponerlo, he decidido crear otro objeto, que si lo tenga
                personaNueva.Nombre = persona.Nombre;
                personaNueva.Apellidos = persona.Apellidos;
                personaNueva.FechaNacimiento = persona.FechaNacimiento;
                personaNueva.IdDept = persona.IdDept;
                personaNueva.Direccion = persona.Direccion;
                personaNueva.Foto = persona.Foto;
                personaNueva.Telefono = persona.Telefono;

                
                if(id == personaNueva.ID)
                {
                    actualizado = BL.ManejadoraPersonasBL.actualizarPersonaBL(personaNueva);
                }

                if (actualizado)
                {
                    salida = Ok("Persona insertada correctamente");
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

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            Boolean borrado = false;

            try
            {
                borrado = BL.ManejadoraPersonasBL.borrarPersonaBL(id);
                if (borrado)
                {
                    salida = Ok();
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
