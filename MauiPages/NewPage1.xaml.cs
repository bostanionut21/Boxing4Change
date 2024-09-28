using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebView.Maui;
using System.Xml.Linq;
namespace Mockup;

public partial class NewPage1 : ContentPage
{
    //private readonly HttpClient _httpClient=new();
    //private readonly SharedUser _sharedUser=new();
    //private readonly Video _video;
    private string name;
    private string welcome;
    private string strategiesObjectives;
    private string interviews;
    private string tutorials;
    private string partners;
    public string Name
    {
        get => name;
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(nameof(Name)); // Notify UI of the change
            }
        }
    }
    public string Welcome
    {
        get => welcome;
        set
        {
            if (welcome != value)
            {
                welcome = value;
                OnPropertyChanged(nameof(Welcome)); // Notify UI of the change
            }
        }
    }
    public string StrategiesObjectives
    {
        get => strategiesObjectives;
        set
        {
            if (strategiesObjectives != value)
            {
                strategiesObjectives = value;
                OnPropertyChanged(nameof(strategiesObjectives)); // Notify UI of the change
            }
        }
    }
    public string Interviews
    {
        get => interviews;
        set
        {
            if (interviews != value)
            {
                interviews = value;
                OnPropertyChanged(nameof(interviews)); // Notify UI of the change
            }
        }
    }
    public string Tutorials
    {
        get => tutorials;
        set
        {
            if (tutorials != value)
            {
                tutorials = value;
                OnPropertyChanged(nameof(tutorials)); // Notify UI of the change
            }
        }
    }
    public string Partners
    {
        get => partners;
        set
        {
            if (partners != value)
            {
                partners = value;
                OnPropertyChanged(nameof(partners)); // Notify UI of the change
            }
        }
    }
    public NewPage1(/*SharedUser sharedUser*/NavigatorService navigatorService, SharedUser sharedUser)
    {
        InitializeComponent();
        NavigatorService = navigatorService;
        name = sharedUser.Surname + "!";
        if(sharedUser.Country== "Romania")
        {
            welcome = "Bine ai venit,";
            strategiesObjectives = "Strategii&Obiective";
            interviews = "Interviuri";
            tutorials = "Tutoriale";
            partners = "Parteneri";
        }
        else if (sharedUser.Country=="Italy")
        {
            welcome = "Benvenuti,";
            strategiesObjectives = "Strategie&Obiettivi";
            interviews = "Interviste";
            tutorials = "Tutorial";
            partners = "Partner";
        }
        else if (sharedUser.Country == "Spain")
        {
            welcome = "Bienvenido,";
            strategiesObjectives = "Estrategias&Objetivos";
            interviews = "Entrevistas";
            tutorials = "Tutoriales";
            partners = "Socios";
        }
        //_sharedUser = sharedUser;
        //_httpClient = new HttpClient { BaseAddress = new Uri("http://10.0.2.2:5000") };
        //_video = new(_httpClient);
        //LoadVideosAsync();
        BindingContext = this;
    }
    public NavigatorService NavigatorService { get; }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        NavigatorService.NavigationManager.NavigateTo("/federations");
        await Task.Delay(400);
        Navigation.PopModalAsync();

    }
    /* protected override async void OnAppearing()
     {
         await Task.Delay(2000);
         base.OnAppearing();

     }
     private async Task<List<VideoDTO>> LoadVideosAsync()
     {
         try
         {
             var country = _sharedUser.Country; // Assuming this is how you determine the language
             var videos = await _video.GetVideosAsync(country);
             return videos;

         }
         catch (HttpRequestException e)
         {
             // Handle exceptions
             Console.WriteLine($"Request error: {e.Message}");
             return null;
         }
     }*/
}