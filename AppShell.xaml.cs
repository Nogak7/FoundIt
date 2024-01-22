using FoundIt.Models;
using FoundIt.Views;
using System.Text.Json;

namespace FoundIt
{

	public partial class AppShell : Shell
	{
		public User user { get; set; }
		public AppShell()
		{
			InitializeComponent();
			
            Routing.RegisterRoute("LogIn", typeof(Login));
            Routing.RegisterRoute("HomePage", typeof(HomePage));
            Routing.RegisterRoute("Register", typeof(Register));
			Routing.RegisterRoute("CreateNewPost", typeof(CreateNewPost));
        }
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var content = await SecureStorage.Default.GetAsync("user");
			if(content != null) 
			{
				user = JsonSerializer.Deserialize<User>(content);
                await AppShell.Current.GoToAsync("HomePage");
            }
		}

	}
}

