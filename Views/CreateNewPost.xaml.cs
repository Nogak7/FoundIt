using FoundIt.ViewModel;

namespace FoundIt.Views;

public partial class CreateNewPost : ContentPage
{
	public CreateNewPost(CreateNewPostViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();
	}
}