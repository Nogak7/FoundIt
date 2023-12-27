using FoundIt.ViewModel;

namespace FoundIt.Views;

public partial class Alerts : ContentPage
{
	public Alerts(AlertsViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}