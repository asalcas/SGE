
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using ENT;
using ViewModels.utils;



namespace MAUI.Models.ViewModels
{
    public class ListadoPersonasVM : INotifyPropertyChanged
    {
        #region Atributos

        private ObservableCollection<ClsPersona> listadoPersonas;
        private ObservableCollection<ClsPersona> listadoAuxiliar;
        private String textoFiltro;

        public DelegateCommand miCommand;

        #endregion

        #region Propiedades

        public event EventHandler? CanExecuteChanged;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get {  return listadoPersonas; }
        }
        public ObservableCollection<ClsPersona> ListadoAuxiliar
        {
            get { return listadoAuxiliar; }
            set { listadoAuxiliar = value; }
        }
        

        public String TextoFiltro
        {
            get { return textoFiltro; }
            set {
                if (textoFiltro != value)
                {
                    textoFiltro = value;
                    OnPropertyChanged(nameof(TextoFiltro));
                    filtrarPorNombre();
                }
            }
        }

        public DelegateCommand MiCommand
        {
            get { return miCommand; }
        }
        #endregion

        #region Constructores
       
        public ListadoPersonasVM()
        {
            listadoPersonas = new ObservableCollection<ClsPersona>();

            // Lambda:
            // - (): Son los parametros que recibirá
            // - async: Lo dice el nombre, marca la funcion como Asincrona
            // - =>: Separa la lista de parametros () del cuerpo de la lambda (funcion que realizará)
            // - await verListado_execute(): El cuerpo de la lambda que al darle al boton se ejecutara y estara en espera hasta que ver listado acabe

            miCommand = new DelegateCommand(() => verListado_execute());

        }



        #endregion
        #region Funciones
        /// <summary>
        /// Función que realizara una búsqueda en la lista con .Where para devolvernos los casos que contenga lo que guarda la variable 'textoFiltro'
        /// </summary>
        /// <returns></returns>
        private async Task filtrarPorNombre()
        {
            if (textoFiltro != string.Empty)
            {
                try
                {
                    listadoPersonas = new ObservableCollection<ClsPersona>(listadoPersonas.Where(persona => persona.Nombre.ToLower().Contains(textoFiltro)));
                    OnPropertyChanged(nameof(ListadoPersonas));

                }
                catch (Exception ex)
                {
                    mostrarMensaje("Error:", "No ha sido posible el filtrado", "Entendido");
                }


            }
            else
            {
                listadoPersonas = ListadoAuxiliar;
                OnPropertyChanged(nameof(ListadoPersonas));



            

            }
            
        }
        #endregion


        #region DisplayAlert

        public async void mostrarMensaje(String cabecera, String mensaje, String confirmacion)
        {
            await Shell.Current.DisplayAlert(cabecera, mensaje, confirmacion);
        }

        #endregion

        #region Commands

        private async void verListado_execute()
        {

            try
            {
                ObservableCollection<ClsPersona> listadoAsincronoPersonas = await BL.ListadoPersonasBL.obtenerListaCompletaPersonasBL();
                
                listadoPersonas = listadoAsincronoPersonas;
                listadoAuxiliar = listadoAsincronoPersonas;
                OnPropertyChanged(nameof(ListadoPersonas));

            }catch(Exception ex)
            {
                mostrarMensaje("Error:", "El execute falló a la hora de actualizar la lista", "Entendido");
            }

            
        }

        #endregion

        #region Notify
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
