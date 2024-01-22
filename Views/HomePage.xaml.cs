using FoundIt.ViewModel;

namespace FoundIt.Views;

public partial class HomePage : ContentPage
{
	public HomePage( HomePageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        HomePageViewModel viewModel = (HomePageViewModel)BindingContext;
        ((App)Application.Current).PostStatuses = await viewModel.service.GetPostStatus();
    }
}