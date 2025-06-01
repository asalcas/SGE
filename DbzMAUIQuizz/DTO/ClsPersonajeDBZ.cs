using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DTO
{
    public class ClsPersonajeDBZ
    {
        [JsonProperty("id")]
        private int idPersonaje;

        [JsonProperty("name")]
        private String nombrePersonaje;
        
        [JsonProperty("image")]
        private String fotoPersonaje;

        public int IdPersonaje
        {
            get { return idPersonaje; }
        }
        public String NombrePersonaje
        {
            get { return nombrePersonaje; }
            set { nombrePersonaje = value; }
        }
        public String FotoPersonaje
        {
            get { return fotoPersonaje; }
            set { fotoPersonaje = value; }
        }

        public ClsPersonajeDBZ() 
        { 
        
        }
        
        public ClsPersonajeDBZ(int idPersonaje)
        {
            this.idPersonaje = idPersonaje;
        }


        public ClsPersonajeDBZ (int id, String nombre, String foto)
        {
            this.idPersonaje = id;
            this.nombrePersonaje = nombre;
            this.fotoPersonaje = foto;
        }

    }
}
