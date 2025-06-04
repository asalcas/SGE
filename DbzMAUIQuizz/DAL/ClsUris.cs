using DTO;
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
        /// PRE: DEBEMOS PASARLE EL NUMERO DE Personajes que queremos.
        /// POST: Devuelve solo un enlace de una pagina WEB con una paginacion especifica y un limite de 58 para que todos los personajes de la API
        /// </summary>
        /// <returns></returns>
        public static String uriAllPersonajes(int numeroPersonajes)
        {
            String uriTodosLosPersonajes = "https://dragonball-api.com/api/characters?page=1&limit=" + $"{numeroPersonajes}"; // Tengo que hacerlo asi por que la api por defecto da maximo 10 solo

            return uriTodosLosPersonajes;
        }
        /// <summary>
        /// Función que se encarga de enviar una URL para realizar la conexion con nuestra API de jugadores, con la finalidad de hacer un POST con el nombre y los puntos que haya conseguido el usuario.
        /// GET y POST
        /// PRE: None
        /// POST: Devuelve el enlace a la pagina WEB la cual realizaremos el Insert.
        /// </summary>
        /// <returns></returns>
        public static String uriJugadores()
        {
            String uriBase = "https://apiplayers-e6d5bdgphgfyhpgf.spaincentral-01.azurewebsites.net/api/jugadores";
            return uriBase;
        }

    }
}
