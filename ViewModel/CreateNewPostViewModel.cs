using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FoundIt.Models;
using FoundIt.Services;
using FoundIt.Views;

namespace FoundIt.ViewModel
{
    public class CreateNewPostViewModel : ViewModel
    {
        private string theme;
        private string context;
        private bool founditem;
        private string picture;
        private User creator;
        private DateTime creatingdate;
        private string location;
        private PostStatus status;




        public string Theme { get => theme; set { if (theme != value) { theme = value; OnPropertyChange(); } } }
        public string Context { get => context; set { if (context != value) { context = value; OnPropertyChange(); } } }
        public bool FoundItem { get => founditem; set { if (founditem != value) { founditem = value; OnPropertyChange(); } } }
        public string Picture { get => picture; set { if (picture != value) { picture = value; OnPropertyChange(); } } }
        public User Creator { get => creator; set { if (creator != value) { creator = value; OnPropertyChange(); } } }
        public DateTime CreatingDate { get => creatingdate; set { if (creatingdate != value) { creatingdate = value; OnPropertyChange(); } } }
        public string Location { get => location; set { if (location != value) { location = value; OnPropertyChange(); } } }
        public PostStatus Status { get => status; set { if (status != value) { status = value; OnPropertyChange(); } } }


        public ICommand CreatePostCommand { get; set; }
        public CreateNewPostViewModel(FoundItService service)
        {
            CreatePostCommand = new Command(async () =>
            {
                try
                {
                    AlertsViewModel vm = new AlertsViewModel() { AlertMessage = "Uploading Post....", AlertShowMessage = true };
                    await Shell.Current.Navigation.PushModalAsync(new Alerts(vm));
                    var response = await service.RegisterAsync(new Post() { Theme = Theme, Context = Context, FoundItem = FoundItem, Picture = Picture, Creator = Creator, CreatingDate = CreatingDate, Location = Location, Status = Status };
                    if (response)
                    {
                        vm.AlertShowMessage = false;
                        vm.AlertMessage = "Register Succeeded";
                        await Task.Delay(1500);
                        await Shell.Current.Navigation.PopModalAsync();
                        await AppShell.Current.GoToAsync("LogIn");
                    }
                    else
                    {
                        vm.AlertShowMessage = false;
                        vm.AlertMessage = ErrorMessages.REGISTER_FAILED;
                        await Task.Delay(1500);
                        await Shell.Current.Navigation.PopAsync();
                    }
                    OnPropertyChange(nameof(ShowmessageRegisterFailed));
                }
                catch (Exception ex) { }

            });

        }
    }
}
