using Microsoft.Extensions.Logging;
using MiniULTHack.Services;
using MiniULTHack.Services.Login;
using MiniULTHack.ViewModels;
using MiniULTHack.Views;

namespace MiniULTHack;

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
            })
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();
        appBuilder.Services.AddSingleton<IConnectionService, SshLoginService>();

        return appBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddSingleton<LoginViewModel>();
        appBuilder.Services.AddSingleton<LogViewModel>();
        appBuilder.Services.AddSingleton<FridgeClusterViewModel>();
        appBuilder.Services.AddSingleton<FridgeViewModel>();

        return appBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder appBuilder)
    {
        appBuilder.Services.AddTransient<LoginView>();
        appBuilder.Services.AddTransient<LogView>();
        appBuilder.Services.AddTransient<FridgeView>();
        appBuilder.Services.AddTransient<FridgeClusterView>();

        return appBuilder;
    }
}
