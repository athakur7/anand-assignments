using Microsoft.AspNetCore.Mvc;
using MVC_Demo_Project.Models;
using System.Diagnostics;

namespace MVC_Demo_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public string sampleDemo1()
        {
           return "This is a sample demo method";

        }
        public string sampleDemo2()
        {
            return "This is a sample demo method 2";
        }
        public IActionResult sampleDemo3()
        {
            int age = 27;
            string name = "Anand";
            ViewBag.Age = age;
            ViewBag.Name = name;
            ViewData["Message"] = "This is a sample demo method 3";
            ViewData["Year"] = DateTime.Now.Year;
            return View();

        }
        public IActionResult Index()
        {
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
