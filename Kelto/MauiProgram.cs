using Microsoft.Extensions.Logging;
using Supabase;
using Blazored.Modal;

namespace Kelto;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "MaPolice");
			})
			.Services.AddBlazoredModal();
		
		var url = Global.url;
      	var key = Global.key;
      	var options = new SupabaseOptions
      	{
      	  AutoRefreshToken = true,
      	  AutoConnectRealtime = true,
      	};

      	builder.Services.AddSingleton(provider => new Supabase.Client(url, key, options));
	
		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
