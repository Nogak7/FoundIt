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
        //����� �� ������ ����� ����
        LocationS = null;
        //���� �� ��� ���� �������� ����� �� ���� ���

    }
}