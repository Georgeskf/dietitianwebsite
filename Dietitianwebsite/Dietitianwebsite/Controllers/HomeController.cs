using Dietitianwebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Dietitianwebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseUrl = "https://api.api-ninjas.com/";
        string APIKEY = "X-Api-Key";
        string APIKEYvalue = "8vs0kXFgFDdely8j92C3kA==V38CyqExQtiELhYe";
        //public string question = "fries";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string question)
        {
            DataTable dt =new DataTable();
            using (var client=new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("X-Api-Key", APIKEYvalue);
                HttpResponseMessage getData = await client.GetAsync("v1/nutrition?query="+question);
                if (getData.IsSuccessStatusCode)
                    {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    dt = JsonConvert.DeserializeObject<DataTable>(results);

                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }
                ViewData.Model = dt;
            }

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}