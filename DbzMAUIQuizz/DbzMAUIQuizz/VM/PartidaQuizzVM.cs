using DbzMAUIQuizz.Models.Utils;
using DTO;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbzMAUIQuizz.VM
{
    public class PartidaQuizzVM : INotifyPropertyChanged
    {
        private ClsPartida partida;
        private ClsPregunta preguntaActual;


        private bool mostrarJuego;
        private bool showPantallaAntesJuego;
        private bool finalGame;

        private string color;
        private String nombreJugador = "";
        private int segundos;
        private int puntos;
        private int rondaPartida;

        private DelegateCommand miCommand;
        private DelegateCommand verRanking;
        private DelegateCommand insertarJugadoreConPuntuacion;

        private ClsJugador jugador;

        public ClsJugador Jugador
        {
            get { return jugador; }
            set { jugador = value; }
        }

        public String NombreJugador
        {
            get { return nombreJugador; }
            set { nombreJugador = value;
                OnPropertyChanged(nameof(NombreJugador));
            }
        }

        public int RondaPartida
        {
            get { return rondaPartida; }
        }

        public int Puntos
        {
            get { return puntos; }
            private set
            {
                puntos = value;
                OnPropertyChanged(nameof(Puntos));
            }
        }
        public int Segundos
        {
            get { return segundos; }
            private set
            {
                segundos = value;
                OnPropertyChanged(nameof(Segundos));
            }
        }


        public string Color
        {
            get { return color; }
            set { color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        private IDispatcher dispatcher;

        public IDispatcher Dispatcher
        {
            get { return dispatcher; }
            set { dispatcher = value; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler Tick;

        public ClsPartida Partida
        {
            get { return partida; }
        }
        public ClsPregunta PreguntaActual
        {
            get { return preguntaActual; }
            
        }

        public bool FinalGame
        {
            get { return finalGame; }
            // Segun GPT si no hago un Setter no puede funcionar, preguntar a Fernando
            set { finalGame = value;
                OnPropertyChanged(nameof(FinalGame));
            }
            
        }
        public bool ShowPantallaAntesJuego
        {
            get { return showPantallaAntesJuego; }
            set
            {
                showPantallaAntesJuego = value;
                OnPropertyChanged(nameof(ShowPantallaAntesJuego));
            }
        }
        public bool MostrarJuego
        {
            get { return mostrarJuego; }
            set
            {
                mostrarJuego = value;
                OnPropertyChanged(nameof(MostrarJuego));
            }
        }
        public DelegateCommand MiCommand
        {
            get { return miCommand; }
        }
        public DelegateCommand VerRanking
        {
            get { return verRanking; }
        }

        public DelegateCommand InsertarJugadoreConPuntuacion
        {
            get { return insertarJugadoreConPuntuacion; }
        }

        public PartidaQuizzVM()
        {
            ShowPantallaAntesJuego = true;
            MostrarJuego = false;
            finalGame = false;

            partida = new ClsPartida();
            jugador = new ClsJugador();

            miCommand = new DelegateCommand(() => empezarPartida());
            verRanking = new DelegateCommand(() => navegarRanking());
            insertarJugadoreConPuntuacion = new DelegateCommand(() => insertarJugador(Jugador));

        }




        public async Task montarPartidita()
        {
            await partida.montarPartida();
        }

        private async Task empezarPartida()
        {
            int indicePregunta = 0;
            bool seguir = true;
            bool preguntaRespondida = false;
            Segundos = 5;
            rondaPartida = 1;
            Color = "#c4542d"; // mame
            

            OnPropertyChanged(nameof(RondaPartida));
            MostrarJuego = true;
            await montarPartidita();


            ShowPantallaAntesJuego = !ShowPantallaAntesJuego;

            if (!ShowPantallaAntesJuego)
            {
                MostrarJuego = true;
            }

            if (partida.ListadoPreguntas.Any())
            {
                preguntaActual = partida.ListadoPreguntas[indicePregunta];
                OnPropertyChanged(nameof(PreguntaActual));
            }

            Dispatcher.StartTimer(TimeSpan.FromSeconds(1.5), () =>
            {
                if (indicePregunta >= partida.ListadoPreguntas.Count())
                {
                    seguir = false;

                    if (!FinalGame)
                    {
                        finalGame = true;
                        MostrarJuego = false;
                    }

                }
                else
                {

                    if (preguntaActual.PersonajeSeleccionado != null && !preguntaRespondida && preguntaActual.PersonajeSeleccionado == PreguntaActual.PersonajePregunta)
                    {

                        puntos += Segundos;
                        OnPropertyChanged(nameof(Puntos));
                        Color = "#249344";
                        preguntaRespondida = true;

                    }
                    
                    if (Segundos == 0 || preguntaRespondida)
                    {
                        indicePregunta++;
                        rondaPartida++;
                        OnPropertyChanged(nameof(RondaPartida));

                        if (indicePregunta >= partida.ListadoPreguntas.Count())
                        {
                            seguir = false;
                        }
                        else
                        {
                            preguntaActual = partida.ListadoPreguntas[indicePregunta];
                            OnPropertyChanged(nameof(PreguntaActual));
                        }


                        Color = "#c4542d";
                        Segundos = 5;
                        preguntaRespondida = false;

                    }
                    else
                    {
                        Segundos--;
                    }


                }

                return seguir;
            });
            jugador.NombreJugador = NombreJugador;
            jugador.PuntuacionJugador = puntos;
            
        }


        private async Task insertarJugador(ClsJugador jugador)
        {

            //await BL.ManejadoraJugadorBL.insertarPuntuacionJugadorBL(jugador);

        }
            
        private async Task navegarRanking()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RankingPage());
        }

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        #endregion
    }
}
