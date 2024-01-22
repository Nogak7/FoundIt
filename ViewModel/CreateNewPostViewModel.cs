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
        private string location;
        private PostStatus status;


        public bool ShowmessageUploudNewPostFailed { get; set; }


        public string Theme { get => theme; set { if (theme != value) { theme = value; OnPropertyChange(); } } }
        public string Context { get => context; set { if (context != value) { context = value; OnPropertyChange(); } } }
        public bool FoundItem { get => founditem; set { if (founditem != value) { founditem = value; OnPropertyChange(); } } }
        public string Picture { get => picture; set { if (picture != value) { picture = value; OnPropertyChange(); } } }
        public User Creator { get => creator; set { if (creator != value) { creator = value; OnPropertyChange(); } } }
        public string Location { get => location; set { if (location != value) { location = value; OnPropertyChange(); } } }
        public PostStatus Status { get => status; set { if (status != value) { status = value; OnPropertyChange(); } } }


        public ICommand CreateNewPostCommand { get; set; }
        public CreateNewPostViewModel(FoundItService service)
        {
            CreateNewPostCommand = new Command(async () =>
            {
                try
                {
                    AlertsViewModel vm = new AlertsViewModel() { AlertMessage = "Uploading Post....", AlertShowMessage = true };
                    await Shell.Current.Navigation.PushModalAsync(new Alerts(vm));
                    App currentApp = (App)Application.Current;
                    Post newPost = new Post()
                    { Theme = Theme, Context = Context, FoundItem = FoundItem, Picture = Picture, Creator = currentApp.User, CreatingDate = DateTime.Now, Location = Location, Status = currentApp.PostStatuses.Find(x => x.Id == 1) };
                    var response = await service.CreateNewPostAsync(newPost);
                    if (response)
                    {
                        vm.AlertShowMessage = false;
                        vm.AlertMessage = "Post Uploud Succeeded";
                        await Task.Delay(1500);
                        await Shell.Current.Navigation.PopModalAsync();
                        await AppShell.Current.GoToAsync("HomePage");
                    }
                    else
                    {
                        vm.AlertShowMessage = false;
                        vm.AlertMessage = ErrorMessages.REGISTER_FAILED;
                        await Task.Delay(1500);
                        await Shell.Current.Navigation.PopAsync();
                    }
                    OnPropertyChange(nameof(ShowmessageUploudNewPostFailed));
                }
                catch (Exception ex) { }

            });

        }
    }
}
