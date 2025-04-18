using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace DAL
{
    public class ClsConexionBD
    {
        /// <summary>
        /// Esta función se encarga de abrir una Conexion con la Base de Datos.
        /// PRE: None
        /// POST: Devuelve un objeto SqlConnection con la conexion abierta 
        /// </summary>
        /// <returns> miConexion (conexion abierta anteriormente) </returns>
        public static SqlConnection abrirConexion()
        {
            SqlConnection miConexion = new SqlConnection();
            try
            {
                miConexion.ConnectionString =
                    "server=alvaro-salvador.database.windows.net;database=alvaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";

                miConexion.Open();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return miConexion;
        }

        /// <summary>
        /// Función que se encargará de cerrar una conexión con la Base de Datos en específico
        /// PRE: Debe tener una conexion PREVIAMENTE ABIERTA
        /// POST: La conexion en cuestión se quedará cerrada
        /// </summary>
        /// <param name="miConexion"></param>
        public static void cerrarConexion(ref SqlConnection miConexion)
        {
            miConexion.Close();
        }
    }
}
