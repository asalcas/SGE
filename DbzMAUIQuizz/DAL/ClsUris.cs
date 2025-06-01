using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ClsUris
    {
        /// <summary>
        /// Función que se encarga de enviar una URL para realizar la conexion a la API, para hacer el GET de Characters.
        /// PRE: None
        /// POST: Devuelve solo un enlace de una pagina WEB con una paginacion especifica y un limite de 58 para que todos los personajes de la API
        /// </summary>
        /// <returns></returns>
        public static String uriAllPersonajes()
        {
            String uriTodosLosPersonajes = "https://dragonball-api.com/api/characters?page=1&limit=58"; // Tengo que hacerlo asi por que la api por defecto da maximo 10 solo

            return uriTodosLosPersonajes;
        }

    }
}
