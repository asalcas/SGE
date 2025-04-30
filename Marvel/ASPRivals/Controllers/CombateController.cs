using ASPRivals.Models.VM;
using DTO;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;

namespace ASPRivals.Controllers
{
    public class CombateController : Controller
    {
        // GET: CombateController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PuntuarCombate()
        {
            // ANTES TENIA UN LISTADO RELLENADO DESDE LA BL, COMO NO PUEDO ENVIARLE A LOS DOS ACTION: 'PuntuarCombate' HAY QUE ENVIARLE LO MISMO
            ListadoHeroeVillanoConCombate miVM = new ListadoHeroeVillanoConCombate();
            return View(miVM);
        }

        [HttpPost]
        public ActionResult PuntuarCombate(ClsCombate nuevoCombate)
        {
            ViewBag.exito = "false";
            Boolean guardado = false;
            ListadoHeroeVillanoConCombate miVM;
            if (nuevoCombate.IdCombatiente1 == 0 || nuevoCombate.IdCombatiente2 == 0)
            {
                ViewBag.mensaje = "Tienes que seleccionar a los dos Combatientes espabilao.";
            }
            else
            {
                if (nuevoCombate.IdCombatiente1 != nuevoCombate.IdCombatiente2)
                {
                    try
                    {
                        guardado = BL.ManejadoraCombateBL.guardarCombateBL(nuevoCombate);
                        if (guardado)
                        {
                            ViewBag.mensaje = "Has puntuado correctamente el combate. SHIELD te da las gracias.";
                            ViewBag.exito = "true";
                        }
                        else
                        {
                            ViewBag.mensaje = "Ha ocurrido un error al guardar la puntuación. Vuelve a intentarlo más tarde.";
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.mensaje = ex.Message;
                        return View("Error");
                    }
                }
                else
                {
                    ViewBag.mensaje = "Deben de ser personajes diferentes >:(";
                }
            }

            miVM = new ListadoHeroeVillanoConCombate(nuevoCombate);
            return View(miVM);
        }
        

        public ActionResult TablaClasificacion()
        {

            List<ClsHeroeVillanoConPuntos> ranking = new List<ClsHeroeVillanoConPuntos>();
            ranking = BL.ListadoHeroesVillanosConPuntos.obtenerListadoCompletoConPuntos();

            return View(ranking);
        }


    }
}
