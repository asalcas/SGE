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
            jugadores = new ObservableCollection<ClsJugador>(await BL.ListadoRankingJugadoresBL.obtenerListadoOrdenadoJugadoresBL());
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
