namespace ENT
{
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
            // --
        }
        public ClsJugador(int idPlayer)
        {
            this.idJugador = idPlayer;
        }

        public ClsJugador(int idPlayer, String namePlayer, int playerScore)
        {
            this.idJugador = idPlayer;
            this.NombreJugador = namePlayer;
            this.PuntuacionJugador = playerScore;
        }
    }
}
