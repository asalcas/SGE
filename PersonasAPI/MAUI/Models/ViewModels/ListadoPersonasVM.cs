using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ENT;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.utils;
using System.Windows.Input;

namespace MAUI.Models.ViewModels
{
    public class ListadoPersonasVM : ICommand
    {
        #region Atributos
        private ObservableCollection<ClsPersona> listadoPersonas;

        private DelegateCommand verListado;
        #endregion

        #region Propiedades

        public event EventHandler? CanExecuteChanged;

        public ObservableCollection<ClsPersona> ListadoPersonas
        {
            get {  return listadoPersonas; }
        }

        public DelegateCommand VerListado
        {
            get { return verListado; }
        }

        #endregion

        #region Constructores
        public ListadoPersonasVM()
        {

        }
        public ListadoPersonasVM(ObservableCollection<ClsPersona> lista)
        {
            Task<List<ClsPersona>> obtencionPersonas = BL.ListadoPersonasBL.obtenerListaCompletaPersonasBL();
            // rellenar la lista que bindearemos despues 'listadoPersonas'
        }

        #endregion


        #region Commands

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
