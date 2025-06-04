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

        private string color;
        private int segundos;
        private int puntos;
        private int rondaPartida;

        private DelegateCommand miCommand;
        private DelegateCommand insertarJugadoreConPuntuacion;

        public int RondaPartida
        {
            get { return rondaPartida; }
        }

        public int Puntos
        {
            get { return puntos; }
            set
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



        public PartidaQuizzVM()
        {
            ShowPantallaAntesJuego = true;
            MostrarJuego = false;

            partida = new ClsPartida();

            miCommand = new DelegateCommand(() => empezarPartida());
            // meter el temporizador de 5 segundos

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

        }
        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
        #endregion
    }
}
