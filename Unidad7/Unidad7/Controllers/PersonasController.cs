using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unidad7.Models;
using BL;
using ENT;
using System.Collections.Generic;
using Actividad4ASP.Models.VM;

namespace Unidad7.Controllers
{
    public class PersonasController : Controller
    {

        /// <summary>
        /// Action que retorna una Persona aleatoria cada vez que entramos
        /// </summary>
        /// <returns> View(personaRandomSelected) </returns>
        public IActionResult Actualizar()
        {

            ClsPersona personaAleatoria = BL.ListaPersonasBL.ObtenerPersonaAleatoria();
            PersonaConListaDepartamentosVM personaVM = new PersonaConListaDepartamentosVM(personaAleatoria);


            return View(personaVM); // se la damos al controllador pa que se la de a la vista


        }

    }
}
