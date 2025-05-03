using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ClsConexionDB
    {
        /// <summary>
        /// Función que hace la conexion con la Base de datos hecha para devolvernos una conexion abierta.
        /// PRE: NONE
        /// POST: La conexion solo estará o ABIERTA o NULA
        /// </summary>
        /// <returns> SqlConnection 'miConexion.Open()' </returns>
        /// <exception cref="Exception"></exception>
        public static SqlConnection abrirConexionBD() {

            SqlConnection miConexion = new SqlConnection();
            try
            {
                miConexion.ConnectionString =
                                        "server=alvaro-salvador.database.windows.net;database=alvaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
                miConexion.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Hubo un error al abrir la conexion a la BD", ex);
            }
            
            return miConexion;
        }

        public static void cerrarConexionDB(ref SqlConnection miConexion)
        {
            try
            {
                miConexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al CERRAR la conexión", ex);

            }
        }
    }
}
