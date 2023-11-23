using System;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;
using FoundIt.Models;

namespace FoundIt.ViewModel
{
    public class RegisterPageViewModel : ViewModel
    {

        #region Fieldes

        private string firstname;
        private string lastname;
        private string email;
        private string username;
        private string password;
        private string confirmpassword;
        private string message;


        #endregion

        #region Properties

        public string Message { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }

        public bool ShowmessageUserName { get; set; }
        public bool ShowmessageFirstName { get; set; }
        public bool ShowmessageLastName { get; set; }
        public bool ShowmessageEmail { get; set; }
        public bool ShowmessagePassword { get; set; }
        public bool ShowmessageConfirmPassword { get => Password != ConfirmPassword; } 
        public string UserName
        {
            get => username;
            set
            {

                if (username != value)
                {
                    username = value;
                    if (ValidName(value))
                        ShowmessageUserName = false;
                    else
                    {
                        ShowmessageUserName = true;
                        Message = Models.Messages.INVALID_NAME;

                    }
                    OnPropertyChange();
                    OnPropertyChange(nameof(ShowmessageUserName));
                }

            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value; 
                    if (!ValidatePassWord())
                    {
                        Message = Models.Messages.INVALID_PASSWORD;
                        ShowmessagePassword = true;    
                    }
                    else
                    {
                        ShowmessagePassword = false;    
                    };
                    OnPropertyChange();
                    OnPropertyChange(nameof(ShowmessagePassword)); 
                    OnPropertyChange(nameof(ShowmessageConfirmPassword));   
                }
            }
        }

        public string Email { get => email; set { if (email != value) { email = value; OnPropertyChange(); } } }
        public string FirstName { get => firstname; set { if (firstname != value) { firstname = value; OnPropertyChange(); } } }
        public string LastName { get => lastname; set { if (lastname != value) { firstname = value; OnPropertyChange(); } } }
        public string ConfirmPassword
        {
            get => confirmpassword;
            set
            {
                if(confirmpassword != value ) 
                {
                  confirmpassword = value;
                    if(Password!=ConfirmPassword) 
                    {
                        ///
                    }

                    
                }
                OnPropertyChange();
                OnPropertyChange(nameof(ShowmessageConfirmPassword));
            }
        }
        #endregion

        #region Helpers


        
        
        
        public bool ValidName(string name)
        {
           
            //לפי השגיאה
            return !(string.IsNullOrEmpty(name) ||name.Length<3);
        }
        private bool ValidatePassWord()
        {
            //לפי השגיאה
            return !string.IsNullOrEmpty(Password);
        }
       
        #endregion

    }
    
}
