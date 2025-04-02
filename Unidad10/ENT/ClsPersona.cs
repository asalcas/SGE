using System.ComponentModel.DataAnnotations;

namespace ENT
{
    public class ClsPersona
    {
        #region Propiedades autoimplementadas

        [Display(Name ="Id Personal")]
        public int ID { get; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Sexo { get; set; }
        public String Foto { get; set; }

        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy",ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        #endregion


        #region Constructores
        public ClsPersona()
        {

        }
        public ClsPersona(int id, String nombre, String apellidos, String sexo, String foto, DateTime fechaNacimiento)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Foto = foto;
            this.FechaNacimiento = fechaNacimiento;
        }
        public ClsPersona(int id)
        {
            this.ID = id;
        }
        #endregion
    }
}
