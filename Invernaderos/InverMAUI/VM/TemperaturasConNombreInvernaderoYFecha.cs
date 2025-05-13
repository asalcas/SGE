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
        private ClsTemperaturasConNombreInvernaderoYFecha dtoInvernadero;

        private double tempMAX;
        private string nombreInvernadero;
        //borrado
        private ClsTemperatura temperatura;



        public ClsTemperaturasConNombreInvernaderoYFecha DtoInvernadero
        {
            get { return dtoInvernadero; }
        }

        //borrado
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



        public TemperaturasConNombreInvernaderoYFecha()
        {

        }
        
        public TemperaturasConNombreInvernaderoYFecha(ClsTemperaturasConNombreInvernaderoYFecha dto)
        {
            NombreInvernadero = dto.Invernadero.Nombre;
            Temperatura = dto.Temperatura;
            tempMAX = 0.5;

        }
        //CAMBIAR el constructor del DTO para hacer lo mismo justo debajo para cambiarlo del Codigo Behind de la vista  ----------------------------------------------------------------------

        /*public TemperaturasConNombreInvernaderoYFecha(int id, DateTime fecha)
        {

            try
            {
                ClsInvernadero invernaderoNuevo = BL.ListaClsInvernaderoBL.obtenerInvernaderoPorID(id);
                ClsTemperatura tempPorIDyFecha = BL.ListadoClsTemperaturaBL.temperaturaPorInvernaderoYFecha(id, fecha);
                dtoInvernadero = new ClsTemperaturasConNombreInvernaderoYFecha(invernaderoNuevo, tempPorIDyFecha);
                tempMAX = 0.5;


            }
            catch (Exception ex)
            {
                throw new Exception("Error al montar el VM", ex);
            }

        }*/

    }
}
