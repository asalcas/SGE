using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DAL
{
    public class ListadoRankingJugadoresDAL
    {
        /// <summary>
        /// Función que se encarga de pedir de una API un listado de jugadores y ordenarlo antes de devolverlo. Alteré la API para que el listado que me de, esté ordenado
        /// PRE: La dirección tiene que ser válida
        /// POST: El listado estará ORDENADO de mayor a MENOR
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsJugador>> obtenerListadoCompletoJugadoresOrdenados()
        {
            String miUriString = ClsUris.uriJugadores(); // El enlace que tenemos en ClsUris que corresponde a nuestra API
            Uri miEnlace = new Uri(miUriString); // Montamos el enlace en nuestro objeto URI

            List<ClsJugador> listadoOrdenadoJugadores = new List<ClsJugador>(); // Declaramos una lista de objetos tipo "ClsJugador" vacía para darle valor mas tarde
            HttpClient miNavegador = new HttpClient(); // Instanciamos un "navegador"

            HttpResponseMessage miCodigoRespuesta; // Variable donde guardaremos para el codigo de respuesta

            String textoJsonRespuesta; // Variable donde Guardaremos el resultado de lo que de la llamada a la API

            try
            {
                miCodigoRespuesta = await miNavegador.GetAsync(miEnlace);

                if(miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await miNavegador.GetStringAsync(miEnlace);
                    miNavegador.Dispose();

                    listadoOrdenadoJugadores = JsonConvert.DeserializeObject<List<ClsJugador>>(textoJsonRespuesta);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("No se pudo acceder al listado ordenado de jugadores", ex);
            }
            return listadoOrdenadoJugadores;
        }

    }
}
