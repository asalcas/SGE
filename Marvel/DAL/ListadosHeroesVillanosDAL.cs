using ENT;
using Microsoft.Data.SqlClient;
namespace DAL
{
    public class ListadosHeroesVillanosDAL
    {

        /// <summary>
        /// Funcion que obtendrá de la Base de Datos una lista completa de objetos tipo "ClsHeroeVillano"
        /// PRE: None
        /// POST: El listado que recibe siempre sera COMPLETO
        /// </summary>
        /// <returns> List<ClsHeroeVillano> listadoCompletoHeroesVillano </returns>
        /// <exception cref="Exception"></exception>
        public static List<ClsHeroeVillano> obtenerListadoCompleto()
        {
            // Listado que posteriormente voy a rellenar de objetos 'ClsHeroeVillano'
            List<ClsHeroeVillano> listadoCompletoHeroesVillanos = new List<ClsHeroeVillano>();

            // Declaro mis objetos 'SqlConnection' y 'SqlDataReader'
            SqlConnection miConexion;
            SqlDataReader miLector;

            // Declaro e instancio el objeto SqlCommand vacío. ¿Por qué? Por que dentro del Try
            // estoy tratando de darle valores a sus "Propiedades" por lo que debemos de instanciarlo vacío previamente
            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion = ClsConexionBD.abrirConexion();
                miComando.CommandText = "SELECT * FROM HeroeVillano;";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        // Instanciamos un objeto 'ClsHeroeVillano' con un Id, ya que su ID no tiene SET
                        ClsHeroeVillano personajeNuevo = new ClsHeroeVillano((int)miLector["IdPersonaje"]);

                        // Rellenamos el objeto
                        if (miLector["Nombre"] != DBNull.Value)
                        {
                            personajeNuevo.Nombre = (String)miLector["Nombre"];
                        }
                        if (miLector["Foto"] != DBNull.Value)
                        {
                            personajeNuevo.Foto = (String)miLector["Foto"];
                        }

                        // Lo introducimos en la lista
                        listadoCompletoHeroesVillanos.Add(personajeNuevo);
                    }
                }

                ClsConexionBD.cerrarConexion(ref miConexion);
                miLector.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Ha ocurrido un error al obtener la lista desde la Base de Datos", ex);
            }
            // Creamos un objeto tipo ClsHeroeVillano vacío con un texto genérico en el campo nombre
            ClsHeroeVillano seleccionPredeterminada = new ClsHeroeVillano(0, "Seleccione un Heroe");

            // Añadimos ese objeto predeterminado en el indice 0
            //listadoCompletoHeroesVillanos.Insert(0, seleccionPredeterminada);

            return listadoCompletoHeroesVillanos;
        }

      
    }
}
