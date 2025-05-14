using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ENT
{
    public class ClsPersona
    {
        #region Propiedades autoimplementadas

        [Display(Name ="Identificador")]
        [JsonPropertyName("id")]
        public int ID { get; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public String Foto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdDept { get; set; } 
        #endregion


        #region Constructores
        public ClsPersona()
        {

        }
        public ClsPersona(int id, String nombre, String apellidos, String telefono, String direccion, String foto, DateTime fechaNacimiento, int idDepartamento)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Foto = foto;
            this.FechaNacimiento = fechaNacimiento;
            this.IdDept = idDepartamento;
        }
        public ClsPersona(int id)
        {
            this.ID = id;
        }
        #endregion
    }
}
