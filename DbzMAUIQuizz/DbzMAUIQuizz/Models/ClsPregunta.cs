using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClsPregunta : INotifyPropertyChanged
    {
        #region Atributos

        private ObservableCollection<ClsPersonajeDBZ> opciones;

        private ClsPersonajeDBZ personajePregunta;

        private ClsPersonajeDBZ personajeSeleccionado;

        private bool esCorrecto;

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Propiedades

        public ObservableCollection<ClsPersonajeDBZ> Opciones 
        { 
            get { return opciones; } 
        }

        public ClsPersonajeDBZ PersonajePregunta
        {
            get { return personajePregunta; }
        }
        public ClsPersonajeDBZ PersonajeSeleccionado
        {
            get { return personajeSeleccionado; }
            set { personajeSeleccionado = value; 
            }
        }
        public bool EsCorrecto
        {
            get { return esCorrecto; }
        }

        #endregion

        #region Constructores
        public ClsPregunta()
        {
            
        }
        
        public ClsPregunta(ObservableCollection<ClsPersonajeDBZ> opciones, ClsPersonajeDBZ personaje)
        {
            this.opciones = opciones;
            this.personajePregunta = personaje;
        }

        #endregion

        #region Logica Pregunta (Comprobación)

        /// <summary>
        /// Función que comprobará si los objetos pasados a la función son iguales
        /// </summary>
        /// <param name="personajeSeleccionado"></param>
        /// <param name="personajePregunta"></param>
        /// <returns></returns>
        public bool comprobarEsCorrecto()
        {
            esCorrecto = personajeSeleccionado == personajePregunta ? true : false;
            OnPropertyChanged(nameof(EsCorrecto));
            return esCorrecto;
        }
        #endregion

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion 
    }
}
