using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class ListadoPersonajesDAL
    {
        /// <summary>
        /// Funcion que traerá una lista de N número de personajes de la API de Dragon Ball
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<ClsPersonajeDBZ>>getAllPersonajesDAL()
        {
            String miEnlace = ClsUris.uriAllPersonajes(58);
            Uri miUri = new Uri(miEnlace);
            List<ClsPersonajeDBZ> listadoPersonajesDBZ = new List<ClsPersonajeDBZ>();
            HttpClient miNavegador;

            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;

            miNavegador = new HttpClient();

            try
            {
                miCodigoRespuesta = await miNavegador.GetAsync(miEnlace);

                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await miNavegador.GetStringAsync(miEnlace);
                    JObject objetoJson = JObject.Parse(textoJsonRespuesta);

                    miNavegador.Dispose();

                    listadoPersonajesDBZ = objetoJson["items"].ToObject<List<ClsPersonajeDBZ>>();
                    // TENGO UN ERROR AL DESERIALIZAR DESDE LA API, por que no son objetos, es un array de objetos
                }
                else if (miCodigoRespuesta.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception("404");
                }
                else if(miCodigoRespuesta.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new Exception("400");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al solicitar las lista de personajes. Codigo de Error: " + ex.Message);
            }
            return listadoPersonajesDBZ;
        }

    }
}
