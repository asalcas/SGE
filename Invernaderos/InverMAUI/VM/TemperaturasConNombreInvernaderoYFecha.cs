using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using ENT;

namespace InverMAUI.VM
{
    public class TemperaturasConNombreInvernaderoYFecha
    {

        private string nombreInvernadero;
        private ClsTemperatura temperatura; // 
        
        
        
        private double tempMAX;
        private double temp1Bar;
        private double temp2Bar;
        private double temp3Bar;
        private double hum1Bar;

        

        public ClsTemperatura Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }
        public double TempMAX
        {
            get { return tempMAX; }
        }

        public string NombreInvernadero
        {
            get { return nombreInvernadero; }
            set { nombreInvernadero = value; }
        }


        #region PERUANADA MESOPOTAMICA
        // Puede ser la mayor peruanada que he hecho en mi vida
        public double? Temp1Bar
        {
            get
            {
                double? resultado = 0;
                if(Temperatura != null)
                {
                    resultado = Temperatura.Temp1 / 50;

                }
                else
                {
                    resultado = null;
                }
                    return resultado; } // Por que Temp1 / 50?, al pensar que para sacar el porcentaje entre 0 - 1, tenia que multiplicar por 100 para el %, 
            // pero si no lo multiplico ya recibo el porcentaje en 0,algo
        }

        public string Temp1Color
        {
            get
            {
                string color = "";

                if (Temp1Bar > 0.7)
                    color = "Red";
                else if (Temp1Bar < 0.3)
                    color = "Blue";
                else
                    color = "Green";

                return color;
            }
        }
        public double? Temp2Bar
        {
            get
            {
                double? resultado = 0;
                if (Temperatura != null)
                {
                    resultado = Temperatura.Temp2 / 50;
                }
                else
                {
                    resultado = null;
                }
                return resultado;
            }
        
        }
        public string Temp2Color
        {
            get
            {
                string color = "";

                if (Temp2Bar > 0.7)
                    color = "Red";
                else if (Temp2Bar < 0.3)
                    color = "Blue";
                else
                    color = "Green";

                return color;
            }
        }
        public double? Temp3Bar
        {
            get
            {
                double? resultado = 0;
                if (Temperatura != null)
                {
                    resultado = Temperatura.Temp3 / 50;
                }
                else
                {
                    resultado = null;
                }
                return resultado;
            }
        }
        public string Temp3Color
        {
            get
            {
                string color = "";

                if (Temp3Bar > 0.7)
                    color = "Red";
                else if (Temp3Bar < 0.3)
                    color = "Blue";
                else
                    color = "Green";

                return color;
            }
        }
        #endregion

        #region PERUANADA MESOPOTAMICA 2: LA VENGANZA DE LOS SITH
        public double? Hum1Bar
        {
            get
            {
                double? resultado = 0;
                if (Temperatura != null)
                {
                    resultado = Temperatura.Humedad1 / 100;

                }
                
                return resultado;
            } 
        }
        public double? Hum2Bar
        {
            get
            {
                double? resultado = 0;
                if (Temperatura != null)
                {
                    
                    resultado = Temperatura.Humedad2 / 100;

                }
                    return resultado;
            } 
        }
        public double? Hum3Bar
        {
            get
            {
                double? resultado = 0;
                if (Temperatura != null)
                {
                    resultado = Temperatura.Humedad3 / 100;

                }
                return resultado;
            } 
        }

        #endregion

        #region TERNARIOS PARA MENSAJES JUNTO A LOS PUTOS PROGRES BAR
        public string Temp1Texto => Temperatura.Temp1 != null ? $"{Temperatura.Temp1} °C" : "?";
        public string Temp2Texto => Temperatura.Temp2 != null ? $"{Temperatura.Temp2} °C" : "?";
        public string Temp3Texto => Temperatura.Temp3 != null ? $"{Temperatura.Temp3} °C" : "?";
        public string Hum1Texto => Temperatura.Humedad1 != null ? $"{Temperatura.Humedad1} %" : "?";
        public string Hum2Texto => Temperatura.Humedad2 != null ? $"{Temperatura.Humedad2} %" : "?";
        public string Hum3Texto => Temperatura.Humedad3 != null ? $"{Temperatura.Humedad3} %" : "?";

        #endregion

        public TemperaturasConNombreInvernaderoYFecha()
        {

        }
        /*public TemperaturasConNombreInvernaderoYFecha(ClsTemperaturasConNombreInvernaderoYFecha dto)
        {
            NombreInvernadero = dto.Invernadero.Nombre;
            Temperatura = dto.Temperatura;
            tempMAX = 0.5;

        }
        */
        public TemperaturasConNombreInvernaderoYFecha(int id, DateTime fecha)
        {

            try
            {
                ClsTemperatura temperaturaPorFechaEID = BL.ListadoClsTemperaturaConInvernaderoYFecha.temperaturaPorInvernaderoYFecha(id, fecha); //
                ClsInvernadero invernadero = BL.ListaClsInvernaderoBL.obtenerInvernaderoPorID(id);
                ClsTemperaturasConNombreInvernaderoYFecha dto = new ClsTemperaturasConNombreInvernaderoYFecha(invernadero, temperaturaPorFechaEID);
                NombreInvernadero = dto.Invernadero.Nombre;
                Temperatura = dto.Temperatura;
                tempMAX = 0.5;


            }
            catch (Exception ex)
            {
                throw new Exception("Error al montar el VM", ex);
            }
           
        }

    }
}
