using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Función que hará una llamada a la BD y traerá un listado del tipo ClsDepartamento 
    /// </summary>
    public class ManejadoraDepartamentosDAL
    {

        public static List<ClsDepartamentos> ObtenerListadoDepartamentosCompleto()
        {
            List<ClsDepartamentos> listadoDepartamentos = new List<ClsDepartamentos>();
            SqlConnection conexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = ClsConexion.abrirConexion(); // Abrimos la conexion
                miComando.CommandText = "SELECT * FROM Departamentos"; // Le decimos que comando ejecutará
                miComando.Connection = conexion; // Le decimos al comando que conexión usará
                miLector = miComando.ExecuteReader(); // Le decimos que con El command text y la conexion que le hemos dado, que cree un lector que vaya dandonos las cosas

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        ClsDepartamentos departamentoNuevo = new ClsDepartamentos((int)miLector["ID"]);

                        if (miLector["Nombre"] != DBNull.Value)
                        {
                            departamentoNuevo.NombreDepartamento = (String)miLector["Nombre"];
                        }
                        listadoDepartamentos.Add(departamentoNuevo);
                    }
                }
                miLector.Close(); 
                ClsConexion.cerrarConexion(ref conexion); // Cerramos la conexion que se abrió anteriormente

            }
            catch (SqlException e)
            {
                throw e;
            }

            return listadoDepartamentos;

        }

    }
}
