using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    class ClsPersona
    {

        private int idPersona { get; }
        private String nombre { get; set; }
        private String apellido { get; set; }
        private int idDepartamento { get; set; }
        private DateTime fechaNac { get; set; }
        private String direccion { get; set; }
        private String telefono { get; set; }

        public ClsPersona()
        {

        }

        public ClsPersona(string nombre, string apellido,
            int idDepartamento, DateTime fechaNac, 
            string direccion, string telefono)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.idDepartamento = idDepartamento;
            this.fechaNac = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }

}
