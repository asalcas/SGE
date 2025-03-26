namespace ENT
{
    public class ClsPersona
    {
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }
        
        public ClsPersona()
        {

        }
        public ClsPersona(string nombre, string apellido, int edad, string direccion, string email)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Direccion = direccion;
            this.Email = email;
        }
    }
}
