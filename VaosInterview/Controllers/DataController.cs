using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using VaosInterview.Models;

namespace VaosInterview.Controllers
{

    public class DataController : Controller
    {
        private readonly HttpClient _httpClient;

        public DataController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetData()
        {
            // Replace with the actual public API endpoint URL
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.abibliadigital.com.br/api/books");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<Response>>();
                return Ok(data);
            }
            else
            {
                return BadRequest("Failed to get data from public API.");
            }
        }
    }
}

