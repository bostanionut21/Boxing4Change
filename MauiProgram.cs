using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
#if ANDROID
using Xamarin.Android.Net;
#endif
namespace Mockup
{
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


            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<UserReq>();
            // Set the base address dynamically based on the platform
            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5292" : "http://localhost:5292";

            // Configure HttpClient with base address
            builder.Services.AddHttpClient<UserReq>(client =>
            {
                client.BaseAddress = new Uri(baseAddress); // Use the platform-specific base address
            });


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
