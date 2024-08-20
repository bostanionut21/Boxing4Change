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
public class UserReq
{
    private readonly HttpClient _httpClient;

    // Constructor to inject HttpClient
    public UserReq(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Method to fetch user data
    public async Task<UserDto> GetUserAsync(string email, string password)
    {
        try
        {
            // Assuming "userId" is passed as a parameter to form a valid endpoint
            var user = await _httpClient.GetFromJsonAsync<UserDto>($"users/{email}/{password}");
            return user!;
        }
        catch (HttpRequestException e)
        {
            // Log error or handle it accordingly
            Console.WriteLine($"Request error: {e.Message}");
            return null!;
        }
    }

    public async Task<bool> GetEmailAsync(string email, string code)
    {
        try
        {
            // Assuming "userId" is passed as a parameter to form a valid endpoint
            var response = await _httpClient.GetAsync($"email/{email}/{code}");
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException e)
        {
            // Log error or handle it accordingly
            Console.WriteLine($"Request error: {e.Message}");
            return false;
        }
    }

    public async Task PostUserAsync(UserDto user)
    {
        try
        {

            // Define the endpoint URL
            var url = "http://www.boxing4change.eu:8080/user";
            // Send the POST request
            var response = await _httpClient.PostAsJsonAsync(url, user);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read and output the response content (if needed)
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response content: {responseContent}");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            Console.WriteLine($"Stack Trace: {e.StackTrace}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }

    public async Task PutPasswordAsync(LoginModel user)
    {
        try
        {

            // Define the endpoint URL
            var url = "http://www.boxing4change.eu:8080/update_password";
            // Send the POST request
            var response = await _httpClient.PutAsJsonAsync(url, user);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read and output the response content (if needed)
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response content: {responseContent}");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            Console.WriteLine($"Stack Trace: {e.StackTrace}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General error: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
    }
}
