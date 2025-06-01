using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class ListadoPersonajesDAL
    {
        public static async Task<List<ClsPersonajeDBZ>>getAllPersonajesDAL()
        {
            String miEnlace = ClsUris.uriAllPersonajes();
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
                    var objetoJson = JObject.Parse(textoJsonRespuesta);

                    listadoPersonajesDBZ = objetoJson["items"].ToObject<List<ClsPersonajeDBZ>>();
                    // TENGO UN ERROR AL DESERIALIZAR DESDE LA API, por que no son objetos, es un array de objetos
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener la lista de Personajes");
            }
            return listadoPersonajesDBZ;
        }

    }
}
