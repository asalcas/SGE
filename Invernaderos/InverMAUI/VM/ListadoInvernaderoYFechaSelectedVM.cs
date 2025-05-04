using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DTOs;
using ENT;
using InverMAUI.Utils;
using InverMAUI.Views;
using Microsoft.Maui.ApplicationModel.Communication;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace InverMAUI.VM
{
    public class ListadoInvernaderoYFechaSelectedVM : INotifyPropertyChanged
    {
        private List<ClsInvernadero> listadoInvernaderosCompleto;
        private ClsInvernadero invernaderoSelected;
        private DateTime fechaSelected;

        // Para poder hacer un comando dentro de una accion/boton
        private DelegateCommand navegarConDatos;


        // Para poder navegar es necesario crear un ATRIBUTO INavigation
        private INavigation navigation;



        public List<ClsInvernadero> ListadoInvernaderosCompleto
        {
            get { return listadoInvernaderosCompleto; }
        }
        public ClsInvernadero InvernaderoSelected
        {
            get { return invernaderoSelected; }
            set
            {
                invernaderoSelected = value;
                NotifyPropertyChanged(nameof(InvernaderoSelected));
                navegarConDatos.RaiseCanExecuteChanged();
            }
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

        // Esto es lo que me dice DONDE estoy yendo en el CODE BEHIND en MainPage.xaml.cs
        public INavigation Navigation
        {
            get { return navigation; }
            set { navigation = value; }
        }

        public ListadoInvernaderoYFechaSelectedVM()
        {
            navegarConDatos = new DelegateCommand(cambiarVistaCommand, puedeEjecutar); // Alomejor debo meter aqui los parametros
            this.listadoInvernaderosCompleto = BL.ListaClsInvernaderoBL.obtenerTodosLosInvernaderosBL();
            listadoInvernaderosCompleto.Insert(0, new ClsInvernadero(0, "-- Selecciona un invernadero --"));
            if (listadoInvernaderosCompleto.Count > 0)
            {
                InvernaderoSelected = listadoInvernaderosCompleto[0];
            }
            this.FechaSelected = DateTime.Now;
        }

        public async void cambiarVistaCommand()
        {
            Boolean navegar = false;

            try
            {
                navegar = BL.ListadoClsTemperaturaConInvernaderoYFecha.comprobacionFecha(FechaSelected);
            }
            catch(Exception ex) 
            {
                throw new Exception("Ha ocurrido un error al seleccionar datos, intentelo de nuevo", ex);
            }
            if (navegar == true)
            {
                if (invernaderoSelected != null && invernaderoSelected.IdInvernadero != 0)
                {

                    try
                    {
                        ClsTemperatura temperaturaPorFechaEID = BL.ListadoClsTemperaturaConInvernaderoYFecha.temperaturaPorInvernaderoYFecha(invernaderoSelected.IdInvernadero, FechaSelected); //
                        ClsInvernadero invernaderoPorID = BL.ListaClsInvernaderoBL.obtenerInvernaderoPorID(invernaderoSelected.IdInvernadero);
                        ClsTemperaturasConNombreInvernaderoYFecha dto = new ClsTemperaturasConNombreInvernaderoYFecha(invernaderoPorID, temperaturaPorFechaEID);

                        await Navigation.PushAsync(new DetallesTemperaturaPage(dto));

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ha ocurrido un error al instanciar el DTO en el VM", ex);
                    }
                }
            }
            else
            {
                muestraToast("Error: Has seleccionado una fecha no existente en nuestros registros, intentelo de nuevo con otra fecha.");
            }
            
        }
        public Boolean puedeEjecutar()
        {
            Boolean ejecutable = false;
            if (this.InvernaderoSelected.IdInvernadero != 0)
            {

                ejecutable = true;

            }
            return ejecutable;
        }


        #region INotifyPropertyChange

        // Implementación de INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        //

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion


        private async void muestraToast(string mensaje)
        {
            var toast = Toast.Make(mensaje, ToastDuration.Short, 14);
            await toast.Show();
        }
    }
}
