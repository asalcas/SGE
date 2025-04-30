using ENT;

namespace ASPRivals.Models.VM
{
    public class ListadoHeroeVillanoConCombate : ClsCombate
    {
        #region Atributo
        private List<ClsHeroeVillano> listadoPeleas;
        #endregion
        public List<ClsHeroeVillano> ListadoPeleas
        {
            get { return listadoPeleas; }
        }

        public ListadoHeroeVillanoConCombate()
        {
            // Lo rellenamos para cuando llamemos al constructor vacio, para enviarlo al controlador Indice, en vez de rellenarlo en el controller
            this.listadoPeleas = BL.ListadoHeroesVillanosBL.ObtenerlistadoHeroesVillanoBL();

        }
        public ListadoHeroeVillanoConCombate(ClsCombate peleita) : base(peleita.IdCombatiente1, peleita.IdCombatiente2, peleita.ResultadoCombatiente1, peleita.ResultadoCombatiente2)
        {
            this.listadoPeleas = BL.ListadoHeroesVillanosBL.ObtenerlistadoHeroesVillanoBL();
        }
    }
}
