using Microsoft.Extensions.Logging;

namespace MobileUI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts => fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddSingleton<IAppKeys, AppKeys>();
        builder.Services.AddSingleton<IDisplay, Display>();
        builder.Services.AddSharedUI(SharedUIPlatform.MAUI);

#if DEBUG && !WINDOWS
        AppConsts.APIClient.APIBaseURL = "https://10.0.2.2:5001";
#endif

#if DEBUG
    builder.Services.AddBlazorWebViewDeveloperTools();
    builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}