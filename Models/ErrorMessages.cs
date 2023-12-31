﻿using System;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FoundIt.Models;


public static class ErrorMessages
{



    public const string INVALID_NAME = "Invalid name, name can only contain letters without spaces please try again.";
    public const string INVALID_PASSWORD = "Invalid password, password can not be empty end must be  without spaces please try again.";
    public const string UNMATCHING_PASSWORDS = "The passwords are not matching please try again";
    public const string INVALID_EMAIL = "Invalid email, please use format of : \"example@email.example\".";
    public const string REGISTER_FAILED = "The email/username that you entered already exist in the system, please try again with a diffarent email/username";
    public const string LOGIN_FAILED = "This username does not exist in the system / the username does  not match the password, please try ";
}
 


