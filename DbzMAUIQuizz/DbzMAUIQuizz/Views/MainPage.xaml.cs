using DbzMAUIQuizz.Models.VM;
using Plugin.Maui.Audio;

namespace DbzMAUIQuizz
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            if(this.BindingContext is PartidaQuizzVM vm)
            {
                vm.Dispatcher = this.Dispatcher;
            }
        }

    }


}


