using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DbzMAUIQuizz.Models
{
    public class ClsPersonajeDBZComprobado : ClsPersonajeDBZ
    {
        #region Atributos

        private Boolean esElCorrecto;

        #endregion

        #region Propiedades

        public Boolean EsElCorrecto
        {
            get { return esElCorrecto; }
            set { esElCorrecto = value; }
        }
        #endregion

        #region Constructores

        public ClsPersonajeDBZComprobado()
        {

        }

        public ClsPersonajeDBZComprobado(int idPersonaje) : base(idPersonaje) 
        {
            this.esElCorrecto = false;
        }


        public ClsPersonajeDBZComprobado(int id, String nombre, String foto) : base(id, nombre, foto)
        {
            this.esElCorrecto = false;
        }

        #endregion
    }
}
