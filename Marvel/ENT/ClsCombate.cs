using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsCombate
    {

        #region ATRIBUTOS

        private int idCombatiente1;
        private int idCombatiente2;
        private DateTime fechaCombate;
        private int resultadoCombatiente1;
        private int resultadoCombatiente2;

        #endregion

        #region GETTERS Y SETTERS
        public int IdCombatiente1
        {
            get { return idCombatiente1; }
            set { idCombatiente1 = value; }
        }
        public int IdCombatiente2
        {
            get { return idCombatiente2; }
            set { idCombatiente2 = value; }
        }
        public DateTime FechaCombate
        {
            get { return fechaCombate; }
            set { fechaCombate = value; }
        }
        public int ResultadoCombatiente1
        {
            get { return resultadoCombatiente1; }
            set { resultadoCombatiente1 = value; }
        }
        public int ResultadoCombatiente2
        {
            get { return resultadoCombatiente2; }
            set { resultadoCombatiente2 = value; }
        }
        #endregion

        #region CONSTRUCTOR

        public ClsCombate()
        {
            this.fechaCombate = DateTime.Now;
        }
        public ClsCombate(int idPersonaje1, int idPersonaje2, int resultadoPersonaje1, int resultadoPersonaje2)
        {
            this.IdCombatiente1 = idPersonaje1;
            this.IdCombatiente2 = idPersonaje2;
            this.ResultadoCombatiente1 = resultadoPersonaje1;
            this.ResultadoCombatiente2 = resultadoPersonaje2;
        }
        public ClsCombate(int idPersonaje1, int idPersonaje2, DateTime horaCombate, int resultadoPersonaje1, int resultadoPersonaje2)
        {
            this.IdCombatiente1 = idPersonaje1;
            this.IdCombatiente2 = idPersonaje2;
            this.FechaCombate = horaCombate;
            this.ResultadoCombatiente1 = resultadoPersonaje1;
            this.ResultadoCombatiente2 = resultadoPersonaje2;
        }
        #endregion
    }
}
