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
        /// Función que guardará un nuevo combate en la Base de Datos, usando un objeto tipo 'ClsCombate' para pasar sus parametros a SQL
        /// PRE: El combate no debe ser NULL
        /// POST: Devuelve un Booleano que nos dictaminará si ha sido guardado con exito o no (para poder hacer futuros mensajes)
        /// </summary>
        /// <param name="combateMarvel"></param>
        /// <returns> Boolean 'guardado' = true/false </returns>
        /// <exception cref="Exception"></exception>
        public static Boolean guardarCombate(ClsCombate combateMarvel)
        {
            Boolean existe = false;
            Boolean guardado = false;

            try
            {
                existe = comprobarExistenciaCombate(combateMarvel);

                if (existe)
                {
                    if (combateMarvel.FechaCombate.Date != DateTime.Today)
                    {
                        guardado = crearCombate(combateMarvel);
                    }
                    else
                    {
                        guardado = actualizarCombate(combateMarvel);
                    }
                }
                else
                {
                    guardado = crearCombate(combateMarvel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo GUARDAR el combate", ex);
            }
            return guardado;
        }

        /// <summary>
        /// Función que actualiza un registro de la Base de Datos con unos parametros que vienen del Objeto que pasamos tipo 'ClsCombate' 
        /// </summary>
        /// <param name="peleita"></param>
        /// <returns> Boolean 'actualizado' (true or false) </returns>
        /// <exception cref="Exception"></exception>
        private static Boolean actualizarCombate(ClsCombate peleita)
        {
            Boolean actualizado = false;
            try
            {
                using (SqlConnection miConexion = ClsConexionBD.abrirConexion())
                using (SqlCommand miComando = new SqlCommand())
                {
                    miComando.Connection = miConexion;

                    // Lo que hace es setear FechaCombate y ResultadoCombatiente1 + Si el id1 = @id1 entonces puntosComb1, sino puntosComb2
                    // Y viceversa
                    miComando.CommandText = @"
                        UPDATE Combate 
                        SET 
                            FechaCombate = @fechaCombate, 
                            ResultadoCombatiente1 = ResultadoCombatiente1 +
                                CASE 
                                    WHEN IdCombatiente1 = @idCombatiente1 THEN @puntosCombatiente1
                                    ELSE @puntosCombatiente2
                                END,
                            ResultadoCombatiente2 = ResultadoCombatiente2 +
                                CASE 
                                    WHEN IdCombatiente2 = @idCombatiente2 THEN @puntosCombatiente2
                                    ELSE @puntosCombatiente1
                                END
                        WHERE 
                            (IdCombatiente1 = @idCombatiente1 AND IdCombatiente2 = @idCombatiente2)
                            OR
                            (IdCombatiente1 = @idCombatiente2 AND IdCombatiente2 = @idCombatiente1);";

                    // Selecciona las dos posibilidades de id1 = id2 o id1 = id1

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
        private static Boolean crearCombate(ClsCombate peleita)
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
        /// Función que llamará a la Base de Datos para obtener el numero de registros que coinciden con el que estamos ofreciendole. 
        /// Si hay algun combate con los 'IdCombatiente 1 & 2' entonces el combate existe si es < 0.
        /// PRE: El objeto que le pasamos por parametros NO PUEDE SER NULL
        /// POST: La respuesta que nos dará confirmará si existe un combate con los parametros que cogeremos del objeto (IdCombatiente1, IdCombatiente2) no tomara en cuenta la fecha
        /// </summary>
        /// <param name="peleita"></param>
        /// <returns> Boolean 'existe' = true/false </returns>
        /// <exception cref="Exception"></exception>
        private static Boolean comprobarExistenciaCombate(ClsCombate peleita)
        {
            Boolean existe = false;

            int numFilas = 0;

            
            try
            {
                using (SqlConnection miConexion = ClsConexionBD.abrirConexion())
                {
                    using (SqlCommand miComando = new SqlCommand())
                    {
                        miComando.Connection = miConexion;
                        miComando.CommandText = @"SELECT COUNT(*) FROM Combate
                                            WHERE (IdCombatiente1 = @idCombatiente1 AND IdCombatiente2 = @idCombatiente2)
                                            OR
                                            (IdCombatiente2 = @idCombatiente1 AND IdCombatiente2 = @idCombatiente1);";

                        // Añadimos los parametros que tiene que cojer al hacer la consulta SQL
                        miComando.Parameters.Add("@idCombatiente1", System.Data.SqlDbType.Int).Value  = peleita.IdCombatiente1;
                        miComando.Parameters.Add("@idCombatiente2", System.Data.SqlDbType.Int).Value = peleita.IdCombatiente2;


                        numFilas = (int)miComando.ExecuteScalar();
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error en la comprobación", ex);
            }
            if (numFilas != 0)
            {
                existe = true;
            }

            return existe;
        }

    }

}
