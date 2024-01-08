using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundIt.Models
{
    public class GroupMember
    {
        public User User { get; set; }
        public Communities Communitie { get; set; }
    }
}
