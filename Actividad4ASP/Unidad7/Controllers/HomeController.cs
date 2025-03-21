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

        public IActionResult Index()
        {
            Random random = new Random();


            List<ClsPersona> ListadoDePersonas = ListaPersonasBL.ObtenerListadoCompletoPersonasBL(); // Conseguimos la lista de la BL
            List<ClsDepartamento> ListadoDeDepartamentos = ListaDepartamentosBL.ObtenerListadoDepartamentosCompletoBL();

            int numRandom = random.Next(0, ListadoDePersonas.Count());
            //ViewData["DatoAPasar"] = ListadoDePersonas[numRandom];
            ClsPersona personaRandom = ListadoDePersonas[numRandom];

            String departamentoSeleccionado = "";

            foreach (var departamento in ListadoDeDepartamentos)
            {
                if (departamento.IdDepartamento == personaRandom.IdDepartamento)
                {
                    departamentoSeleccionado = departamento.NombreDept;
                }
            }

            // Hacer la logica del ClsPersonaConnombreDept aqui

            PersonaDepartamentosVM personaRandomSelected = new PersonaDepartamentosVM(personaRandom.Nombre, personaRandom.Apellido,
                personaRandom.FechaNac, personaRandom.Direccion, personaRandom.Telefono, departamentoSeleccionado);

            ViewData["DatoAPasar"] = personaRandomSelected;

           

            // se la damos al controllador pa que se la de a la vista
            return View(personaRandomSelected); // Pasar persona con nombre dept 

        }
        public IActionResult EditarPersona()
        {
             
           // Preguntar como pasar el mismo objeto que tengo en el INDEX para así usarlo en el CSHTML "EditarPersona"

            
            return View(); 
            
            
        }
        
    }
}
