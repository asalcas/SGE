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


            try
            {
                existe = BL.ListadoClsTemperaturaBL.comprobacionFecha(fechaSelected);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
            


            if (existe)
            {
                // Crear el objeto DTO y llevarlo a la vista, no se como hacerlo sin meter otro return aquí
                ClsTemperaturasConNombreInvernaderoYFecha dto = new ClsTemperaturasConNombreInvernaderoYFecha();
                ClsInvernadero invernaderoParam;
                ClsTemperatura temperaturaParam;
                try
                {
                    invernaderoParam = BL.ListaClsInvernaderoBL.obtenerInvernaderoPorID(idInvernadero);
                    temperaturaParam = BL.ListadoClsTemperaturaBL.temperaturaPorInvernaderoYFecha(idInvernadero, fechaSelected);

                }catch(Exception ex)
                {
                    throw new Exception("Error al obtener los datos para el DTO", ex);
                }

                if (invernaderoParam != null && temperaturaParam != null)
                {
                    dto.Invernadero = invernaderoParam;
                    dto.Temperatura = temperaturaParam;
                    return View("VerTemperaturasYHumedad", dto);
                }

            }
            
            ViewBag.mensaje = "Error: Has seleccionado un invernadero/fecha no existente en nuestros registros, intentelo de nuevo con otros datos.";
            try
            {
                listadoInvernadero = BL.ListaClsInvernaderoBL.obtenerTodosLosInvernaderosBL();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al volver a rellenar la lista", ex);
                
            }
            

            return View(listadoInvernadero);
        }


        public ActionResult VerTemperaturasYHumedad( ClsTemperaturasConNombreInvernaderoYFecha dto)
        {
            return View(dto);
        }
        
    }
}
