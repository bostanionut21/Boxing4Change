using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using System.Linq;
using Microsoft.AspNetCore.Components.Authorization;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace Mockup;
#if ANDROID
using Xamarin.Android.Net;
#endif
//namespace Mockup;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });
        SharedUser sharedUser = new();
        // Set the base address dynamically based on the platform

        builder.Services.AddAuthorizationCore();
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped<UserReq>();
        builder.Services.AddSingleton(sharedUser);
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://www.boxing4change.eu:8080/") });
       


#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
