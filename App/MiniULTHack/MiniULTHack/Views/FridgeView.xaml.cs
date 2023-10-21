using MiniULTHack.ViewModels;
using PersonalDictionary.Views.Base;

namespace MiniULTHack.Views;

public partial class FridgeView : ContentPageBase
{

	private readonly FridgeViewModel _viewModel;

    public FridgeView(FridgeViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = _viewModel;
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }

}