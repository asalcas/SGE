namespace ENT
{
    public class ClsPersona
    {
        #region Propiedades autoimplementadas
        public String DNI { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        #endregion


        #region Constructores
        public ClsPersona()
        {

        }
        public ClsPersona(string Dni, String nombre, String apellido, String sexo, DateTime fechaNacimiento)
        {
            this.DNI = Dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.FechaNacimiento = fechaNacimiento;
        }
        #endregion
    }
}
