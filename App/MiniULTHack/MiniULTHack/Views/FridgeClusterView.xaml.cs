using MiniULTHack.ViewModels;
using PersonalDictionary.Views.Base;

namespace MiniULTHack.Views;

public partial class FridgeClusterView : ContentPageBase
{

	private readonly FridgeClusterViewModel _viewModel;

    public FridgeClusterView(FridgeClusterViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }
}