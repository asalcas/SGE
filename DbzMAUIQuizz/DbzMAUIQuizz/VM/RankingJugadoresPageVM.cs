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

        ObservableCollection<ClsJugador> jugadores;

        DelegateCommand jugar;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<ClsJugador> Jugadores
        {
            get { return jugadores; }
        }

        public RankingJugadoresPageVM()
        {
            rellenarJugadoresListado();
        }

        #region Funciones del VM
        /// <summary>
        /// Función que rellena el listado de jugadores de nuestro VM
        /// </summary>
        private async void rellenarJugadoresListado()
        {
            jugadores = new ObservableCollection<ClsJugador>(await BL.ListadoRankingJugadoresBL.obtenerListadoOrdenadoJugadoresBL());
            OnPropertyChanged(nameof(Jugadores));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
