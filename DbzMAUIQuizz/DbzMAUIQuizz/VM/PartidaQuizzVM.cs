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

        #region Atributos

        private ClsPartida partida;

        private ClsJugador jugador;

        private DelegateCommand comenzar;

        private DelegateCommand verRanking;

        private DelegateCommand insertarJugadoreConPuntuacion;

        private DelegateCommand inicio;

        private String nombreJugador;

        #region Atributos/Propiedades para mostrar cosas en la UI

        private String mensaje;

        private Boolean verMensaje;

        private Boolean verPantallaInicio;

        private Boolean verJuego;

        private Boolean verEndGame;

        public String Mensaje
        {
            get { return mensaje; }
        }
        public Boolean VerMensaje
        {
            get { return verMensaje; }
        }
        public Boolean VerPantallaInicio
        {
            get { return verPantallaInicio; }
        }
        public Boolean VerJuego
        {
            get { return verJuego; }
        }
        public Boolean VerEndGame
        {
            get { return verEndGame; }
        }

        #endregion

        #endregion

        #region Propiedades

        public ClsPartida Partida
        {
            get {  return partida; }
        }

        public ClsJugador Jugador 
        {
            get { return jugador; }
        }

        public String NombreJugador
        {
            get { return nombreJugador; }
            set { nombreJugador = value; }
        }

        #region Propiedades Commands
        public DelegateCommand Comenzar
        {
            get { return comenzar; }
        }
        public DelegateCommand VerRanking
        {
            get { return verRanking; }
        }

        public DelegateCommand InsertarJugadoreConPuntuacion
        {
            get { return insertarJugadoreConPuntuacion; }
        }

        public DelegateCommand Inicio
        {
            get { return inicio; }
        }
        
        #endregion

        #endregion

        #region Constructores

        public PartidaQuizzVM()
        {
            // Valores por defecto para VER en la UI

            verPantallaInicio = true;
            verJuego = false;
            verEndGame = false;

            // -----------------------------------

            jugador = new ClsJugador();
            partida = new ClsPartida();
            comenzar = new DelegateCommand(jugar);
            verRanking = new DelegateCommand(navegacionRank);
            insertarJugadoreConPuntuacion = new DelegateCommand(insertarUsuario);
            inicio = new DelegateCommand(navegarJuego);

        }

        #endregion

        #region UI

        #region Commands

        /// <summary>
        /// Va a ser lo que haga nuestro boton JUGAR en la UI
        /// </summary>
        private async void jugar()
        {
            verPantallaInicio = false;
            OnPropertyChanged(nameof(VerPantallaInicio));

            verJuego = true;
            OnPropertyChanged(nameof(VerJuego));

            await preparaPartida();
        }

        /// <summary>
        /// Va a ser lo que haga nuestro boton RANKING en la UI
        /// </summary>
        private async void navegacionRank()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RankingPage());
        }

        /// <summary>
        /// Va a ser lo que haga nuestro boton GUARDAR PUNTUACION en la UI (EndGame)
        /// </summary>
        private async void insertarUsuario()
        {
            
            if(!string.IsNullOrWhiteSpace(NombreJugador)) // Mirado en Internet, para que no me deje un nombre asi: ""
            {
                jugador.PuntuacionJugador = partida.PuntosTotales;
                jugador.NombreJugador = NombreJugador;

                await BL.ManejadoraJugadorBL.insertarPuntuacionJugadorBL(jugador);

                mensaje = "Usuario añadido con éxito";
                OnPropertyChanged(nameof(Mensaje));
                verMensaje = true;
            }
            else
            {
                mensaje = "Debes introducir correctamente tu NICK o iniciales.";
                OnPropertyChanged(nameof(Mensaje));
                verMensaje = true;

            }

        }

        private async void navegarJuego()
        {
            verPantallaInicio = true;
            OnPropertyChanged(nameof(VerPantallaInicio));

            verJuego = false;
            OnPropertyChanged(nameof(VerJuego));

            verMensaje = false;
            OnPropertyChanged(nameof(VerMensaje));

            jugador = new ClsJugador();
            OnPropertyChanged(nameof(Jugador));

            partida = new ClsPartida();
            OnPropertyChanged(nameof(Partida));

        }

        #endregion

        #endregion

        #region Funciones para que la partida funcione

        private async Task preparaPartida()
        {
            await partida.montarPartida();
            await partida.empezarPartida();
        }


        #endregion

        #region Notify

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
