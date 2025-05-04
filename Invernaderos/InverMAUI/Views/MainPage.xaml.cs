using InverMAUI.VM;

namespace InverMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            var vm = new ListadoInvernaderoYFechaSelectedVM();
            vm.Navigation = this.Navigation; // Aquí se pasa la navegación
            this.BindingContext = vm;
        }

        
    }

}
