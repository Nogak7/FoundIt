﻿using System;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;
using FoundIt.Models;
using System.Text.RegularExpressions;

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

        public string EmailMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }
        public string FirstNameMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }
        public string LastNameMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }
        public string UserNameMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }
        public string PasswordMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }
        public string ConfirmPaswordMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }

        public bool ShowmessageUserName { get; set; }
        public bool ShowmessageFirstName { get; set; }
        public bool ShowmessageLastName { get; set; }
        public bool ShowmessageEmail { get; set; }
        public bool ShowmessagePassword { get; set; }
        public bool ShowmessageConfirmPassword { get => Password != ConfirmPassword; }
        public string FirstName { get => firstname; set { if (firstname != value) { firstname = value; OnPropertyChange(); } } }
        public string LastName { get => lastname; set { if (lastname != value) { lastname = value; OnPropertyChange(); } } }
        public string Email 
        { 
            get => email; 
            set 
            { 
                if (email != value) 
                {
                    email = value;
                    if(IsValidEmail())
                    {
                         ShowmessageEmail = false;
                    }
                    else
                    {
                        ShowmessageEmail = true;
                        EmailMessage = Models.Messages.INVALID_EMAIL;
                    }                                    
                    OnPropertyChange();
                    OnPropertyChange(nameof(ShowmessageEmail));
                } } }
        public string UserName
        {
            get => username;
            set
            {

                if (username != value)
                {
                    username = value;
                    if (ValidUserName(value))
                        ShowmessageUserName = false;
                    else
                    {
                        ShowmessageUserName = true;
                        UserNameMessage = Models.Messages.INVALID_NAME;

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
                        PasswordMessage = Models.Messages.INVALID_PASSWORD;
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
                        ConfirmPaswordMessage = Models.Messages.UNMATCHING_PASSWORDS;

                    }

                    
                }
                OnPropertyChange();
                OnPropertyChange(nameof(ShowmessageConfirmPassword));
            }
        }
        #endregion

        #region Helpers


        
        
        
        public bool ValidUserName(string name)
        {
           
            //לפי השגיאה
            return !(string.IsNullOrEmpty(name) ||name.Length<3 );
        }
        private bool ValidatePassWord()
        {
            //לפי השגיאה
            return !string.IsNullOrEmpty(Password);
        }
       public bool ValidName(string name)
        {
            return ((!(string.IsNullOrEmpty(name))) && name.Length > 2 && IsLetters(name));
        }
        public bool IsLetters(string name) 
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (!(name[i]<'A' && name[i]>'z'))
                    return false;
            }
            return true;
        }
        public bool IsValidEmail()
        {
            return IsValidEmailH(Email);
        }
        static bool IsValidEmailH(string email)
        {
            // Define a regular expression for validating an Email
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            // Create a Regex object
            Regex regex = new Regex(pattern);

            // Use the IsMatch method to determine if the string matches the regular expression
            return regex.IsMatch(email);
        }
        #endregion

    }
    
}
