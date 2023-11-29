﻿using System;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FoundIt.Models
{
	public static class Messages
	{



		public const string INVALID_NAME = "Invalid name, name can only contain letters without spaces please try again.";
		public const string INVALID_PASSWORD = "Invalid password, password can not be empty end must be  without spaces please try again.";
		public const string UNMATCHING_PASSWORDS = "The passwords are not matching please try again";
        public const string INVALID_EMAIL = "Invalid email, please use format of : \"example@email.example\".";
    }
}


