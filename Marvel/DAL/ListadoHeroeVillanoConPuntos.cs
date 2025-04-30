using ENT;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadoHeroeVillanoConPuntos
    {
        /// <summary>
        /// Función que llama a la BD con una consulta SQL que se traerá todos los datos de la tabla HeroeVillano con un campo más que será la suma de todos los puntos
        /// PRE: NONE
        /// POST: Recibimos un objeto nuevo que está en la Biblioteca de Clases DTO (Data Transfer Object)
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<ClsHeroeVillanoConPuntos> obtenerlistadoCompletoHeroesVillanosConPuntos()
        {
            List<ClsHeroeVillanoConPuntos> listadoCompleto = new List<ClsHeroeVillanoConPuntos> ();
            SqlConnection miConexion;
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                miConexion = ClsConexionBD.abrirConexion();
                miComando.CommandText = "SELECT " + 
                                            "personaje.IdPersonaje, " +
                                            "personaje.Nombre, " +
                                            "personaje.Foto, " +
                                            "COALESCE(SUM( " + // COALESCE funciona como: Si tengo un resultado lo uso, si no lo tengo en vez de null pondre un 0
                                                "CASE " + // Y dentro haremos un switch en el caso de que sea igual al id del combatiente 1 o el 2, sino se sumara 0
                                                    "WHEN c.IdCombatiente1 = personaje.IdPersonaje THEN c.ResultadoCombatiente1 " +
                                                    "WHEN c.IdCombatiente2 = personaje.IdPersonaje THEN c.ResultadoCombatiente2 " +
                                                    "ELSE 0 " +
                                                "END " +
                                                "), 0) AS Puntitos " +                                                 
                                        "FROM " +
                                            "HeroeVillano AS personaje " +
                                        "LEFT JOIN " + // Hacemos la conexion con los id, como puede ser uno U otro, sera con un OR
                                            "Combate c ON personaje.IdPersonaje = c.IdCombatiente1 OR personaje.IdPersonaje = c.IdCombatiente2 " +
                                        "GROUP BY " +
                                            "personaje.IdPersonaje, personaje.Nombre, personaje.Foto " +
                                        "ORDER BY " +
                                            "Puntitos DESC ";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows) 
                {
                    while (miLector.Read())
                    {

                        ClsHeroeVillano personajeSinPuntos = new ClsHeroeVillano((int)miLector["IdPersonaje"]);

                        if (miLector["Nombre"] != DBNull.Value)
                        {
                            personajeSinPuntos.Nombre = (String)miLector["Nombre"];
                        }
                        if (miLector["Foto"] != DBNull.Value)
                        {
                            personajeSinPuntos.Foto = (String)miLector["Foto"];
                        }

                        ClsHeroeVillanoConPuntos personajeConPuntos = new ClsHeroeVillanoConPuntos(personajeSinPuntos, (int)miLector["Puntitos"]);
                        listadoCompleto.Add(personajeConPuntos);

                    }


                }
                ClsConexionBD.cerrarConexion(ref miConexion);
                miLector.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error al crear la lista de personajes con puntos", ex);
            }

            return listadoCompleto;
        }

    }
}
