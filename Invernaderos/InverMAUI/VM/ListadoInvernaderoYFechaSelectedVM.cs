using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DTOs;
using ENT;
using InverMAUI.Utils;
using Microsoft.Maui.ApplicationModel.Communication;

namespace InverMAUI.VM
{
    public class ListadoInvernaderoYFechaSelectedVM 
    {
        private List<ClsInvernadero> listadoInvernaderosCompleto;
        private ClsInvernadero invernaderoSelected;
        private DateTime fechaSelected;
        private DelegateCommand navegarConDatos;

        public List<ClsInvernadero> ListadoInvernaderosCompleto
        {
            get { return listadoInvernaderosCompleto; }
        }
        public ClsInvernadero InvernaderoSelected
        {
            get { return invernaderoSelected; }
            set { invernaderoSelected = value; }
        }

        public DateTime FechaSelected
        {
            get { return fechaSelected; }
            set { fechaSelected = value; }
        }

        public DelegateCommand NavegarConDatos
        {
            get { return navegarConDatos; }
        }
        public ListadoInvernaderoYFechaSelectedVM()
        {
            navegarConDatos = new DelegateCommand(navegarVista2); // Alomejor debo meter aqui los parametros
            this.listadoInvernaderosCompleto = BL.ListaClsInvernaderoBL.obtenerTodosLosInvernaderosBL();
            listadoInvernaderosCompleto.Insert(0, new ClsInvernadero(0, "-- Selecciona un invernadero --"));
            if (listadoInvernaderosCompleto.Count > 0)
            {
                InvernaderoSelected = listadoInvernaderosCompleto[0];
            }
            this.FechaSelected = DateTime.Now;
        }

        public async Task navegarVista2(int id, DateTime fecha)
        {
            // Quiza creo mi objeto: ClsTemperaturasConNombreInvernaderoYFecha objetoMandar = ;
            // Código correcto para realizar la navegación
            await Shell.Current.GoToAsync(); // Y se lo mando aqui
        }
        public Boolean puedeEjecutar()
        {
            Boolean ejecutable = false;
            if(this.InvernaderoSelected.IdInvernadero != 0)
            {
                ejecutable = true;
            }
            return ejecutable;
        }
    }
}
