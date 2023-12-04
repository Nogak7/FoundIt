using FoundIt.ViewModel;

namespace FoundIt.Views;

public partial class HomePage : ContentPage
{
	public HomePage( HomePageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}