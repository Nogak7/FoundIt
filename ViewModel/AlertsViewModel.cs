using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundIt.ViewModel
{
    public class AlertsViewModel:ViewModel
    {
        private string message;
        public bool AlertShowMessage { get; set; }
        public string AlertMessage { get => message; set { if (message != value) { message = value; OnPropertyChange(); } } }

     
    }
}
