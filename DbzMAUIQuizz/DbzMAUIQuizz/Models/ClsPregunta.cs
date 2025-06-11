using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbzMAUIQuizz.Models;

namespace DTO
{
    public class ClsPregunta : INotifyPropertyChanged
    {
        #region Atributos

        private ObservableCollection<ClsPersonajeDBZComprobado> opciones;

        private ClsPersonajeDBZ personajePregunta;

        private ClsPersonajeDBZComprobado personajeSeleccionado;

        private bool esCorrecto;

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Propiedades

        public ObservableCollection<ClsPersonajeDBZComprobado> Opciones
        {
            get { return opciones; }
        }

        public ClsPersonajeDBZ PersonajePregunta
        {
            get { return personajePregunta; }
        }
        public ClsPersonajeDBZComprobado PersonajeSeleccionado
        {
            get { return personajeSeleccionado; }
            set
            {
                personajeSeleccionado = value;
                comprobarEsCorrecto();
                OnPropertyChanged(nameof(EsCorrecto));
            }
        }
        public bool EsCorrecto
        {
            get
            {
                return esCorrecto;
            }
        }

        #endregion

        #region Constructores
        public ClsPregunta()
        {

        }

        public ClsPregunta(ObservableCollection<ClsPersonajeDBZComprobado> opciones, ClsPersonajeDBZComprobado personaje)
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
        private void comprobarEsCorrecto()
        {
            esCorrecto = personajeSeleccionado == personajePregunta ? true : false;
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
