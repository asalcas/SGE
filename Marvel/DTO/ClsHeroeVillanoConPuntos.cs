using ENT;
namespace DTO
{
    public class ClsHeroeVillanoConPuntos : ClsHeroeVillano
    {

        #region ATRIBUTOS
        private int puntitos;
        #endregion

        //------------------------ 

        #region GETTERS y SETTERS
        public int Puntitos
        {
            get { return puntitos; }
            set { puntitos = value; }
        }
        #endregion

        //------------------------

        #region CONSTRUCTORES
        public ClsHeroeVillanoConPuntos()
        {

        }

        
        public ClsHeroeVillanoConPuntos(ClsHeroeVillano personaje, int puntitosNuevos)
            : base (personaje.IdPersonaje, personaje.Nombre, personaje.Foto)
        {
            this.Puntitos = puntitosNuevos;
        }
        #endregion
    }
}
