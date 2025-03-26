using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unidad7.Models;
using BL;
using ENT;
using System.Collections.Generic;
using Actividad4ASP.Views.VM;

namespace Unidad7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Action que recibe un VM para entregarselo a la vista para mostrarla
        /// </summary>
        /// <returns> View(personaRandomSelected) </returns>
        public IActionResult Index()
        {
            Random random = new Random();

            List<ClsPersona> ListadoDePersonas = ListaPersonasBL.ObtenerListadoCompletoPersonasBL(); // Conseguimos la lista de la BL
            List<ClsDepartamento> ListadoDeDepartamentos = ListaDepartamentosBL.ObtenerListadoDepartamentosCompletoBL();
            int numRandom = random.Next(0, ListadoDePersonas.Count());
            ClsPersona personaRandom = ListadoDePersonas[numRandom];
            String departamentoSeleccionado = "";

            foreach (var departamento in ListadoDeDepartamentos) // Cambiarlo a While o al Lambda Find
            {
                if (departamento.IdDepartamento == personaRandom.IdDepartamento)
                {
                    departamentoSeleccionado = departamento.NombreDept;
                }
            }
            // Aqui estoy creando el objeto VM en teoría con el ID del ClsPersona random
            PersonaDepartamentosVM personaRandomSelected = new(numRandom, personaRandom.Nombre, personaRandom.Apellido,
                personaRandom.FechaNac, personaRandom.Direccion, personaRandom.Telefono, departamentoSeleccionado); 


            return View(personaRandomSelected); // se la damos al controllador pa que se la de a la vista


        }

        /// <summary>
        /// En el action vamos a traer las listas de la BL, para mostrar en la vista el Objeto 'PersonaDepartamentosVM' con un ID (que en este caso será la 
        /// posición del array, simulando un AUTOINCREMENT
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View(personaEditar)</returns>
        public IActionResult EditarPersona(int id)
        {
            bool founded = false;
            int indice = 0;
            List<ClsPersona> personas = ListaPersonasBL.ObtenerListadoCompletoPersonasBL();
            List<ClsDepartamento> listadoDeptCompleto = ListaDepartamentosBL.ObtenerListadoDepartamentosCompletoBL();
            ClsPersona personaEncontrada = new();
            String nombreDept = "";

            //Buscamos la persona
            while (!founded && indice < personas.Count())
            {

                if (indice == id)
                {
                    personaEncontrada = personas[indice];
                    founded = true;
                }

                indice++;
            }

            founded = false;
            indice = 0;

            // Buscamos el departamento
            while (!founded && indice < listadoDeptCompleto.Count())
            {
                if (listadoDeptCompleto[indice].IdDepartamento == personaEncontrada.IdDepartamento)
                {
                    nombreDept = listadoDeptCompleto[indice].NombreDept;
                }
                indice++;
            }

            PersonaDepartamentosVM personaEditar = new PersonaDepartamentosVM(
                id,
                personaEncontrada.Nombre,
                personaEncontrada.Apellido,
                personaEncontrada.FechaNac,
                personaEncontrada.Direccion,
                personaEncontrada.Telefono,
                nombreDept);


            return View(personaEditar);  // se la damos al controllador pa que se la de a la vista


        }

    }
}
