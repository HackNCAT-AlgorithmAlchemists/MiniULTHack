using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniULTHack.Models;
using MiniULTHack.Services;
using MiniULTHack.ViewModels.Base;
using System.Collections.ObjectModel;

namespace MiniULTHack.ViewModels
{
    public partial class FridgeClusterViewModel : ViewModelBase
    {
        public static string Route => "Cluster";

        [ObservableProperty]
        private FridgeModel _selectedModel;

        private ObservableCollection<FridgeModel> _fridgeSerialNumbers;


        private readonly INavigationService _navigationService;
        private readonly IConnectionService _connectionService;

        public FridgeClusterViewModel(INavigationService navigationService, IConnectionService connectionService) : base(navigationService)
        {
            _connectionService = connectionService;
        }

        public override Task InitializeAsync()
        {
            //TODO read fridges
            return base.InitializeAsync();
        }

        [RelayCommand]
        private async Task NavigateFridge()
        {
            if (SelectedModel == null) return;
            await _navigationService.NavigateToAsync(Route,
                new Dictionary<string, object> { { FridgeViewModel.RouteParameter, SelectedModel } });
        }


    }
}
