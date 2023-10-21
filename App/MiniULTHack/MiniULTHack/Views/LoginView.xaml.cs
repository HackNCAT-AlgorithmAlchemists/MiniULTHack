using MiniULTHack.ViewModels;
using PersonalDictionary.Views.Base;

namespace MiniULTHack.Views;

public partial class LoginView : ContentPageBase
{

	private readonly LoginViewModel _loginViewModel;

    public LoginView(LoginViewModel loginViewModel)
    {
        _loginViewModel = loginViewModel;
        BindingContext = _loginViewModel;
        InitializeComponent();
    }
}