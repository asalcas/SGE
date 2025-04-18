namespace ENT
{
    public class ClsHeroeVillano
    {
        #region ATRIBUTOS

        private int idPersonaje;
        private String nombre;
        private String foto;

        #endregion

        //------------------------
        #region GETTER SETTER
        public int IdPersonaje
        {
            get { return idPersonaje; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        #endregion
        //------------------------

        #region CONSTRUCTORES
        public ClsHeroeVillano()
        {

        }

        public ClsHeroeVillano(int id)
        {
            this.idPersonaje = id;
        }
        public ClsHeroeVillano (int id, String nombre)
        {
            this.idPersonaje = id;
            this.nombre = nombre;
        }

        public ClsHeroeVillano(int id, String name, String imagen)
        {
            this.idPersonaje = id;
            this.Nombre = name;
            this.Foto = imagen;
        }

        #endregion

    }

}
