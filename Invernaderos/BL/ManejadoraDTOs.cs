using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using ENT;

namespace BL
{
    public class ManejadoraDTOs
    {
        /// <summary>
        /// Función que se encarga de rellenar los DTO necesarios para las vistas correspondientes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ClsTemperaturasConNombreInvernaderoYFecha rellenarDTO(int id, DateTime fecha)
        {
            ClsTemperaturasConNombreInvernaderoYFecha temperaturaParaLaVista = new ClsTemperaturasConNombreInvernaderoYFecha();
            try
            {
                ClsInvernadero invernadero = DAL.ListadosInvernaderosDAL.obtenerInvernaderoPorId(id);
                ClsTemperatura temperatura = DAL.ListadosClsTemperaturasDAL.obtenerTemperaturasPorInvernaderoYFecha(id, fecha);
                temperaturaParaLaVista.Temperatura = temperatura;
                temperaturaParaLaVista.Invernadero = invernadero;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al rellenar un DTO", ex);
            }
            return temperaturaParaLaVista;
        }
    }
}
