using FoundIt.ViewModel;

namespace FoundIt.Views;

public partial class Register : ContentPage
{
	public Register(RegisterPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}