
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClsPartida // esto casi que es mi VM
    {
        #region Atributos

        // (58)? viene de totales 
        private ObservableCollection<ClsPersonajeDBZ> listadoPersonajesCorrectos;

        // (20)? viene de totales
        private ObservableCollection<ClsPersonajeDBZ> listadoPersonajesAleatorios; 

        // en la partida tengo que comprobar en el VM que la respuesta sea igual a pregunta.personajeCorrecto
        private ObservableCollection<ClsPregunta> listadoPreguntas; // monto las preguntas con la lista del total 

        #endregion

        #region Propiedades
        public ObservableCollection<ClsPersonajeDBZ> ListadoPersonajesAleatorios
        {
            get { return listadoPersonajesAleatorios; }

        }
        public ObservableCollection<ClsPersonajeDBZ> ListadoPersonajesCorrectos
        {
            get { return listadoPersonajesCorrectos; }

        }
        public ObservableCollection<ClsPregunta> ListadoPreguntas
        {
            get { return listadoPreguntas; }
        }
      

        #endregion

        #region Constructores
        public ClsPartida()
        {
            listadoPersonajesAleatorios = new ObservableCollection<ClsPersonajeDBZ>();
            listadoPersonajesCorrectos = new ObservableCollection<ClsPersonajeDBZ>();
            listadoPreguntas = new ObservableCollection<ClsPregunta>();
        }

        #endregion

        #region MontarPartida
        public async Task montarPartida()
        {
            // 1 llenamos los listados
            await cargarListados();
            // 2 creamos 20 preguntas
            await crearPreguntas(ListadoPersonajesAleatorios, ListadoPersonajesCorrectos);

        }
       
        

        #region Crear lista de preguntas
        /// <summary>
        /// Función que recibe un objeto 'ObservableCollection<ClsPersonajeDbz> donde tendremos todos los datos recogidos aleatoriamente', y otro listado 'ObservableCollection<ClsPersonajeDBZ> que tendrá solo las 
        /// opciones correctas para toda la partida'
        /// PRE: listadoAleatorio y listadoCorrecto deben tener contenido, sino no hará nada
        /// POST: Tendremos una lista de preguntas con 3 opciones que no coincidirán con la respuesta correcta + la respuesta correcta en nuestra 'listaPreguntas'
        /// </summary>
        /// <param name="listadoAleatorio"></param>
        /// <param name="listadoCorrecto"></param>
        /// <returns></returns>
        private async Task crearPreguntas(ObservableCollection<ClsPersonajeDBZ> listadoAleatorio, ObservableCollection<ClsPersonajeDBZ> listadoCorrecto)
        {
            Random rnd = new Random();
            int indice = 0;
            ClsPregunta nuevaPregunta;

            foreach (ClsPersonajeDBZ personajeCorrecto in listadoCorrecto)
            {
                // Como funciona el Where: De la lista cuando el personaje es distinto de personajeCorrecto coje 3
                nuevaPregunta = new ClsPregunta(new ObservableCollection<ClsPersonajeDBZ>(listadoAleatorio.Where(personajePregunta => personajePregunta != personajeCorrecto).Take(3)), personajeCorrecto);
                nuevaPregunta.Opciones.Add(personajeCorrecto);
                

                // pa que no tengan el mismo orden las opciones todo el rato y la correcta este al final
                mezclarLista(nuevaPregunta.Opciones);
                // mezclamos para coger otros 3 distintos
                mezclarLista(listadoAleatorio);
                listadoPreguntas.Add(nuevaPregunta);
            }


        }
        #endregion

        #region Cargar Listas (aleatoria, correcta)
        /// <summary>
        /// Funcion que va a recibir un listado con todos los personajes en 'listadoPersonajesAleatorios' que vendrá de una API
        /// PRE: La API debe darnos un resultado
        /// POST: 'listadoPersonajesAleatorios' tendrá un nuevo valor al terminar la ejecución
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task cargarListados()
        {
            Random rnd = new Random();
            int indice = 0;

            try
            {
                listadoPersonajesAleatorios = await rellenarListado(); // Listado con 58 valores

                while (listadoPersonajesCorrectos.Count() < 20)
                {
                    indice = rnd.Next(0, listadoPersonajesAleatorios.Count());

                    if (!listadoPersonajesCorrectos.Contains(listadoPersonajesAleatorios[indice])) // SI el listado NO TIENE un objeto ClsPersonajeDBZ como el que vemos en listadoPersonajesAleatorios[indice]
                    {
                        listadoPersonajesCorrectos.Add(listadoPersonajesAleatorios[indice]); // Lo guardamos
                    }
                }



            }
            catch (Exception ex)
            {
                throw new Exception("Error al rellenar las listas");
            }
        }
        #endregion

        #region Rellenar listas de la clase
        /// <summary>
        /// Funcion que literalmente llama a la BL para aplicar reglas de negocio sobre la DAL para recibir la lista de personajesCompleta de la API
        /// </summary>
        /// <returns></returns>
        public static async Task<ObservableCollection<ClsPersonajeDBZ>> rellenarListado()
        {
            ObservableCollection<ClsPersonajeDBZ> listadoPersonajes = new ObservableCollection<ClsPersonajeDBZ>(await BL.ListadoPersonajesBL.getAllPersonajesBL());

            return listadoPersonajes;

        }

        #endregion

        #region Función para mezclar listas
        private void mezclarLista(ObservableCollection<ClsPersonajeDBZ> listaParaMezclar)
        {
            Random rnd = new Random();
            int indice = listaParaMezclar.Count();
            int posicionMezcla;
            ClsPersonajeDBZ personajeApoyo;

            while (indice > 1)
            {
                indice--;
                posicionMezcla = rnd.Next(indice + 1);
                personajeApoyo = listaParaMezclar[posicionMezcla];
                listaParaMezclar[posicionMezcla] = listaParaMezclar[indice];
                listaParaMezclar[indice] = personajeApoyo;

            }
        }
        #endregion

        #endregion
    }
}
