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
        }

        public ClsJugador()
        {
            // --
        }
        public ClsJugador(int idPlayer, int playerScore)
        {
            this.idJugador = idPlayer;
            this.puntuacionJugador = playerScore;
        }

        public ClsJugador(int idPlayer, String namePlayer, int playerScore)
        {
            this.idJugador = idPlayer;
            this.nombreJugador = namePlayer;
            this.puntuacionJugador = playerScore;
        }
    }
}
