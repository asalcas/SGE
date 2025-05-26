using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ENT;

namespace DAL
{
    public class ManejadoraClsJugador
    {
        /// <summary>
        /// Función que insertará un nuevo registro en la Base de Datos.
        /// POST: Nos devolverá el numero de inserciones que hagamos
        /// </summary>
        /// <param name="nombreJugador"></param>
        /// <param name="puntuacionJugador"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int insertarJugadorDAL(ClsJugador jugador)
        {
            int numFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.CommandText =
                    "INSERT INTO Jugador (nombreJugador, puntuacionJugador) VALUES (@nombre, @puntuacion);";
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = jugador.NombreJugador;
                miComando.Parameters.Add("@puntuacion", System.Data.SqlDbType.Int).Value = jugador.PuntuacionJugador;
                miComando.Connection = miConexion;

                numFilasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo introducir un nuevo Jugador en la base de datos", ex);
            }
            finally
            {
                ClsConexion.cerrarConexion(ref miConexion);
            }

            return numFilasAfectadas;

        }
        /// <summary>
        /// Función que se encarga de conectarse a la Base de datos y actualizar un registro de la misma por el ID
        /// PRE: ID NO PUEDE SER INEXISTENTE
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int updateUsuario(ClsJugador jugador)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int numFilasAfectadas = 0;
            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.Connection = miConexion;
                miComando.CommandText =
                    "UPDATE Jugador " +
                    "SET nombreJugador = @nombre, " +
                    "puntuacionJugador = @puntuacion " +
                    "WHERE idJugador = @id;";
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = jugador.NombreJugador;
                miComando.Parameters.Add("@puntuacion", System.Data.SqlDbType.Int).Value = jugador.PuntuacionJugador;
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = jugador.IdJugador;

                numFilasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo actualizar un registro DAL", ex);
            }
            finally
            {
                ClsConexion.cerrarConexion(ref miConexion);
            }

            return numFilasAfectadas;
        }
        /// <summary>
        /// Función que se encarga de conectarse a la Base de datos y elimina un registro de la misma por el ID
        /// PRE: ID NO PUEDE SER INEXISTENTE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int deletePersona(int id)
        {
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            int numFilasAfectadas = 0;
            try
            {

                miConexion = ClsConexion.abrirConexion();
                miComando.Connection = miConexion;
                miComando.CommandText =
                    "DELETE FROM Jugador WHERE idJugador = @id;";
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                numFilasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo borrar un registro DAL", ex);
            }
            finally
            {
                ClsConexion.cerrarConexion(ref miConexion);
            }
            return numFilasAfectadas;
        }
    }
}
