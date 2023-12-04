
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

namespace FoundIt.ViewModel
{

    public class LoginPageViewModel : ViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;
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
                    var response = await service.LogInAsync(UserName, Password); 
                    if (response)
                    {
                        await AppShell.Current.GoToAsync("HomePage");
                    }
                    else
                    {
                        ShowmessageLogInFailed = true;
                        LogInFailedMessage = Models.Messages.LOGIN_FAILED; 
                    }
                    OnPropertyChange(nameof(ShowmessageLogInFailed));
                }
                catch (Exception ex) { }

            });

        }
    }
}

