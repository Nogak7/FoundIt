using FoundIt.ViewModel;

namespace FoundIt.Views;

public partial class Login : ContentPage
{
	public Login(LoginPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}