using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BenchmarkPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44378");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Laravel()
        {
            return View("laravel");
        }

        public IActionResult Nodejs()
        {
            return View("nodejs");
        }

        public IActionResult Asp()
        {
            return View("asp");
        }

        public IActionResult DatabaseIO()
        {
            HttpResponseMessage response = _httpClient.GetAsync("/api/Product/DatabaseIO").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                TimeSpan time = JsonSerializer.Deserialize<TimeSpan>(responseContent);
                return View("Index", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult DiscIO()
        {
            HttpResponseMessage response = _httpClient.GetAsync("/api/Product/DiscIO").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                TimeSpan time = JsonSerializer.Deserialize<TimeSpan>(responseContent);
                return View("Index", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult GarbageCollection()
        {
            HttpResponseMessage response = _httpClient.GetAsync("/api/Product/GarbageCollection").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                TimeSpan time = JsonSerializer.Deserialize<TimeSpan>(responseContent);
                return View("Index", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ThreadPerformance()
        {
            HttpResponseMessage response = _httpClient.GetAsync("/api/Product/ThreadPerformance").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                TimeSpan time = JsonSerializer.Deserialize<TimeSpan>(responseContent);
                return View("Index", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult DatabaseIOLaravel()
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://127.0.0.1:8000/api/dbIO").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                float time = JsonSerializer.Deserialize<float>(responseContent);
                return View("php", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult DiscIOLaravel()
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://127.0.0.1:8000/api/discIO").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                float time = JsonSerializer.Deserialize<float>(responseContent);
                return View("php", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult GarbageCollectionLaravel()
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://127.0.0.1:8000/api/gc").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                float time = JsonSerializer.Deserialize<float>(responseContent);
                return View("php", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ThreadPerformanceLaravel()
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://127.0.0.1:8000/api/tp").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                float time = JsonSerializer.Deserialize<float>(responseContent);
                return View("php", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult DatabaseIONodejs()
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:3000/dbIO").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                float time = JsonSerializer.Deserialize<float>(responseContent);
                return View("nodejs", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult DiscIONodejs()
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:3000/discIO").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                float time = JsonSerializer.Deserialize<float>(responseContent);
                return View("nodejs", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult GarbageCollectionNodejs()
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:3000/gc").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                float time = JsonSerializer.Deserialize<float>(responseContent);
                return View("nodejs", time);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ThreadPerformanceNodejs()
        {
            HttpResponseMessage response = _httpClient.GetAsync("http://localhost:3000/tp").Result;
            if (response.IsSuccessStatusCode)
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                float time = JsonSerializer.Deserialize<float>(responseContent);
                return View("nodejs", time);
            }
            else
            {
                return View("Error");
            }
        }


    }
}
