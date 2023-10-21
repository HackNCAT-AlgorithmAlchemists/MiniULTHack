using PersonalDictionary.ViewModels.Base;

namespace PersonalDictionary.Views.Base;

public abstract class ContentPageBase : ContentPage
{
	public ContentPageBase()
	{
		
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is not IViewModelBase ivmb)
        {
            return;
        }

        await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
    }
}