using Microsoft.Extensions.Logging;

namespace DbzMAUIQuizz
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SourceCodePro-VariableFont_wght.ttf", "SourceCode");
                    fonts.AddFont("Saiyan-Sans.ttf", "StandardDBZ");
                    fonts.AddFont("Saiyan-Sans Left Oblique.ttf", "IzquierdaDBZ");
                    fonts.AddFont("Saiyan-Sans Right Oblique.ttf", "DerechaDBZ");
                    fonts.AddFont("ARCADE_N.ttf", "Arcade");

                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
