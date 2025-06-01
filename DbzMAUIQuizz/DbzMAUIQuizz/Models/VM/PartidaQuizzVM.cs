using DbzMAUIQuizz.Models.Utils;
using DTO;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbzMAUIQuizz.Models.VM
{
    public class PartidaQuizzVM : INotifyPropertyChanged
    {
        private ClsPartida partida;
        private ClsPregunta preguntaActual;
        private ClsPersonajeDBZ personajeSelected;
        private Boolean mostrarJuego;
        private Boolean showPantallaAntesJuego;
        private DelegateCommand miCommand;
        private String color;


        public String Color
        {
            get { return color; }
            set { color = value; }
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
            set { preguntaActual = value; }
        }
        
        public ClsPersonajeDBZ PersonajeSelected
        {
            get { return personajeSelected; }
            set { personajeSelected = value; }
        }

        public Boolean ShowPantallaAntesJuego
        {
            get { return showPantallaAntesJuego; }
            set { showPantallaAntesJuego = value;
                OnPropertyChanged(nameof(ShowPantallaAntesJuego));
            }
        }
        public Boolean MostrarJuego
        {
            get { return mostrarJuego; }
            set { mostrarJuego = value;
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
            int segundos = 5;

            MostrarJuego = true;
            await montarPartidita();

            ShowPantallaAntesJuego = !ShowPantallaAntesJuego;

            if (!ShowPantallaAntesJuego)
            {
                MostrarJuego = true;
            }


            Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                
                if (indicePregunta >= partida.ListadoPreguntas.Count())
                {
                    seguir = false;

                }
                else
                {
                    
                    if (PersonajeSelected != null && (!preguntaRespondida && PersonajeSelected == PreguntaActual.PersonajePregunta))
                    {
                        partida.asignarPuntos(segundos);
                        preguntaRespondida = true;
                    }
                    if (segundos == 0 || preguntaRespondida)
                    {
                        indicePregunta++;

                        if (indicePregunta >= partida.ListadoPreguntas.Count())
                        {
                            seguir = false;
                        }
                        else
                        {
                            PreguntaActual = partida.ListadoPreguntas[indicePregunta];
                            OnPropertyChanged(nameof(PreguntaActual));
                        }

                            

                        segundos = 5;
                        OnPropertyChanged(nameof(Partida.Segundos));
                        preguntaRespondida = false;

                    }
                    else
                    {
                        segundos--;
                        OnPropertyChanged(nameof(Partida.Segundos));
                    }

                    partida.asignarSegundos(segundos);
                }

                return seguir;
            });
          
        }
        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
