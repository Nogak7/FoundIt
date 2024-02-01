using FoundIt.ViewModel;
using System.Collections.ObjectModel;

namespace FoundIt.Views;

public partial class CreateNewPostPage : ContentPage
{
	public CreateNewPostPage(CreateNewPostViewModel vm)
	{
		this.BindingContext = vm;
		InitializeComponent();

         Locations = new ObservableCollection<Location>();
        //נאתחל את התלמיד הבודד לריק
        LocationS = null;
        //נקשר את הדף שלנו לאובייקט המכיל את הקוד שלו

    }
}