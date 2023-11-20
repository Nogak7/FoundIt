using FoundIt.Views;
namespace FoundIt
{

	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute("Register", typeof(Register));
		}
	}
}

