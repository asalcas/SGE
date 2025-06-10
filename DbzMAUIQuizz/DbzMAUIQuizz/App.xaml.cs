

namespace DbzMAUIQuizz
{
    public partial class App : Application
    {
        public static IServiceProvider Servicios =>
        Current?.Handler?.MauiContext?.Services;
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(App.Servicios.GetService<MainPage>());
        }
    }
}
