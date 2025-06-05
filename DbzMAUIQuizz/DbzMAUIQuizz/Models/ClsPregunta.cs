using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClsPregunta
    {
        #region Atributos

        private ObservableCollection<ClsPersonajeDBZ> opciones;
        private ClsPersonajeDBZ personajePregunta;
        private bool esCorrecto;
        private ClsPersonajeDBZ personajeSeleccionado;
        private int segundos;

        #endregion
        public ClsPersonajeDBZ PersonajeSeleccionado
        {
            get { return personajeSeleccionado; }
            set { personajeSeleccionado = value; }
        }
        public ObservableCollection<ClsPersonajeDBZ> Opciones 
        { 
            get { return opciones; } 

        }

        public ClsPersonajeDBZ PersonajePregunta
        {
            get { return personajePregunta; }
            set {  personajePregunta = value; }
        }

        public int Segundos
        {
            get { return segundos; }
        }

        public ClsPregunta()
        {
            
        }

        public ClsPregunta(ObservableCollection<ClsPersonajeDBZ> opciones, ClsPersonajeDBZ personaje)
        {
            this.opciones = opciones;
            this.PersonajePregunta = personaje;
            this.segundos = 5;
        }

        /// <summary>
        /// Función que comprobará si los objetos pasados a la función son iguales
        /// </summary>
        /// <param name="personajeSeleccionado"></param>
        /// <param name="personajePregunta"></param>
        /// <returns></returns>
        public bool comprobarEsCorrecto(ClsPersonajeDBZ personajeSeleccionado, ClsPersonajeDBZ personajePregunta)
        {
            Boolean esCorrecto;
            esCorrecto = personajeSeleccionado == personajePregunta ? true : false;
            return esCorrecto;

        }
    }
}
