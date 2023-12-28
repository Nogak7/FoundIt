
using System;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;
using FoundIt.Models;
using System.Text.RegularExpressions;
using System.Windows.Input;
using FoundIt.Services;
using System.Text.Json;
using FoundIt.Views;

namespace FoundIt.ViewModel
{
    //

    public class LoginPageViewModel : ViewModel
	{
		
        public ICommand LogInCommand { get; set; }
        private string username;
		private string password;
        private string message;

        public string UserNameMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }
        public string PasswordMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }
        public string LogInFailedMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }

        public bool ShowmessageUserName { get; set; }
        public bool ShowmessagePassword { get; set; }
        public bool ShowmessageLogInFailed { get; set; }
        public string UserName
        {
            get => username;
            set  { if (username != value) { username = value; OnPropertyChange(); } }
        }
        public string Password
        {
            get => password;
            set { if (password != value) { password = value; OnPropertyChange(); } }
        }

        public LoginPageViewModel(FoundItService service)
        {
             LogInCommand = new Command(async () =>
              {
                try
                {
                      AlertsViewModel vm = new AlertsViewModel() { AlertMessage = "Connecting to server....", AlertShowMessage = true };
                      await Shell.Current.Navigation.PushModalAsync(new Alerts(vm));
                      var response = await service.LogInAsync(UserName, Password); 
                    if (response)
                    {
                          vm.AlertShowMessage = false;
                          vm.AlertMessage = "Register Succeeded";
                          await Task.Delay(1500);
                          await Shell.Current.Navigation.PopModalAsync();
                          await AppShell.Current.GoToAsync("HomePage");
                    }
                    else
                    {
                          LoginDto user = new LoginDto(UserName , Password);
                          await SecureStorage.Default.SetAsync("user", JsonSerializer.Serialize(user));
                          vm.AlertShowMessage = false;
                          vm.AlertMessage = "Log In failed, please try again ";
                          await Task.Delay(1500);
                          await Shell.Current.Navigation.PopAsync();
                    }
                    OnPropertyChange(nameof(ShowmessageLogInFailed));
                }
                catch (Exception ex) { }

            });

        }
    }
}

