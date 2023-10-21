using CommunityToolkit.Mvvm.ComponentModel;
using MiniULTHack.Models;
using MiniULTHack.Services;
using MiniULTHack.ViewModels.Base;

namespace MiniULTHack.ViewModels
{
    [QueryProperty(nameof(this.Fridge), RouteParameter)]
    public partial class FridgeViewModel : ViewModelBase
    {
        public static string Route => "Fridge";
        public const string RouteParameter = "FridgeModel";

        public FridgeModel Fridge { get; private set; }

        [ObservableProperty]
        private int _maxTemp;

        [ObservableProperty]
        private int _minTemp;

        [ObservableProperty]
        private string _statusText;

        private readonly INavigationService _navigationService;
        private readonly IConnectionService _connectionService;

        public FridgeViewModel(INavigationService navigationService, IConnectionService connectionService) : base(navigationService)
        {
            _navigationService = navigationService;
            _connectionService = connectionService;
        }

        public override Task InitializeAsync()
        {
            MaxTemp = Fridge.MaximumTemperature;
            MinTemp = Fridge.MinimumTemperature;

            //TODO get status 

            return base.InitializeAsync();
        }




    }
}
