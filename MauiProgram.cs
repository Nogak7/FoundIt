using FoundIt.Services;
using FoundIt.ViewModel;
using FoundIt.Views;
using Microsoft.Extensions.Logging;

namespace FoundIt;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<Login>();
        builder.Services.AddTransient<LoginPageViewModel>(); 
		builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomePageViewModel>();
        builder.Services.AddTransient<Register>();
        builder.Services.AddTransient<RegisterPageViewModel>();
		builder.Services.AddSingleton<FoundItService>();
        builder.Services.AddTransient<WelcomePageViewModel>();
   

        return builder.Build();
	}
}

