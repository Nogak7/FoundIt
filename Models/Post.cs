using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundIt.Models
{
    public class Post
    {
        public string Theme { get; set; }
        public string Context {  get; set; }
        public bool FoundItem { get; set; }
        public string Picture {  get; set; }
        public User Creator { get; set; }
        public DateTime CreatingDate { get; set; }
        public string Location { get; set; }
       public PostStatus Status { get; set; }
    }
}
