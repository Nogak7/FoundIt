using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundIt.Models
{
    public class PostComment
    {
        public Post Post { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public List<PostComment> Comments { get; set; }
    }
}
