using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace blazspire;

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
			});

		var config = new ConfigurationBuilder()
		.SetBasePath(Directory.GetCurrentDirectory() ?? FileSystem.AppDataDirectory)
		.AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
		.Build();

		var apiSettings = new ApiSettings();
		config.GetSection("api").Bind(apiSettings);

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddSingleton<AppState>();
		builder.Services.AddSingleton(new FetchService(apiSettings));
		builder.Services.AddScoped<ImagesService>();
		// builder.Services.AddScoped<ILogger, Logger>();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
		Console.OutputEncoding = Encoding.UTF8;
#endif

		builder.Services.AddLogging(logging =>
	 {
		 logging.AddDebug();
	 });


		return builder.Build();
	}
}
