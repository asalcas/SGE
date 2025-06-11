using BL;
using DbzMAUIQuizz.Models.Utils;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbzMAUIQuizz.VM
{
    public class RankingJugadoresPageVM : INotifyPropertyChanged
    {
        #region Atributos

        ObservableCollection<ClsJugador> jugadores;

        private DelegateCommand actualizarListado;

        private Boolean ruediniBombini;

        #endregion

        #region Propiedades
        public ObservableCollection<ClsJugador> Jugadores
        {
            get { return jugadores; }
        }

        public DelegateCommand ActualizarListado
        {
            get { return actualizarListado; }
        }

        public Boolean RuediniBombini
        {
            get { return ruediniBombini; }
        }
        #endregion

        #region Constructores
        public RankingJugadoresPageVM()
        {
            rellenarJugadoresListado();

            actualizarListado = new DelegateCommand(rellenarJugadoresListado);
        }

        #endregion

        #region Funciones del VM
        /// <summary>
        /// Función que rellena el listado de jugadores de nuestro VM
        /// </summary>
        private async void rellenarJugadoresListado()
        {
            try
            {
                ruediniBombini = true;
                OnPropertyChanged(nameof(RuediniBombini));
                jugadores = new ObservableCollection<ClsJugador>(await BL.ListadoRankingJugadoresBL.obtenerListadoOrdenadoJugadoresBL());
                ruediniBombini = false;
                OnPropertyChanged(nameof(RuediniBombini));

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    Application.Current.MainPage.DisplayAlert("Error:", "No se ha encontrado registros", "Entendido");

                }
                else if (ex.Message.Contains("400"))
                {
                    Application.Current.MainPage.DisplayAlert("Error:", "Hemos tenido un BadRequest", "Entendido");

                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Error:", "Ha ocurrido un error inesperado", "Entendido");

                }
            }
            
            
            OnPropertyChanged(nameof(Jugadores));
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
