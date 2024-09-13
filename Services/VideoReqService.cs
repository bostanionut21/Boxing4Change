using Microsoft.Maui.ApplicationModel.Communication;
using Mockup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Mockup;
public class Video
{
    private readonly HttpClient _httpClient;

    // Constructor to inject HttpClient
    public Video(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Method to fetch user data
    public async Task<List<VideoDTO>> GetVideosAsync(string country)
    {
        try
        {
            // Fetch data from the endpoint
            var videos = await _httpClient.GetFromJsonAsync<List<VideoDTO>>($"/videos/country/{country}");
            return videos ?? new List<VideoDTO>(); // Return an empty list if null
        }
        catch (HttpRequestException e)
        {
            // Log error or handle it accordingly
            Console.WriteLine($"Request error: {e.Message}");
            return new List<VideoDTO>(); // Return an empty list in case of error
        }
    }


}
