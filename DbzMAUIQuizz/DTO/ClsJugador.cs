namespace DTO
{
    // ENVIAR DATOS A LA API
    public class ClsJugador
    {
        private int idJugador;
        private String nombreJugador;
        private int puntuacionJugador;

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
    }
}
