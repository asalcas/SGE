using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadosCombatesDAL
    {
        /// <summary>
        /// Funcion que obtendrá de la Base de Datos una lista completa de objetos tipo "ClsCombate"
        /// PRE: None
        /// POST: El listado que recibe siempre sera COMPLETO
        /// </summary>
        /// <returns> List<ClsCombate> listadoCompletoCombates </returns>
        /// <exception cref="Exception"></exception>
        public static List<ClsCombate> obtenerListadoCombatesCompleto()
        {

            List<ClsCombate> listadoCompletoCombates = new List<ClsCombate>();
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miConexion = ClsConexionBD.abrirConexion();
                miComando.CommandText = "SELECT * FROM Combate";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {

                        ClsCombate combateNuevo = new ClsCombate();
                        if (miLector["IdCombatiente1"] != DBNull.Value)
                        {
                            combateNuevo.IdCombatiente1 = (int)miLector["IdCombatiente1"];
                        }
                        if (miLector["IdCombatiente2"] != DBNull.Value)
                        {
                            combateNuevo.IdCombatiente2 = (int)miLector["IdCombatiente2"];
                        }
                        if (miLector["FechaCombate"] != DBNull.Value)
                        {
                            combateNuevo.FechaCombate = (DateTime)miLector["FechaCombate"];
                        }
                        if (miLector["ResultadoCombatiente1"] != DBNull.Value)
                        {
                            combateNuevo.ResultadoCombatiente1 = (int)miLector["ResultadoCombatiente1"];
                        }
                        if (miLector["ResultadoCombatiente2"] != DBNull.Value)
                        {
                            combateNuevo.ResultadoCombatiente2 = (int)miLector["ResultadoCombatiente2"];
                        }

                        listadoCompletoCombates.Add(combateNuevo);
                    }
                }

                ClsConexionBD.cerrarConexion(ref miConexion);
                miLector.Close();

            }
            catch (SqlException ex)
            {
                throw new Exception("No se ha podido obtener la lista completa de Combates", ex);

            }

            return listadoCompletoCombates;

        }
    }
}
