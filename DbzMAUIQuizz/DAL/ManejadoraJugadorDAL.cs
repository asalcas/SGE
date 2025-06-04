using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManejadoraJugadorDAL
    {
        public async Task<HttpStatusCode> insertarPuntuacionJugadorDAL(ClsJugador jugador)
        {
            HttpClient miNavegador = new HttpClient();
            string datosIntroducir;
            HttpContent contenido;

            String miCadenaUri = ClsUris.uriInsercionJugadores();
            Uri miUri = new Uri(miCadenaUri);

            HttpResponseMessage respuestaObtenida = new HttpResponseMessage();
            try
            {
                datosIntroducir = JsonConvert.SerializeObject(jugador);
                contenido = new StringContent(datosIntroducir, System.Text.Encoding.UTF8,"application/json");
                respuestaObtenida = await miNavegador.PostAsync(miUri, contenido);
            }
            catch (Exception ex) 
            {
                throw new Exception("No se pudo insertar la puntuación del jugador", ex);
            }
            return respuestaObtenida.StatusCode;
        }
    }
}
