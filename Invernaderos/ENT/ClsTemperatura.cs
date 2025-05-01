using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ENT
{
    public class ClsTemperatura
    {
        #region ATRIBUTOS 

        private int idInvernadero;
        private DateTime fecha;
        private double temp1;
        private double temp2;
        private double temp3;
        private double humedad1;
        private double humedad2;
        private double humedad3;

        #endregion

        #region GETTERS Y SETTERS

        public int IdInvernadero
        {
            get { return idInvernadero; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public double Temp1
        {
            get { return temp1; }
            set { temp1 = value; }
        }
        public double Temp2
        {
            get { return temp2; }
            set { temp2 = value; }
        }
        public double Temp3
        {
            get { return temp3; }
            set { temp3 = value; }
        }
        public double Humedad1
        {
            get { return humedad1; }
            set { humedad1 = value; }
        }
        public double Humedad2
        {
            get { return humedad2; }
            set { humedad2 = value; }
        }
        public double Humedad3
        {
            get { return humedad3; }
            set { humedad3 = value; }
        }

        #endregion

        #region CONSTRUCTORES
        public ClsTemperatura()
        {

        }
        public ClsTemperatura(int id)
        {
            this.idInvernadero = id;
        }


        public ClsTemperatura(int id, DateTime fechaObtenida, double temp1, double temp2, double temp3, double hum1, double hum2, double hum3)
        {
            this.idInvernadero = id;
            this.Fecha = fechaObtenida;
            this.Temp1 = temp1;
            this.Temp2 = temp2;
            this.Temp3 = temp3;
            this.Humedad1 = hum1;
            this.Humedad2 = hum2;
            this.Humedad3 = hum3;
        }

        #endregion
    }
}
