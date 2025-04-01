using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListaPersonasDAL
    {
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

                    while (miLector.Read())
                    {
                        ClsPersona personaNueva = new ClsPersona();
                        personaNueva.DNI = (String)miLector["DNI"];
                        personaNueva.Nombre = (String)miLector["Nombre"];
                        personaNueva.Apellido = (String)miLector["Apellido"];
                        personaNueva.Sexo = (String)miLector["Sexo"];
                        personaNueva.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        ListadoCompletoPersonas.Add(personaNueva);

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
