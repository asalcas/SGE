using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsDepartamentos
    {
        #region Propiedades Autoimplementadas
        public int IdDepartamento { get; }
        public string NombreDepartamento { get; set; }
        #endregion


        #region Constructores

        public ClsDepartamentos()
        {

        }
        public ClsDepartamentos(int IdDept)
        {
            this.IdDepartamento = IdDept;
        }
        public ClsDepartamentos(int IdDept, string nombreDept)
        {
            this.IdDepartamento = IdDept;
            this.NombreDepartamento = nombreDept;
        }

        #endregion
    }
}
