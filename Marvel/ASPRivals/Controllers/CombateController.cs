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

        public ActionResult PuntuarCombate(List<ClsHeroeVillano> listado)
        {
            listado = BL.ListadoHeroesVillanosBL.ObtenerlistadoHeroesVillanoBL();
            return View(listado);
        }

        public ActionResult TablaClasificacion(List<ClsHeroeVillanoConPuntos> listadoHeroesVillanosConPuntos)
        {
            return View(listadoHeroesVillanosConPuntos);
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
