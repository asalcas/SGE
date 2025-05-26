using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClsConexion
    {
        /// <summary>
        /// Función que otorga una conexión abierta con la Base de datos en SqlServer
        /// PRE: None
        /// POST: Devuelve un objeto SqlConnection con la conexion abierta 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static SqlConnection abrirConexion()
        {
            SqlConnection miConexion;
            try
            {
                miConexion = new SqlConnection();
                miConexion.ConnectionString =
                    "server=alvaro-salvador.database.windows.net;database=alvaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
                miConexion.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return miConexion;
        }

        /// <summary>
        /// Función dedicada a cerrar una conexión que tengamos en nuestras funciones
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
