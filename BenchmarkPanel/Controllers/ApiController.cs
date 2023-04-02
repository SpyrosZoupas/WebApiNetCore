using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

public class ApiController : Controller
{
    private readonly HttpClient _httpClient;

    public ApiController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IActionResult DatabaseIO()
    {
        // Send a GET request to the API endpoint and wait for the response
        HttpResponseMessage response = _httpClient.GetAsync("https://localhost:44378/api/Product/DatabaseIO").Result;

        // Check if the response was successful
        if (response.IsSuccessStatusCode)
        {
            // Read the response content as a string
            string responseContent = response.Content.ReadAsStringAsync().Result;

            // Return the response content as a JSON result
            return Json(responseContent);
        }
        else
        {
            // Return an error message if the response was not successful
            return BadRequest("Failed to get data from the API.");
        }
    }
}
