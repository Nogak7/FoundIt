using System;
using System.Security.Cryptography.X509Certificates;

namespace FoundIt.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }  

        public string FirstName { get; set; }  

        public string LastName { get; set; } 

        public string Pasword { get; set; } 

       
        public string UserName { get; set; } 
        public User()
        {
            
        }
    }
}

