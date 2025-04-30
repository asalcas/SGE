using DAL;
using ENT;
using Microsoft.Data.SqlClient;

namespace BL
{
    public class ManejadoraPersonasBL
    {
        /// <summary>
        /// Función de la BL que obtiene la lista de <ClsPersona> de la DAL con sus reglas de negocio, y será completa: "TODOS LOS REGISTROS DE LA BASE DE DATOS"
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns> La lista completa del tipo 'ClsPersona' </returns>
        public static List<ClsPersona> ObtenerListaPersonasCompletaBL()
        {
            return ManejadoraPersonasDAL.ObtenerListadoCompletoPersonasDAL();
        }

        /// <summary>
        /// Función que de la BL que se encarga de llamar a la DAL para obtener a UNA PERSONA DE LA BD a través de su ID
        /// Pre: La 'id' debe ser VÁLIDA
        /// Post: None
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Un objeto tipo ClsPersona </returns>
        public static ClsPersona ObtenerPersonaPorID(int id)
        {
            return ManejadoraPersonasDAL.buscarPersonaPorID(id);
        }

        /// <summary>
        /// Función que se encarga de llamar a la DAL para actualizar un Registro pasandole un objeto ClsPersona
        /// Pre: El 'Objeto.Nombre' y 'Objeto.Apellido' NO PUEDEN SER NULL
        /// Post: Si quieres mostrar los datos correctamente debes actualizar las vistas, ya que solo afecta en la BD, tendrás que llamar de nuevo a la BD y recargar todo
        /// </summary>
        /// <param name="personaEditar"></param>
        /// <returns> Boolean para saber si se ha actualizado el registro </returns>
        public static Boolean actualizarPersonaBL(ClsPersona personaEditar)
        {
            return ManejadoraPersonasDAL.editarPersonaBD(personaEditar);
        }

        /// <summary>
        /// Función de la BL que se encarga de llamar al metodo de Borrar una persona de la BD pasandole un parámetro
        /// Pre: El 'id' debe ser válido
        /// Post: El registro desaparece de la BD
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Boolean para saber si se ha eliminado el registro </returns>
        public static Boolean borrarPersonaBL(int id)
        {
            return ManejadoraPersonasDAL.eliminarPersonaDBDAL(id);
        }

        /// <summary>
        /// Función de la BL que llama a la DAL con un objeto tipo ClsPersona para que haga una sentancia SQL INSERT
        /// Pre: 'Objeto.Nombre' y 'Objeto.Apellido' deben de ser válidos, no pueden ser NULL 
        /// Post: None
        /// </summary>
        /// <param name="personaInsertar"></param>
        /// <returns></returns>
        public static Boolean insertarPersonaBL(ClsPersona personaInsertar)
        {
            return ManejadoraPersonasDAL.insertarPersonaDAL(personaInsertar);
        }
    }
}
