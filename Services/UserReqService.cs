using Mockup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

public class UserReq
{
    private readonly HttpClient _httpClient;

    // Constructor to inject HttpClient
    public UserReq(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Method to fetch user data
    public async Task<UserDto> GetUserAsync()
    {
        try
        {
            // Assuming "userId" is passed as a parameter to form a valid endpoint
            var user = await _httpClient.GetFromJsonAsync<UserDto>($"users/3");
            return user;
        }
        catch (HttpRequestException e)
        {
            // Log error or handle it accordingly
            Console.WriteLine($"Request error: {e.Message}");
            return null;
        }
    }
}
