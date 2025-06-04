using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadoClsJugadores
    {
        /// <summary>
        /// Función que traerá una lista completa de objetos tipo 'ClsJugador' con todos los datos que tengamos en la Base de Datos
        /// PRE: None
        /// POST: Si no hay datos la lista será VACÍA. Posibles estados: Llena/Vacía pero nunca Null ORDENADA De forma Descendente
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<ClsJugador> obtenerTodosLosJugadoresDAL()
        {
            List<ClsJugador> listadoJugadores = new List<ClsJugador>();
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            int idJugador = 0;
            int puntuacionJugador = 0;

            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.CommandText = "SELECT * FROM Jugador ORDER BY puntuacionJugador DESC;";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        if (miLector["idJugador"] != DBNull.Value)
                        {
                            idJugador = (int)miLector["idJugador"];
                        }
                        

                        ClsJugador instanciaJugador = new ClsJugador(idJugador);

                        if (miLector["puntuacionJugador"] != DBNull.Value)
                        {instanciaJugador.PuntuacionJugador = (int)miLector["puntuacionJugador"];
                        }

                        if (miLector["nombreJugador"] != DBNull.Value)
                        {
                            instanciaJugador.NombreJugador = (String)miLector["nombreJugador"];
                        }
                        

                        listadoJugadores.Add(instanciaJugador);
                    }

                    ClsConexion.cerrarConexion(ref miConexion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo acceder a la base de datos para obtener una lista de todos los jugadores", ex);
            }
            finally
            {
                ClsConexion.cerrarConexion(ref miConexion);
            }
            return listadoJugadores;
        }
        /// <summary>
        /// Función que traerá un objeto de tipo 'ClsJugador' con todos los datos que tengamos en la Base de Datos
        /// PRE: None
        /// POST: Si no hay datos el 'ClsJugador' será NULL. Posibles estados: ClsJugador/Null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ClsJugador obtenerJugadorPorIDDAL(int id)
        {

            // ESTO LO ESTOY HACIENDO POR PRACTICAR

            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            ClsJugador jugadorObtenido = null;
            int idJugador = 0;
            int puntuacion = 0;
            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.CommandText = " SELECT * FROM Jugador WHERE idJugador = @id;";
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                miComando.Connection = miConexion;
   
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        if (miLector["idJugador"] != DBNull.Value)
                        {
                            idJugador = (int)miLector["idJugador"];
                        }
                        
                        jugadorObtenido = new ClsJugador(idJugador);

                        if (miLector["puntuacionJugador"] != DBNull.Value)
                        {
                            jugadorObtenido.PuntuacionJugador = (int)miLector["puntuacionJugador"];
                        }

                        if (miLector["nombreJugador"] != DBNull.Value)
                        {
                            jugadorObtenido.NombreJugador = (String)miLector["nombreJugador"];
                        }

                    }
                }


            }catch(Exception ex)
            {
                throw new Exception("No se pudo obtener el usuario que has tratado de obtener", ex);
            }
            finally
            {
                ClsConexion.cerrarConexion(ref miConexion);
            }
            return jugadorObtenido;
        }
    }
}
