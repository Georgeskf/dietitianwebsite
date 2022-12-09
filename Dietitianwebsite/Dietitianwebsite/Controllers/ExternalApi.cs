using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Specialized;

namespace Dietitianwebsite.Controllers
{
    public class ExternalApi : Controller
    {
        // GET: ExternalApi
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExternalApi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExternalApi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExternalApi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExternalApi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExternalApi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExternalApi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExternalApi/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /*public static IRestResponse CreateNewUser(string enviroment, string email, string password)
        {
            NameValueCollection Env = ValidateEnv(enviroment);
            string baseurlenv = "https://api.api-ninjas.com/v1/nutrition?query=";
            var enviroments = new EndPointProviders();
            var Client = new RestClient();
            Client.BaseUrl = new Uri(baseurlenv);
            var request = new RestRequest(Method.POST);

            // Resource should just be the path
            

            // This is how to add parameters
          

            // This looks correct assuming you are putting your actual x-api-key here
            request.AddHeader("x-api-key", "8vs0kXFgFDdely8j92C3kA==V38CyqExQtiELhYe");

            // There is a chance you need to configure the aws api gateway to accept this content type header on that resource. Depends on how locked down you have it
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            IRestResponse response = Client.Execute(request);
            Console.WriteLine(request);
            if (!IsReturnedStatusCodeOK(response))
            {
                throw new HttpRequestException("Request issue -> HTTP code:" + response.StatusCode);
            }
            return response;

        }
        //Rest of the stuff*/
        
    }
}
