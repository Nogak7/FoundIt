using FoundIt.Models;

namespace FoundIt;

public partial class App : Application
{
	public User User { get; set; }=new User() { Email="talsi", FirstName="t", Pasword="t", Id=1, UserName="talsi" };
	public List<PostStatus> PostStatuses { get; set; } = new List<PostStatus>() {
	new PostStatus() { Id = 1, PostStatusName = "Waiting For approval" },

	new PostStatus() { Id = 2, PostStatusName = "Not Found Yet" },


			new PostStatus() { Id = 3, PostStatusName = "Verification" },


			new PostStatus() { Id = 4, PostStatusName = "Found" }};
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}

}

