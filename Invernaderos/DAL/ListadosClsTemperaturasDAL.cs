using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadosClsTemperaturasDAL
    {
        /// <summary>
        /// Función que llama a la Base de Datos para recoger UN registro que coincida con los parametros determinados ('id' y 'fecha')
        /// PRE: El 'id' o la 'fecha' NUNCA podrán ser Null, son Primary Key
        /// POST: Nos devolvera un objeto ClsTemperatura lleno/vacio, pero nunca NULL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fecha"></param>
        /// <returns> ClsTemperatura nuevaTemperatura</returns>
        /// <exception cref="Exception"></exception>
        public static ClsTemperatura obtenerTemperaturasPorInvernaderoYFecha(int id, DateTime fecha)
        {
            SqlDataReader miLector;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();

            ClsTemperatura nuevaTemperatura = new ClsTemperatura();
            try
            {
                miConexion = ClsConexionDB.abrirConexionBD();
                miComando.Connection = miConexion;
                miComando.CommandText = @"SELECT * FROM temperaturas
                                          WHERE (idInvernadero = @idInvernadero
                                          AND fecha = @fecha);";
                miComando.Parameters.Add("@idInvernadero", System.Data.SqlDbType.Int).Value = id;
                miComando.Parameters.Add("@fecha", System.Data.SqlDbType.DateTime).Value = fecha;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {



                        // TODO: REVISAR TODOS LOS NOMBRES DE LA BASE DE DATOS PARA COMPROBAR QUE SON CORRECTOS CON LOS QUE LE ESTOY PONIENDO EN 
                        // ESTA FUNCION Y EN LA DE ListadoInvernaderos


                        nuevaTemperatura = new ClsTemperatura((int)miLector["idInvernadero"]);
                        if (miLector["fecha"] != DBNull.Value)
                        {
                            nuevaTemperatura.Fecha = (DateTime)miLector["fecha"];
                        }
                        if (miLector["temp1"] != DBNull.Value)
                        {
                            nuevaTemperatura.Temp1 = (double)miLector["temp1"];
                        }
                        if (miLector["temp2"] != DBNull.Value)
                        {
                            nuevaTemperatura.Temp2 = (double)miLector["temp2"];
                        }
                        if (miLector["temp3"] != DBNull.Value)
                        {
                            nuevaTemperatura.Temp3 = (double)miLector["temp3"];
                        }
                        if (miLector["humedad1"] != DBNull.Value)
                        {
                            nuevaTemperatura.Humedad1 = (double)miLector["humedad1"];
                        }
                        if (miLector["humedad2"] != DBNull.Value)
                        {
                            nuevaTemperatura.Humedad2 = (double)miLector["humedad2"];
                        }
                        if (miLector["humedad3"] != DBNull.Value)
                        {
                            nuevaTemperatura.Humedad3 = (double)miLector["humedad3"];
                        }

                    }

                }
                miLector.Close();
                ClsConexionDB.cerrarConexionDB(ref miConexion);
            }
            catch (SqlException ex)
            {
                throw new Exception("Ocurrió un error al REALIZAR la busqueda de las temperaturas por invernadero", ex);
            }
            return nuevaTemperatura;
        }
    }
}