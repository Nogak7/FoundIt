using FoundIt.Views;
namespace FoundIt
{

	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			
            Routing.RegisterRoute("LogIn", typeof(Login));
        }
	}
}

