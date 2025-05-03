using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadosInvernaderosDAL
    {
        /// <summary>
        /// Función que se encarga de llamar a la base de datos para poder traerse una lista de objetos tipo ClsInvernaderos.
        /// PRE: NONE
        /// POST: La lista del tipo ClsInvernadero SIEMPRE será completa
        /// </summary>
        /// <returns> List<ClsInvernadero> listaDeInvernaderos </returns>
        /// <exception cref="Exception"></exception>
        public static List<ClsInvernadero> obtenerListadoCompletoInvernaderosDAL()
        {

            List<ClsInvernadero> listaDeInvernaderos = new List<ClsInvernadero>();

            SqlConnection miConexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion = ClsConexionDB.abrirConexionBD();
                miComando.Connection = miConexion;
                miComando.CommandText = "SELECT * FROM invernaderos;";
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {

                        ClsInvernadero nuevoInvernadero = new ClsInvernadero((int)miLector["idInvernadero"]);
                        if (miLector["nombre"] != DBNull.Value)
                        {
                            nuevoInvernadero.Nombre = (String)miLector["nombre"];
                        }

                        listaDeInvernaderos.Add(nuevoInvernadero);

                    }
                }
                miLector.Close();
                ClsConexionDB.cerrarConexionDB(ref miConexion);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al obtener el listado completo de invernaderos DAL", ex);
            }

            return listaDeInvernaderos;
        }
        /// <summary>
        /// Función que se encarga de llamar a la base de datos para poder traerse un objeto tipo ClsInvernadero.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ClsInvernadero obtenerInvernaderoPorId(int id)
        {
            ClsInvernadero invernaderoBuscado;
            SqlConnection miConexion = new SqlConnection();
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion = ClsConexionDB.abrirConexionBD();
                miComando.Connection = miConexion;
                miComando.CommandText = "SELECT * FROM invernaderos WHERE idInvernadero = @idInvernadero;";
                miComando.Parameters.Add("@idInvernadero", System.Data.SqlDbType.Int).Value = id;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    miLector.Read();
                    invernaderoBuscado = new ClsInvernadero((int)miLector["idInvernadero"]);
                    if (miLector["nombre"] != DBNull.Value)
                    {
                        invernaderoBuscado.Nombre = (String)miLector["nombre"];
                    }
                }
                else
                {
                    invernaderoBuscado = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el invernadero por id", ex);
            }
            finally
            {
                ClsConexionDB.cerrarConexionDB(ref miConexion);

            }
            return invernaderoBuscado;

        }
    }
}
