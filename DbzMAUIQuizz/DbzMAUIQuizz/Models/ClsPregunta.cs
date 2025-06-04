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
        private ObservableCollection<ClsPersonajeDBZ> opciones;
        private ClsPersonajeDBZ personajePregunta;
        private bool esCorrecto;
        private ClsPersonajeDBZ personajeSeleccionado;

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

        public ClsPregunta()
        {
            
        }

        public ClsPregunta(ObservableCollection<ClsPersonajeDBZ> opciones, ClsPersonajeDBZ personaje)
        {
            this.opciones = opciones;
            this.PersonajePregunta = personaje;
        }

    }
}
