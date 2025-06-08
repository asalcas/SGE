
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    #region Que es mi ClsPartida?
    /* Como mi ClsPartida es practicamente un paso intermedio entre mi VM y las preguntas, TODO lo que es logica lo tratare aquí y solo dejaré en el VM 
     * las conexiones con la interfaz
    */
    #endregion
    public class ClsPartida : INotifyPropertyChanged
    {
        #region Atributos

        private ObservableCollection<ClsPersonajeDBZ> listadoPersonajesCorrectos; // (58)? viene de totales 

        private ObservableCollection<ClsPersonajeDBZ> listadoPersonajesAleatorios;  // (20)? viene de totales

        private ObservableCollection<ClsPregunta> listadoPreguntas; // Montado con 1 objeto 'ClsPersonajeDBZ' y una 'List<ClsPersonajeDBZ> opciones'

        private Boolean respondido = false;

        private int indicePregunta; // Necesito usarla como variable de la clase, por que sino todo el rato se me reiniciaria a 0

        // Interacciones en el VM:

        private ClsPregunta preguntaActual;

        private int segundosPorPregunta;

        private int puntosTotales;

        private Boolean colorear;

        private Boolean partidaAcabada;

        // --------------------------------

        public event PropertyChangedEventHandler? PropertyChanged;

        private IDispatcherTimer espera;

        private IDispatcherTimer cuentaAtras;

        #region Explicación de: 'SegundosPorPregunta' y 'puntosTotales' en 'ClsPartida'

        /* - TIEMPO:
         *  No me gusta tratar los segundos desde pregunta, por que dentro de una partida no vamos a tener ninguna pregunta con tiempos desiguales,
         *  si tuvieramos que cambiar algun tiempo, sería un ajuste de la partida, llamemoslo 'Dificultad', 'Nivel' o como sea, según mi punto de vista lo veo
         *  totalmente dependiente a la partida, y no a la pregunta, quizá por eso no me entra tanto en la pregunta.
         * - PUNTUACION:
         *  Me pasa lo mismo que con el tiempo, una pregunta aislada no tiene una puntuación para mi, al final lo que tarda es su puntuación, por lo que para que darle
         *  puntuación individual, si ya podriamos coger la puntuación sumada?
         */
        #endregion

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

        public ClsPregunta PreguntaActual
        {
            get { return preguntaActual; }
        }

        public int SegundosPorPregunta
        {
            get { return segundosPorPregunta; }
        }
        public int PuntosTotales
        {
            get { return puntosTotales; }
        }

        public int IndicePregunta
        {
            get { return indicePregunta; }
        }

        public Boolean Colorear
        {
            get { return PreguntaActual.EsCorrecto; }
        }

        public Boolean PartidaAcabada
        {
            get { return partidaAcabada; }
        }

        #endregion

        #region Constructores
        public ClsPartida()
        {
            listadoPersonajesAleatorios = new ObservableCollection<ClsPersonajeDBZ>();
            listadoPersonajesCorrectos = new ObservableCollection<ClsPersonajeDBZ>();
            listadoPreguntas = new ObservableCollection<ClsPregunta>();
            preguntaActual = new ClsPregunta();
            segundosPorPregunta = 5;



            // Timer para restar -1 a segundosPorPregunta y comprueba la interacción del usuario
            cuentaAtras = Application.Current.Dispatcher.CreateTimer();
            cuentaAtras.Interval = TimeSpan.FromSeconds(1.25);
            cuentaAtras.Tick += restarTiempoYComprobarRespuesta;

          

        }

        #endregion

        #region Comenzar una partida

        public async Task empezarPartida()
        {
            indicePregunta = 0;
            if (listadoPreguntas.Any())
            {
                preguntaActual = listadoPreguntas[indicePregunta];
                OnPropertyChanged(nameof(PreguntaActual));
                //jugarPregunta.Start();
                jugarPregunta();
            }
        }

        #endregion

        #region Logica JUGAR PARTIDA
        private void jugarPregunta()
        {
            // 1 damos un valor a segundosPorPregunta = 5, como variable de clase para que en 'cuentaAtras' vaya restandole
            segundosPorPregunta = 5;
            respondido = false;
            cuentaAtras.Start();
        }

        /// <summary>
        /// Función que se encargará de hacer una cuenta atrás de 'N' numero de segundos a 0 y de comprobar la respuesta del usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restarTiempoYComprobarRespuesta(object sender, EventArgs e)
        {

            bool acierto = false;

            if (respondido)
            {
                cuentaAtras.Stop();
                pasarPregunta();
            }
            else
            {
                if (preguntaActual.PersonajeSeleccionado != null) // Si el valor del 'preguntaActual.PersonajeSeleccionado' cambia
                {
                    respondido = true; // El usuario ha respondido
                    acierto = preguntaActual.comprobarEsCorrecto(); // Comprobamos que ha acertado o no

                    if (acierto) // Si lo hace
                    {
                        puntosTotales += segundosPorPregunta;
                        OnPropertyChanged(nameof(PuntosTotales)); // Sumamos puntos y notificamos a la Vista
                    }
                    
                }

                if (segundosPorPregunta > 0) // Mientras que no responda y 'segundos' sean > que 0 
                {
                    segundosPorPregunta--;
                    OnPropertyChanged(nameof(SegundosPorPregunta)); // Restamos la variable de segundos y notificamos
                }
                else
                {
                    respondido = true; // Si se le pasa el tiempo, osea 'segundos' = 0, paramos el timer de 1 segundo
                }
            }
        }

        private void pasarPregunta()
        {
            indicePregunta++;
            OnPropertyChanged(nameof(IndicePregunta));

            if (indicePregunta < listadoPreguntas.Count())
            {
                preguntaActual = listadoPreguntas[indicePregunta];
                OnPropertyChanged(nameof(PreguntaActual));

                
                segundosPorPregunta = 5;
                OnPropertyChanged(nameof(SegundosPorPregunta));
                cuentaAtras.Start();
                respondido = false;
            }
            else
            {
                
                partidaAcabada = true;
                OnPropertyChanged(nameof(PartidaAcabada));
            }
            

        }

        public void esperarViendoResultado()
        {
            // Es para no poner un Taks.Delay(1000) 
        }

        public bool comprobarFinPartida() // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! ESTOY AQUI, tengo que mostrar la ultima pantalla y ya
        {
            bool acabado = false;

            if(indicePregunta == listadoPreguntas.Count())
            {
                acabado = true;
            }
            return acabado;
        }
        #endregion

        #region MontarPartida
        /// <summary>
        /// Función que se encarga de tener una partida Completa cargada en memoria, una vez que llamamos a esta función tenemos todo cargado en nuestra RAM.
        /// </summary>
        /// <returns></returns>
        public async Task montarPartida()
        {
            // 1 llenamos los listados
            await cargarListados();
            // 2 creamos 20 preguntas
            await crearPreguntas(ListadoPersonajesAleatorios, ListadoPersonajesCorrectos);

        }

        #region Crear lista de preguntas

        /// <summary>
        /// Función que recibe un objeto 'ObservableCollection<ClsPersonajeDBZ> donde tendremos todos los datos recogidos aleatoriamente', y otro listado 'ObservableCollection<ClsPersonajeDBZ> que tendrá solo las 
        /// opciones correctas para toda la partida'.
        /// PRE: listadoAleatorio y listadoCorrecto deben tener contenido, sino no hará nada.
        /// POST: Tendremos una lista de preguntas con 3 opciones que no coincidirán con la respuesta correcta + la respuesta correcta en nuestra 'listaPreguntas'.
        /// </summary>
        /// <param name="listadoAleatorio"> listadoAleatorio </param>
        /// <param name="listadoCorrecto"> listadoCorrecto </param>
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

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    #endregion

}
