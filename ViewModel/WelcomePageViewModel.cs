using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoundIt.ViewModel
{
    public class WelcomePageViewModel : ViewModel
    {
        public ICommand RegisterCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        public WelcomePageViewModel()
        {
            RegisterCommand = new Command(async () =>
            {
                await AppShell.Current.GoToAsync("Register");
            });
            LogInCommand = new Command(async () =>
            {
                await AppShell.Current.GoToAsync("LogIn");
            });
        }
       
    }
}
