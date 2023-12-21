using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundIt.ViewModel
{
    public class AlartsViewModel:ViewModel
    {
        private string message;
        public bool AlartShowMessage { get; set; }
        public string AlartMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }

        public void DispleyAlart(string message)
        {
            AlartMessage = message;
            AlartShowMessage = true;
        }
    }
}
