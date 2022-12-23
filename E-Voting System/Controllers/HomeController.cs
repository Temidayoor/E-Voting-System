using E_Voting_System.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System.Diagnostics;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web;

namespace E_Voting_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

     
        public IActionResult Index()
        {
            //string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //if (string.IsNullOrEmpty(ipAddress))
            //{
            //    ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            //}
            //Location location = new Location();
            //string url = string.Format("http://freegeoip.net/json/{0}", ipAddress);
            //using (WebClient client = new WebClient())
            //{
            //    string json = client.DownloadString(url);
            //    location = new JavaScriptSerializer().Deserialize<Location>(json);
            //}

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