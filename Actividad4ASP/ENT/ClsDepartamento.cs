using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    class ClsDepartamento
    {
        private int idDepartamento { get; }
        private String nombreDept { get; set; }

        public ClsDepartamento()
        {

        }

        public ClsDepartamento(String nombreDept)
        {
            this.nombreDept = nombreDept;

        }
    }

}
