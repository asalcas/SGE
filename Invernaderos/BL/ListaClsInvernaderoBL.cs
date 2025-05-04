using ENT;

namespace BL
{
    public class ListaClsInvernaderoBL
    {
        /// <summary>
        /// Función que llama directamente al metodo 'obtenerTemperaturaPorInvernaderoYFecha' con los parametros (id, fecha)
        /// PRE: Tanto 'id' como 'fecha' NO PUEDEN SER NULL, ya que ambos forman una Primary key compuesta.
        /// POST: Devuelve UN solo ClsTemperatura, ya sea Vacio o Lleno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static ClsTemperatura obtenerTemperaturaPorInvernaderoYFecha(int id, DateTime fecha)
        {
            return DAL.ListadosClsTemperaturasDAL.obtenerTemperaturasPorInvernaderoYFecha(id, fecha);
        }

        /// <summary>
        /// Funcion que referencia a la DAL para obtener un listado completo de Invernaderos de la Base de DAtos
        /// PRE: NONE
        /// POST: El listado que retornará Contendrá TODOS LOS REGISTROS de la Base de DATOS
        /// </summary>
        /// <returns> List<ClsInvernadero> </returns>
        public static List<ClsInvernadero> obtenerTodosLosInvernaderosBL()
        {
            return DAL.ListadosInvernaderosDAL.obtenerListadoCompletoInvernaderosDAL();
        }

        /// <summary>
        /// Función que retorna un objeto tipo ClsInvernadero de la Base de datos según su ID
        /// PRE: El Id NO PUEDE SER NULL
        /// POST: Devuelve un objeto tipo ClsInvernadero o lleno o vacío.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsInvernadero obtenerInvernaderoPorID(int id)
        {
            return DAL.ListadosInvernaderosDAL.obtenerInvernaderoPorId(id);
        }
    }
}
