using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ENT;

namespace DAL
{
    public class ListadoPersonasDAL
    {
        /// <summary>
        /// Función que se encarga de recoger un Json de la API en cuestión, para mas tarde deserializarlo y obtener una lista de tipo 'ClsPersona'
        /// POST: ES UN LISTADO COMPLETO, O VACÍO
        /// </summary>
        /// <returns> List<ClsPersona> listadoPersonas </returns>
        /// <exception cref="Exception"></exception>
        public static async Task<List<ClsPersona>> getListadoPersonasCompletoDAL()
        {
            String miCadenaURL = miUri.getUriBase();
            List<ClsPersona> listadoPersonas = new List<ClsPersona>();


            Uri uriAPI = new Uri($"{miCadenaURL}Personas"); // Esta es la cadena URL que usaremos para hacer la consulta (el equivalente a 'miConexion')

            HttpClient miHttpClient; // Esto servirá para hacer la consulta web (muy parecido al 'miComando' donde le cargamos el 'miConexion')
            HttpResponseMessage miCodigoRespuesta; // Esto sirve para recibir el mensaje del servidor a la consulta en cuestion ([200 Ok], [404 Not Found]...)

            String jsonRespuesta; // Esto será lo que recogerá la consulta

            miHttpClient = new HttpClient(); // Esto es como si fuese una instanciación de un Navegador que hará la petición

            try
            {
                miCodigoRespuesta = await miHttpClient.GetAsync(uriAPI); // Se hace la petición (peticion GET)

                if (miCodigoRespuesta.IsSuccessStatusCode) // if(miCodigoRespuesta == 200)
                {
                    jsonRespuesta = await miHttpClient.GetStringAsync(uriAPI); // Guardamos el Json en nuestra variable de la peticion anterior en jsonRespuesta
                    miHttpClient.Dispose(); // Cerramos el "Navegador" para liberar memoria

                    listadoPersonas = JsonConvert.DeserializeObject<List<ClsPersona>>(jsonRespuesta); // DESERIALIZAMOS el JSON y lo convertimos en una Lista de tipo 'ClsPersona'
                }
                else
                {
                    throw new Exception("404");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el JSON en getListadoPersonasCompletoDAL", ex);
            }

            return listadoPersonas; // Lo retornamos

        }
    }
}

