using Microsoft.Extensions.Logging;

namespace EldanHildesheim_Calculator
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
            fonts.AddFont("digital-7mono.ttf", "Digital");
          });

#if DEBUG
  		builder.Logging.AddDebug();
#endif

      return builder.Build();
    }
  }
}
