using FoundIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoundIt.ViewModel
{
    public class HomePageViewModel : ViewModel
    {
        public FoundItService service { get; protected set; }
        public HomePageViewModel(FoundItService service )
        {
            this.service = service;
        }
    }
}
