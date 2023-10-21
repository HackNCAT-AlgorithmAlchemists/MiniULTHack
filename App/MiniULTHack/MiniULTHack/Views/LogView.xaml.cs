using MiniULTHack.ViewModels;
using PersonalDictionary.Views.Base;

namespace MiniULTHack.Views;

public partial class LogView : ContentPageBase
{

	private readonly LogViewModel _viewModel;

    public LogView(LogViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }
}