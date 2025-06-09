namespace DTO
{
    public class ClsJugador
    {
        #region Atributos

        private int idJugador;

        private String nombreJugador;

        private int puntuacionJugador;

        #endregion

        #region Propiedades
        public int IdJugador
        {
            get { return idJugador; }
        }

        public String NombreJugador
        {
            get { return nombreJugador; }
            set { nombreJugador = value; }
        }
        public int PuntuacionJugador
        {
            get { return puntuacionJugador; }
            set { puntuacionJugador = value; }
        }

        #endregion

        #region Constructores
        public ClsJugador()
        {

        }
        public ClsJugador(int id)
        {
            this.idJugador = id;
        }

        public ClsJugador(int id, String nombre, int puntuacion)
        {
            this.idJugador = id;
            this.NombreJugador = nombre;
            this.PuntuacionJugador = puntuacion;
        }

        #endregion
    }
}
