using DbzMAUIQuizz.VM;

namespace DbzMAUIQuizz
{
    public partial class MainPage : ContentPage
    {


        public MainPage(PartidaQuizzVM vm)
        {
            InitializeComponent();
            BindingContext = vm;

        }

    }


}


