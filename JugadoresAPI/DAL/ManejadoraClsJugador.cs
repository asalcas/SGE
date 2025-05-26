using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ManejadoraClsJugador
    {
        /// <summary>
        /// Función que insertará un nuevo registro en la Base de Datos.
        /// </summary>
        /// <param name="nombreJugador"></param>
        /// <param name="puntuacionJugador"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int insertarJugadorDAL(String nombreJugador, int puntuacionJugador)
        {
            int numFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.CommandText =
                    "INSERT INTO Jugador (nombreJugador, puntuacionJugador) VALUES (@nombre, @puntuacion);";
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombreJugador;
                miComando.Parameters.Add("@puntuacion", System.Data.SqlDbType.Int).Value = puntuacionJugador;
                miComando.Connection = miConexion;

                numFilasAfectadas = miComando.ExecuteNonQuery();

            }catch(Exception ex)
            {
                throw new Exception("No se pudo introducir un nuevo Jugador en la base de datos", ex);
            }
            finally
            {
                ClsConexion.cerrarConexion(ref miConexion);
            }

            return numFilasAfectadas;

        }
    }
}
