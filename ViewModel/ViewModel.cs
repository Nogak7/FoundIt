using System;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FoundIt.ViewModel
{
	public class ViewModel:INotifyPropertyChanged

	{ 
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChange([CallerMemberName] string propertyName = null )
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

        
	}
}

