using DBFirstEFInASP.Data;          // make sure this matches your actual namespace
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DBFirstEFInASP.Controllers
{
    public class NorthWindController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SpainCustomers()
        {
            using var cnt = new NorthwindContext();

            var spainCustomers = cnt.Customers
                .Where(x => x.Country == "Spain")
                .ToList();

            return View(spainCustomers);
        }
    }
}
