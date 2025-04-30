using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using MAUIRivals.Models.Utils;

namespace MAUIRivals.VM
{
    public class ClsCombateConListaHeroeVillanoVM
    {
        #region Atributos

        private List<ClsHeroeVillano> listaPersonaje;
        private ClsHeroeVillano combatiente1 = new ClsHeroeVillano();
        private ClsHeroeVillano combatiente2 = new ClsHeroeVillano();
        private int puntuacionCombatiente1;
        private int puntuacionCombatiente2;
        private int puntuacionMax;

        private ClsCombate combateMarvel;
        private DelegateCommand guardar_Actualizar;

        #endregion

        #region GETTERS y SETTERS
        public List<ClsHeroeVillano> ListaPersonaje
        {
            get { return listaPersonaje; }
        }
        public ClsHeroeVillano Combatiente1
        {
            get { return combatiente1; }
            set { combatiente1 = value;
                guardar_Actualizar.RaiseCanExecuteChanged(); // ESTO HACE QUE SE REEVALUE LA CONDICION DE NUESTRO CAN EXECUTE
            }
        }
        public ClsHeroeVillano Combatiente2
        {
            get { return combatiente2; }
            set { combatiente2 = value;
                guardar_Actualizar.RaiseCanExecuteChanged();
            }
        }
        public int PuntuacionMax
        {
            get { return puntuacionMax; }
        }
        public ClsCombate CombateMarvel
        {
            get { return combateMarvel; }
            set { combateMarvel = value; }
        }
        public int PuntuacionCombatiente1
        {
            get { return puntuacionCombatiente1; }
            set { puntuacionCombatiente1 = value; }
        }
        public int PuntuacionCombatiente2
        {
            get { return puntuacionCombatiente2; }
            set { puntuacionCombatiente2 = value; }
        }
        public DelegateCommand Guardar_Actualizar
        {
            get { return guardar_Actualizar; }
        }

        #endregion
        public ClsCombateConListaHeroeVillanoVM()
        {
            try
            {
                listaPersonaje = BL.ListadoHeroesVillanosBL.ObtenerlistadoHeroesVillanoBL();
                puntuacionMax = 5;
                guardar_Actualizar = new DelegateCommand(guardarCombate, habilitarBotonGuardar); // necesario (que hacer, cuando hacer)

            }
            catch (Exception ex)
            {
                muestraMensajes("Error inesperado:", "No se pudo obtener el listado de personajes de la Base de Datos, vuelva a intentarlo más tarde", "Entendido");
            }
        }
        
        #region DisplayAlert function
        private async void muestraMensajes(string cabecera, string mensaje, string confirmacion)
        {
            await Shell.Current.DisplayAlert(cabecera, mensaje, confirmacion);
        }
        #endregion

        #region COMMANDS
        private bool habilitarBotonGuardar()
        {
            Boolean ejecutable = false;

            if((combatiente1.IdPersonaje != combatiente2.IdPersonaje) && (PuntuacionCombatiente1 != 0 || PuntuacionCombatiente2 != 0))
            {
                if (combatiente1.IdPersonaje != 0 && combatiente2.IdPersonaje!= 0)
                {
                    ejecutable = true;
                }
                
            }
            return ejecutable;
        }

        private void guardarCombate()
        {
            Boolean guardado = false;
            ClsCombate combateGuardar = new ClsCombate();

            combateGuardar.IdCombatiente1 = combatiente1.IdPersonaje;
            combateGuardar.IdCombatiente2 = combatiente2.IdPersonaje;
            combateGuardar.FechaCombate = DateTime.Now;
            combateGuardar.ResultadoCombatiente1 = this.PuntuacionCombatiente1;
            combateGuardar.ResultadoCombatiente2 = this.PuntuacionCombatiente2;

            try
            {
                guardado = BL.ManejadoraCombateBL.guardarCombateBL(combateGuardar);
                if (guardado)
                {

                    muestraMensajes("Enhorabuena!", "La puntuación ha sido un éxito, SHIELD te da las gracias!", "Entendido");
                }
            }
            catch (Exception ex)
            {
                muestraMensajes("Error:", "Ha ocurrido un error inesperado al guardar el combate, intentelo de nuevo mas tarde", "Entendido");
            }
            
        }
        #endregion
    }
}
