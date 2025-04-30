using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsPersona
    {
        // DUDA A FERNANDO es private o public auida
        public int IdPersona { get; } // Esto no determina si puedo ponerle en el constructor un ID
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int IdDepartamento { get; set; }
        public DateTime FechaNac { get; set; }
        public String Direccion { get; set; }
        public long Telefono { get; set; }


        public ClsPersona()
        {

        }
        public ClsPersona(int idPersona, string nombre, string apellido,
            int idDepartamento, DateTime fechaNac,
            string direccion, long telefono)
        {
            this.IdPersona = idPersona;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.IdDepartamento = idDepartamento;
            this.FechaNac = fechaNac;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
    }

}
