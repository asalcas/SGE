using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ENT;
using DTOs;

namespace InvernASP.Controllers
{
    public class InvernaderosController : Controller
    {
        // GET: InvernaderosController
        public ActionResult Index()
        {

            List<ClsInvernadero> listadoInvernaderos = new List<ClsInvernadero>();
            try
            {
                listadoInvernaderos = BL.ListaClsInvernaderoBL.obtenerTodosLosInvernaderosBL();
            }
            catch (Exception ex)
            {

                return View("Error");
            }

            return View(listadoInvernaderos);
        }

        [HttpPost]
        public ActionResult Index(int idInvernadero, DateTime fechaSelected)
        {
            Boolean existe = false;
            List<ClsInvernadero> listadoInvernadero = new List<ClsInvernadero>();
            ViewBag.exito = "false"; // Condicion para poder cambiar estilos en la clase del mensaje que meteremos en el HTML
            ClsInvernadero invernaderoParam;
            ClsTemperatura temperaturaParam;
            ClsTemperaturasConNombreInvernaderoYFecha dto;

            ActionResult vista = View();

            if (idInvernadero != 0)
            {
                try
                {
                    existe = BL.ListadoClsTemperaturaBL.comprobacionFecha(fechaSelected);
                    if (existe)
                    {
                        // Crear el objeto DTO y llevarlo a la vista, no se como hacerlo sin meter otro return aquí
                        dto = new ClsTemperaturasConNombreInvernaderoYFecha();


                        invernaderoParam = BL.ListaClsInvernaderoBL.obtenerInvernaderoPorID(idInvernadero);
                        temperaturaParam = BL.ListadoClsTemperaturaBL.temperaturaPorInvernaderoYFecha(idInvernadero, fechaSelected);

                        if (invernaderoParam != null && temperaturaParam != null)
                        {
                            dto.Invernadero = invernaderoParam;
                            dto.Temperatura = temperaturaParam;
                            vista = View("VerTemperaturasYHumedad", dto);
                        }
                    }
                    else
                    {
                        // Si continuamos sin irnos a la vista correspondiente salta este ViewBag
                        ViewBag.mensaje = "Error: Has seleccionado un invernadero/fecha no existente en nuestros registros, intentelo de nuevo con otros datos.";

                        listadoInvernadero = BL.ListaClsInvernaderoBL.obtenerTodosLosInvernaderosBL();


                        // EN VEZ DE REPETIR EL MISMO CODIGO QUE EL INDEX REDIRECCIONO AL ACTION IN
                        vista = View(listadoInvernadero);
                    }
                }
                catch (Exception ex)
                {

                    vista = View("Error");
                }



            }
            else
            {
                ViewBag.mensaje = "Error: Has seleccionado un invernadero/fecha no existente en nuestros registros, intentelo de nuevo con otros datos.";
                idInvernadero = 0;
            }

                return vista;

        }


    }
}
