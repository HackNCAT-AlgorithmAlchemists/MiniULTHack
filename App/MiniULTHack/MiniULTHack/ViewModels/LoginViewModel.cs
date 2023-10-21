using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniULTHack.Services;
using MiniULTHack.ViewModels.Base;

namespace MiniULTHack.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {

        public static string Route => "Login";

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _gatewayIp;

        [ObservableProperty]
        private bool hasError = false;


        private readonly INavigationService _navigationService;
        private readonly IConnectionService _loginService;

        public LoginViewModel(INavigationService navigationService, IConnectionService loginService) : base(navigationService)
        {
            _navigationService = navigationService;
            _loginService = loginService;
        }

        [RelayCommand]
        private async Task Login()
        {
            if (!_loginService.Login(GatewayIp, Username, Password))
            {
                HasError = true;
                return;
            }

            string log = _loginService.GetLogRaw();
            
            await _navigationService.NavigateToAsync(LogViewModel.Route);

        }


    }
}
