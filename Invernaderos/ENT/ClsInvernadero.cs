namespace ENT
{
    public class ClsInvernadero
    {
        #region ATRIBUTOS y PROPIEDADES

        // Atributos
        private int idInvernadero;
        private String nombre;

        // Propiedades (Getters - Setters)
        public int IdInvernadero
        {
            get { return idInvernadero; }
        }
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion
        #region CONSTRUCTORES
        public ClsInvernadero()
        {
            
        }
        public ClsInvernadero(int id, String nombreInvernadero)
        {
            this.idInvernadero = id;
            this.Nombre = nombreInvernadero;
        }

        #endregion




    }
}
