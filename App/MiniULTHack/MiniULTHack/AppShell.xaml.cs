using MiniULTHack.Services;
using MiniULTHack.ViewModels;
using MiniULTHack.Views;

namespace MiniULTHack;

public partial class AppShell : Shell
{
    private readonly INavigationService _navigationService;
    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;
        InitializeRouting();

        InitializeComponent();
    }

    private static void InitializeRouting()
    {
        Routing.RegisterRoute(FridgeClusterViewModel.Route, typeof(FridgeClusterView));
        Routing.RegisterRoute(FridgeViewModel.Route, typeof(FridgeView));
        Routing.RegisterRoute(LogViewModel.Route, typeof(LogView));

    }
}
