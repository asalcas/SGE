using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ManejadoraPersonasDAL
    {
        /// <summary>
        /// Función que retorna un Listado de personas cogiendolo de la BD
        /// Pre: Conexion a la BD
        /// Post: Ofrece una lista COMPLETA
        /// </summary>
        /// <returns> List<ClsPersona> listadoCompletoPersonas </returns>
        public static List<ClsPersona> ObtenerListadoCompletoPersonasDAL()
        {
            List<ClsPersona> listadoCompletoPersonas = new List<ClsPersona>();
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

                        listadoCompletoPersonas.Add(personaNueva);

                    }
                }
                miLector.Close();
                ClsConexion.cerrarConexion(ref conexion);
            }
            catch (SqlException excSQL)
            {
                throw excSQL;
            }

            return listadoCompletoPersonas;
        }

        /// <summary>
        /// Función que retorna una Persona en base a su ID
        /// Pre: Tenemos que pasar un ID válido, NO PUEDE SER NULO
        /// Post: Siempre devuelve una Persona
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns> Una ClsPersona </returns>
        public static ClsPersona buscarPersonaPorID(int idPersona)
        {

            SqlConnection miConexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@idPersona", System.Data.SqlDbType.Int).Value = idPersona;



            ClsPersona personaObtenida = null; // Inicializo en null para poder darle valor del ID dentro de la lectura

            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.CommandText = "SELECT * FROM Personas WHERE ID = @idPersona;";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();


                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        personaObtenida = new ClsPersona((int)miLector["ID"]); // Aquí

                        if (miLector["Nombre"] != DBNull.Value)
                        {
                            personaObtenida.Nombre = (String)miLector["Nombre"];
                        }
                        if (miLector["Apellidos"] != DBNull.Value)
                        {
                            personaObtenida.Apellidos = (String)miLector["Apellidos"];
                        }
                        if (miLector["Telefono"] != DBNull.Value)
                        {
                            personaObtenida.Telefono = (String)miLector["Telefono"];
                        }
                        if (miLector["Direccion"] != DBNull.Value)
                        {
                            personaObtenida.Direccion = (String)miLector["Direccion"];
                        }
                        if (miLector["Foto"] != DBNull.Value)
                        {
                            personaObtenida.Foto = (String)miLector["Foto"];
                        }
                        if (miLector["FechaNacimiento"] != DBNull.Value)
                        {
                            personaObtenida.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }
                        if (miLector["IDDepartamento"] != DBNull.Value)
                        {
                            personaObtenida.IdDept = (int)miLector["IDDepartamento"];
                        }

                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }


            return personaObtenida;
        }

        /// <summary>
        /// Función que editará un registro de un registro en la BD
        /// Pre: Siempre debemos pasar una Persona, NO PUEDE SER NULO
        /// Post: Siempre devuelve un Booleano.
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public static Boolean editarPersonaBD(ClsPersona personaParaEditar)
        {
            Boolean actualizado = false;
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();


            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.Connection = miConexion;
                miComando.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = personaParaEditar.ID;
                miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = personaParaEditar.Nombre;
                miComando.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = personaParaEditar.Apellidos;
                miComando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = personaParaEditar.Telefono;
                miComando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = personaParaEditar.Direccion;
                miComando.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar).Value = personaParaEditar.Foto;
                miComando.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime).Value = personaParaEditar.FechaNacimiento;
                miComando.Parameters.Add("@IDDepartamento", System.Data.SqlDbType.Int).Value = personaParaEditar.IdDept;

                miComando.CommandText = "UPDATE Personas SET " +
                    "Nombre = @Nombre, " +
                    "Apellidos = @Apellidos, " +
                    "Telefono = @Telefono, " +
                    "Direccion = @Direccion, " +
                    "Foto = @Foto, " +
                    "FechaNacimiento = @FechaNacimiento, " +
                    "IDDepartamento = @IDDepartamento " +
                    "WHERE " +
                    "ID = @ID;";

                numeroFilasAfectadas = miComando.ExecuteNonQuery();

                if (numeroFilasAfectadas > 0)
                {
                    actualizado = true;
                }
                ClsConexion.cerrarConexion(ref miConexion);

            }
            catch (SqlException e)
            {
                throw e;
            }



            return actualizado;
        }

        /// <summary>
        /// Función que elimina una persona de la BD a través de su ID
        /// Pre: Debe tener un ID válido
        /// Post: NONE
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Booleano que nos dice si ha pasado o no para posibles mensajes </returns>
        public static Boolean eliminarPersonaDBDAL(int id)
        {
            Boolean borrado = false;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                miComando.CommandText = "DELETE FROM Personas WHERE ID = @ID";
                miComando.Connection = miConexion;
                miComando.ExecuteNonQuery();

                miConexion.Close();
                borrado = true;
             
            } catch(SqlException e)
            {
                throw e;
            }


            return borrado;
        }

        /// <summary>
        /// Función que se encarga de Introducir una nueva Persona a la BD
        /// Pre: @Nombre y @Apellido NO PUEDEN SER NULL
        /// Post: None
        /// </summary>
        /// <param name="personaNueva"></param>
        /// <returns>Booleano que nos dice si hemos introducido o no el nuevo Registro</returns>
        public static Boolean insertarPersonaDAL(ClsPersona personaNueva)
        {
            Boolean insertado = false;
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = personaNueva.Nombre;
            miComando.Parameters.Add("@Apellidos", System.Data.SqlDbType.VarChar).Value = personaNueva.Apellidos;
            miComando.Parameters.Add("@Telefono", System.Data.SqlDbType.VarChar).Value = personaNueva.Telefono;
            miComando.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar).Value = personaNueva.Direccion;
            miComando.Parameters.Add("@Foto", System.Data.SqlDbType.VarChar).Value = personaNueva.Foto;
            miComando.Parameters.Add("@FechaNacimiento", System.Data.SqlDbType.DateTime).Value = personaNueva.FechaNacimiento;
            miComando.Parameters.Add("@IDDepartamento", System.Data.SqlDbType.Int).Value = personaNueva.IdDept;

            try
            {
                miConexion = ClsConexion.abrirConexion();
                miComando.CommandText = "INSERT INTO Personas (Nombre, Apellidos, Telefono, Direccion, Foto, FechaNacimiento, IDDepartamento) VALUES" +
                    "(@Nombre, @Apellidos, @Telefono, @Direccion, @Foto, @FechaNacimiento, @IDDepartamento)";
                miComando.Connection = miConexion;
                miComando.ExecuteNonQuery();

                ClsConexion.cerrarConexion(ref miConexion);
                insertado = true;

            }catch(SqlException e)
            {
                throw e;
            }

            return insertado;
        }
    }
}
