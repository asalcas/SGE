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
            SqlConnection conexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();

            try
            {
                    conexion = ClsConexion.abrirConexion();
                    miComando.CommandText = "SELECT * FROM Personas";
                    miComando.Connection = conexion;
                    miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {


                    while (miLector.Read())
                    {
                        // Como nuestro ID no tiene set, hemos creado un Constructor de ClsPersona con ID por parametros para poder asignarselo :)

                        ClsPersona personaNueva = new ClsPersona((int)miLector["ID"]);

                        if (miLector["Nombre"] != DBNull.Value)
                        {
                            personaNueva.Nombre = (String)miLector["Nombre"];
                        }
                        if (miLector["Apellidos"] != DBNull.Value)
                        {
                            personaNueva.Apellidos = (String)miLector["Apellidos"];
                        }
                        if (miLector["Telefono"] != DBNull.Value)
                        {
                            personaNueva.Telefono = (String)miLector["Telefono"];
                        }
                        if (miLector["Direccion"] != DBNull.Value)
                        {
                            personaNueva.Direccion = (String)miLector["Direccion"];
                        }
                        if (miLector["Foto"] != DBNull.Value)
                        {
                            personaNueva.Foto = (String)miLector["Foto"];
                        }
                        if (miLector["FechaNacimiento"] != DBNull.Value)
                        {
                            personaNueva.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }
                        if (miLector["IDDepartamento"] != DBNull.Value)
                        {
                            personaNueva.IdDept = (int)miLector["IDDepartamento"];
                        }

                        ListadoCompletoPersonas.Add(personaNueva);

                    }
                }
                    miLector.Close();
                    ClsConexion.cerrarConexion(ref conexion);
            }
            catch (SqlException excSQL)
            {
                throw excSQL;
            }

            return ListadoCompletoPersonas;
        }
    }
}
