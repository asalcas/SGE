using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using ENT;
using MAUIRivals.Models.Utils;

namespace MAUIRivals.VM
{
    public class ListadoHeroesVillanosConPuntosVM : INotifyPropertyChanged
    {
        
        private ObservableCollection<ClsHeroeVillanoConPuntos> listaHeroesVillanosConPuntos;

        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<ClsHeroeVillanoConPuntos> ListaHeroesVillanosConPuntos
        {
            get { return listaHeroesVillanosConPuntos; }
            
        }

        //public DelegateCommand ActualizarLista
        //{
        //    get { return actualizarLista; }
        //}

        public ListadoHeroesVillanosConPuntosVM()
        {
            // En el constructor ya no es necesario rellenar la lista desde la base de datos, por que en el 'OnAppearing()' ya se está rellenando


                //try
                //{
                //    listaHeroesVillanosConPuntos = new ObservableCollection<ClsHeroeVillanoConPuntos>(BL.ListadoHeroesVillanosConPuntos.obtenerListadoCompletoConPuntos());
                //}
                //catch (Exception ex)
                //{
                //    muestraMensajes("Error inesperado:", "No se pudo obtener el listado de personajes de la Base de Datos, vuelva a intentarlo más tarde", "Entendido");

                //}
        }


        #region TASK
        
        // Estuve mirando documentación y para poder llamar desde el OnAppearing
        public async Task actualizacionLista()
        {
            try
            {
                //Casteamos y llamamos a la Base de Datos para traernos la lista completa de heroes y villanos NUEVA dentro de nuestra lista que tenemos como ATRIBUTO
                
                listaHeroesVillanosConPuntos = new ObservableCollection<ClsHeroeVillanoConPuntos>(BL.ListadoHeroesVillanosConPuntos.obtenerListadoCompletoConPuntos());

                // Y AHORA NOTIFICAMOS EL CAMBIO DE PROPIEDAD

                OnPropertyChanged(nameof(ListaHeroesVillanosConPuntos));
            
            }catch(Exception ex)
            {
                muestraMensajes("Error:", "No se pudo realizar la actualización correctamente. Intentelo mas tarde", "Entendido");
            }

        }

        #endregion

        #region DisplayAlert function
        private async void muestraMensajes(string cabecera, string mensaje, string confirmacion)
        {
            await Shell.Current.DisplayAlert(cabecera, mensaje, confirmacion);
        }
        #endregion

        // Implementación de INotifyPropertyChanged
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
