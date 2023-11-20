using System;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;
using FoundIt.Models;

namespace FoundIt.ViewModel
{
	public class RegisterPageViewModel:ViewModel
	{

        #region Fieldes

        private string firstname;
		private string lastname;
		private string  email;
		private string username;
		private string password;
		private string confirmpassword;
		private bool showmessage;
		private string message;

        #endregion

        #region Properties

		public string UserName
		{
			get => username;
			set {

				if (username!=value && ValidName(firstname))
				{
					 firstname = value;
					 OnPropertyChange();
					
			   	}
				else
				{
					message = Models.Messages.INVALID_NAME;
                    Console.WriteLine(message); ;
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
                    password = value; if (!ValidatePassWord())
                    {
                       message = Models.Messages.INVALID_PASSWORD;
                    }
                    else
                    {

                    };
                    OnPropertyChange();
                }
            }
        }


        #endregion

        #region Helpers

        public bool ValidName(string name)
		{
            //לפי השגיאה
            return !(string.IsNullOrEmpty(name) || name.Length < 3);
        }
        private bool ValidatePassWord()
        {
            //לפי השגיאה
            return !string.IsNullOrEmpty(Password);
        }
        #endregion

    }
}


