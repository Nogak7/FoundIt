using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

        private FoundItService createPostService;
        public bool ShowmessageUploudNewPostFailed { get; set; }


        public string Theme { get => theme; set { if (theme != value) { theme = value; OnPropertyChange(); } } }
        public string Context { get => context; set { if (context != value) { context = value; OnPropertyChange(); } } }
        public bool FoundItem { get => founditem; set { if (founditem != value) { founditem = value; OnPropertyChange(); } } }
        public string Picture { get => picture; set { if (picture != value) { picture = value; OnPropertyChange(); } } }
        public string PictureLocation { get => picture; set { if (value != picture) { picture = value; OnPropertyChange(); } } }
        public User Creator { get => creator; set { if (creator != value) { creator = value; OnPropertyChange(); } } }
        public string Location { get => location; set { if (location != value) { location = value; OnPropertyChange(); } } }
        public PostStatus Status { get => status; set { if (status != value) { status = value; OnPropertyChange(); } } }

        public ImageSource PhotoImageSource { get; set; }

        #region Commands
        public ICommand CreateNewPostCommand { get; set; }
        public ICommand UploadPhoto { get; protected set; }

        public ICommand TakePictureCommand { get; protected set; }
        public ICommand PutPictureCommand { get; protected set; }
        public ICommand ChangePhoto { get; protected set; }
        #endregion


       

            public CreateNewPostViewModel(FoundItService service)
            {
               createPostService = service;
             UploadPhoto = new Command(UploudPicture) ;
               TakePictureCommand = new Command(TakePicture);
               ChangePhoto = new Command(TakePicture);
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



                #region helpers


            }
        private async void TakePicture()
        {
            //נכון לכרגע (נובמבר 2023) יש בעיה בתמיכה בווינדוס
            //#זו דרך לייצר תנאים ברמת הקומפילציה לפני זמן ריצה

#if ANDROID || IOS
            try
            {
                FileResult photo = null;

                //אם יש תמיכה במצלמה
                //יש לשים לב שעל מנת שיהיה ניתן להשתמש במצלמה צריך לתת הרשאות
                //https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker?tabs=android#tabpanel_1_android

                if (MediaPicker.Default.IsCaptureSupported)
                {
                    //חייבים להריץ ב
                    //UI
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        photo = await MediaPicker.Default.CapturePhotoAsync();

                        #region מסך טעינה
                        AlertsViewModel vm = new AlertsViewModel() { AlertMessage = "....", AlertShowMessage = true };
                        await Task.Delay(1000);
                        await Shell.Current.Navigation.PushModalAsync(new Alerts(vm));
                        #endregion

                        //הצגת התמונה במסך ושליחתה לממשק.
                        await LoadPhoto(photo);

                        #region סגירת מסך טעינה
                        await Shell.Current.Navigation.PopModalAsync();
                        #endregion

                    });
                }

            }
            catch (Exception ex) { }
#elif WINDOWS
              Shell.Current.DisplayAlert("לא נתמך", "כרגע לא ניתן להשתמש", "אישור");
#endif


        }

        private async void UploudPicture()
        {
            //נכון לכרגע (נובמבר 2023) יש בעיה בתמיכה בווינדוס
            //#זו דרך לייצר תנאים ברמת הקומפילציה לפני זמן ריצה

#if ANDROID || IOS
            try
            {
                FileResult photo = null;

                //אם יש תמיכה במצלמה
                //יש לשים לב שעל מנת שיהיה ניתן להשתמש במצלמה צריך לתת הרשאות
                //https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker?tabs=android#tabpanel_1_android

                if (MediaPicker.Default.IsCaptureSupported)
                {
                    //חייבים להריץ ב
                    //UI
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        photo = await MediaPicker.Default.PickPhotoAsync();

                        #region מסך טעינה
                        AlertsViewModel vm = new AlertsViewModel() { AlertMessage = "....", AlertShowMessage = true };
                        await Task.Delay(1000);
                        await Shell.Current.Navigation.PushModalAsync(new Alerts(vm));
                        #endregion

                        //הצגת התמונה במסך ושליחתה לממשק.
                        await LoadPhoto(photo);

                        #region סגירת מסך טעינה
                        await Shell.Current.Navigation.PopModalAsync();
                        #endregion

                    });
                }

            }
            catch (Exception ex) { }
#elif WINDOWS
              Shell.Current.DisplayAlert("לא נתמך", "כרגע לא ניתן להשתמש", "אישור");
#endif


        }
        private async Task LoadPhoto(FileResult photo)
            {
                try
                {

                    var stream = await photo.OpenReadAsync();
                    PhotoImageSource = ImageSource.FromStream(() => stream);
                    OnPropertyChange(nameof(PhotoImageSource));
                    await Upload(photo);


                }
                catch (Exception ex) { }
            }
            private async Task Upload(FileResult file)
            {

                try
                {

                    // bool success = await createPostService.UploadPhoto(file);
                    bool success = await createPostService.UploadFile(file);
                    if (success)
                    {
                        var u = JsonSerializer.Deserialize<User>(await SecureStorage.Default.GetAsync("LoggedUser"));
                        PictureLocation = await createPostService.GetImage() + $"{u.Id}.jpg";
                    }
                    else
                        Shell.Current.DisplayAlert("אין קשר לשרת", "לא הצלחתי להעלות את התמונה. נסה שוב", "אישור");
                }
                catch (Exception ex) { }

            }


            #endregion

        }
    }
    

