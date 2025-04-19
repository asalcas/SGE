using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ManejadoraCombatesDAL
    {

        /// <summary>
        /// Función que actualiza un registro de la Base de Datos con unos parametros que vienen del Objeto que pasamos tipo 'ClsCombate' 
        /// </summary>
        /// <param name="peleita"></param>
        /// <returns> Boolean 'actualizado' (true or false) </returns>
        /// <exception cref="Exception"></exception>
        public static Boolean actualizarCombate(ClsCombate peleita)
        {
            Boolean actualizado = false;
            try
            {
                using (SqlConnection miConexion = ClsConexionBD.abrirConexion())
                using (SqlCommand miComando = new SqlCommand())
                {
                    miComando.Connection = miConexion;

                    // Me daba un problema dependiendo del orden de los ID, por lo que solución peruana, si hago la consulta de las dos formas y solo coje una
                    miComando.CommandText = @"
                        UPDATE Combate 
                        SET 
                            FechaCombate = @fechaCombate,
                            ResultadoCombatiente1 = ResultadoCombatiente1 + @puntosCombatiente1,
                            ResultadoCombatiente2 = ResultadoCombatiente2 + @puntosCombatiente2
                        WHERE IdCombatiente1 = @idCombatiente1 AND IdCombatiente2 = @idCombatiente2;

                        UPDATE Combate 
                        SET 
                            FechaCombate = @fechaCombate,
                            ResultadoCombatiente1 = ResultadoCombatiente1 + @puntosCombatiente2,
                            ResultadoCombatiente2 = ResultadoCombatiente2 + @puntosCombatiente1
                        WHERE IdCombatiente1 = @idCombatiente2 AND IdCombatiente2 = @idCombatiente1;";

                    miComando.Parameters.Add("@idCombatiente1", System.Data.SqlDbType.Int).Value = peleita.IdCombatiente1;
                    miComando.Parameters.Add("@idCombatiente2", System.Data.SqlDbType.Int).Value = peleita.IdCombatiente2;
                    miComando.Parameters.Add("@fechaCombate", System.Data.SqlDbType.Date).Value = DateTime.Today;
                    miComando.Parameters.Add("@puntosCombatiente1", System.Data.SqlDbType.Int).Value = peleita.ResultadoCombatiente1;
                    miComando.Parameters.Add("@puntosCombatiente2", System.Data.SqlDbType.Int).Value = peleita.ResultadoCombatiente2;

                    int numeroFilasAfectadas = miComando.ExecuteNonQuery();
                    actualizado = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al actualizar un combate", ex);
            }


            return actualizado;
        }
        /// <summary>
        /// Función que crea un nuevo Registro en la Base de datos a partir del objeto tipo 'ClsCombate'
        /// PRE: El objeto no puede ser NULL
        /// POST: Devolveremos solo un Booleano para saber si ha salido correctamente
        /// </summary>
        /// <param name="peleita"></param>
        /// <returns> Boolean 'creado' = true/false </returns>
        /// <exception cref="Exception"></exception>
        public static Boolean crearCombate(ClsCombate peleita)
        {
            Boolean creado = false;
            try
            {
                // Probando otra forma de hacerlo, que en teoria es mas limpia y moderna, preguntar a Fernando, no tengo que hacer finally ni cerrar la conexion por que se cierra sola
                using (SqlConnection miConexion = ClsConexionBD.abrirConexion())
                using (SqlCommand miComando = new SqlCommand())
                {
                    miComando.Connection = miConexion;
                    miComando.CommandText = "INSERT INTO Combate(IdCombatiente1, IdCombatiente2, FechaCombate, ResultadoCombatiente1, ResultadoCombatiente2) " +
                                        "VALUES (@idCombatiente1,@idCombatiente2,@fechaCombate,@puntosCombatiente1, @puntosCombatiente2);";

                    miComando.Parameters.Add("@idCombatiente1", System.Data.SqlDbType.Int).Value = peleita.IdCombatiente1;
                    miComando.Parameters.Add("@idCombatiente2", System.Data.SqlDbType.Int).Value = peleita.IdCombatiente2;
                    miComando.Parameters.Add("@fechaCombate", System.Data.SqlDbType.Date).Value = DateTime.Today;
                    miComando.Parameters.Add("@puntosCombatiente1", System.Data.SqlDbType.Int).Value = peleita.ResultadoCombatiente1;
                    miComando.Parameters.Add("@puntosCombatiente2", System.Data.SqlDbType.Int).Value = peleita.ResultadoCombatiente2;

                    miComando.ExecuteNonQuery();
                    creado = true;
                }
                // ClsConexionBD.cerrarConexion(ref miConexion); <------ No es necesario
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear un combate", ex);
            }


            return creado;
        }

        /// <summary>
        /// Función que llamará a la Función de 'obtenerListadoCompleto' de la clase ListadosCombatesDAL, y comprueba que el objeto tipo 'ClsCombate' que le pasamos existe o no.
        /// PRE: El objeto que le pasamos por parametros NO PUEDE SER NULL
        /// POST: La respuesta que nos dará confirmará si existe un combate con los parametros que cogeremos del objeto (IdCombatiente1, IdCombatiente2) no tomara en cuenta la fecha
        /// </summary>
        /// <param name="peleita"></param>
        /// <returns> Boolean 'existe' = true/false </returns>
        /// <exception cref="Exception"></exception>
        public static Boolean comprobarExistenciaCombate(ClsCombate peleita)
        {
            Boolean existe = false;
            List<ClsCombate> listaCombatesComprobar = new List<ClsCombate>();
            ClsCombate? combateBuscado = new ClsCombate();
            try
            {
                listaCombatesComprobar = DAL.ListadosCombatesDAL.obtenerListadoCombatesCompleto();
                combateBuscado = listaCombatesComprobar.Find(pelea =>
                ((pelea.IdCombatiente1 == peleita.IdCombatiente1) && (pelea.IdCombatiente2 == peleita.IdCombatiente2)) ||
                ((pelea.IdCombatiente1 == peleita.IdCombatiente2) && (pelea.IdCombatiente2 == peleita.IdCombatiente1))
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error en la comprobación", ex);
            }
            if (combateBuscado != null)
            {
                existe = true;
            }

            return existe;
        }

    }

}
