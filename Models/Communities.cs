using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundIt.Models
{
    public class Communities
    {
        public string GroupName { get; set; }
        public User Manager {  get; set; }
        public List<User> GroupMembers { get; set; }
        public string Location { get; set; }

        
    }
}
