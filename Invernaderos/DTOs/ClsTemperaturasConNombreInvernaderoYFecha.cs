﻿using ENT;
using System.Reflection.Metadata;

namespace DTOs
{
    // Clase que me facilitará el traslado de datos directamente a la vista de la lista
    public class ClsTemperaturasConNombreInvernaderoYFecha
    {
        #region ATRIBUTOS

        private ClsInvernadero invernadero; // aqui lo suyo 100% deberia de traer el nombre solo, no el objeto
        private ClsTemperatura temperatura;

        #endregion

        #region GETTERS y SETTERS
        public ClsInvernadero Invernadero
        {
            get { return invernadero; }
            set { invernadero = value; }
        }
        public ClsTemperatura Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }
        #endregion
        #region CONSTRUCTORES
        public ClsTemperaturasConNombreInvernaderoYFecha()
        {
        
        }

        
        public ClsTemperaturasConNombreInvernaderoYFecha(ClsInvernadero invernaderoNuevo, ClsTemperatura temperaturaNueva) {
            this.Invernadero = invernaderoNuevo;
            this.Temperatura = temperaturaNueva;
        
        }

        #endregion


    }
}
