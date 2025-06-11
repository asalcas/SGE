using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DbzMAUIQuizz.Models
{
    public class ClsPersonajeDBZComprobado : ClsPersonajeDBZ, INotifyPropertyChanged
    {
        #region Atributos

        private Boolean? esElCorrecto;

       

        #endregion

        #region Propiedades

        public Boolean? EsElCorrecto
        {
            get { return esElCorrecto; }
            set { esElCorrecto = value;
                OnPropertyChanged(nameof(EsElCorrecto));

            }
        }
        #endregion

        #region Constructores

        public ClsPersonajeDBZComprobado()
        {

        }

        public ClsPersonajeDBZComprobado(int idPersonaje) : base(idPersonaje) 
        {
        }


        public ClsPersonajeDBZComprobado(int id, String nombre, String foto) : base(id, nombre, foto)
        {
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
