using FoundIt.Models;

namespace FoundIt;

public partial class App : Application
{
	public User User { get; set; }
	public List<PostStatus> PostStatuses { get; set; }	
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}

}

