using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsDepartamento
    {
        public int IdDepartamento { get; }
        public String NombreDept { get; set; }


        public ClsDepartamento(int idDepartamento, String nombreDept)
        {
            this.IdDepartamento = idDepartamento;
            this.NombreDept = nombreDept;

        }
    }

}
