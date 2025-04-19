using DTO;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            List<ClsHeroeVillano> listado = BL.ListadoHeroesVillanosBL.ObtenerlistadoHeroesVillanoBL();
            return View(listado);
        }

        [HttpPost]
        public ActionResult PuntuarCombate(int personaje1, int personaje2, int puntuacion1, int puntuacion2)
        {
            Boolean guardado = false;
            ClsCombate nuevoCombate = new ClsCombate(personaje1,personaje2,DateTime.Today,puntuacion1,puntuacion2);
            

            if(nuevoCombate.IdCombatiente1 != nuevoCombate.IdCombatiente2 && nuevoCombate.ResultadoCombatiente1 != nuevoCombate.ResultadoCombatiente2)
            {
                guardado = BL.ManejadoraCombateBL.guardarCombateBL(nuevoCombate);
                TempData["Exito"] = "Has puntuado correctamente el combate. SHIELD te da las gracias.";
                return RedirectToAction(nameof(TablaClasificacion)); // Esto puede ser peruanada

            }
            else
            {
                TempData["Error"] = "Deben de ser personajes diferentes y/o tener distintas puntuaciones";

            }
            return RedirectToAction(nameof(PuntuarCombate));



        }


        public ActionResult TablaClasificacion()
        {

            List<ClsHeroeVillanoConPuntos> ranking = new List<ClsHeroeVillanoConPuntos>();
            ranking = BL.ListadoHeroesVillanosConPuntos.obtenerListadoCompletoConPuntos();

            return View(ranking);
        }

        // GET: CombateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CombateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CombateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CombateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CombateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CombateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CombateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
