using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListaPersonasDAL
    {
        /// <summary>
        /// Función que retorna un Listado de personas cogiendolo de la BD
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> ObtenerListadoCompletoPersonasDAL()
        {
            List<ClsPersona> ListadoCompletoPersonas = new List<ClsPersona>();
            SqlConnection miConexion = new SqlConnection();
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion.ConnectionString = "server=alvaro-salvador.database.windows.net;database=alvaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
                
                    miConexion.Open();
                    miComando.CommandText = "SELECT * FROM Personas";
                    miComando.Connection = miConexion;
                    miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {


                    while (miLector.Read())
                    {
                        // Como nuestro DNI no tiene set, hemos creado un Constructor de ClsPersona con ID por parametros para poder asignarselo :)

                        ClsPersona personaNueva = new ClsPersona((String)miLector["DNI"]);

                        if(miLector["Nombre"] != DBNull.Value)
                        {
                            personaNueva.Nombre = (String)miLector["Nombre"];
                        }
                        if (miLector["Apellido"] != DBNull.Value)
                        {
                            personaNueva.Apellido = (String)miLector["Apellido"];
                        }
                        if (miLector["Sexo"] != DBNull.Value)
                        {
                            personaNueva.Sexo = (String)miLector["Sexo"];
                        }
                        if (miLector["FechaNacimiento"] != DBNull.Value)
                        {
                            personaNueva.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }

                        ListadoCompletoPersonas.Add(personaNueva);

                    }
                }
                    miLector.Close();
                    miConexion.Close();
            }
            catch (SqlException excSQL)
            {
                throw excSQL;
            }

            return ListadoCompletoPersonas;
        }
    }
}
