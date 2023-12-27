using FoundIt.ViewModel;

namespace FoundIt.Views;

public partial class WelcomePage : ContentPage
{
	public WelcomePage(WelcomePageViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}