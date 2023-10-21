using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniULTHack.Services;
using MiniULTHack.ViewModels.Base;

namespace MiniULTHack.ViewModels
{
    public partial class LogViewModel : ViewModelBase
    {
        public static string Route => "Log";

        [ObservableProperty]
        private string _logText;

        private readonly IConnectionService _connectionService;

        public LogViewModel(INavigationService navigationService, IConnectionService connectionService) : base(navigationService)
        {
            _connectionService = connectionService;
        }

        public override Task InitializeAsync()
        {
            RefreshLog();
            return base.InitializeAsync();
        }

        [RelayCommand]
        private void RefreshLog()
        {
            LogText = _connectionService.GetLogRaw();
        }
    }
}
