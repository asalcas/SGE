using System;
using System.Collections.Generic;
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

        private String nombreInvernadero;
        private ClsTemperatura temperatura;

        public String NombreInvernadero
        {
            get { return nombreInvernadero; }
            set { nombreInvernadero = value; }
        }


        public ClsTemperatura Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }
        
      
        // Aqui necesito un invernadero para poner nombre y fecha
        // y tambien las temperaturas de ese invernadero
        
        public TemperaturasConNombreInvernaderoYFecha()
        {
            
        }
        public TemperaturasConNombreInvernaderoYFecha(ClsTemperaturasConNombreInvernaderoYFecha dto)
        {
            this.NombreInvernadero = dto.Invernadero.Nombre;
            this.Temperatura = dto.Temperatura;

        }
        
        
        
        // Aqui relleno el constructor del VM con los metodos de la DAL que previamente hice para que esté bastante CLEAN, y asi solo coge lo que necesita la vista


    }
}
