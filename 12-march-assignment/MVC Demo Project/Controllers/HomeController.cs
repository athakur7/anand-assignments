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
        Employee obj = new Employee()
        {
            EmployeeId = 101,
            EmpName = "Anand",
            Salary = 45000
        };
        List<Employee> employeesList = new List<Employee>()
        {
            new Employee(){
                EmployeeId = 101, EmpName = "Anand", Salary = 45000,
                ImageUrl = "https://ui-avatars.com/api/?name=Anand&background=4a90d9&color=fff&size=200&rounded=true&bold=true",
                Description = "Anand is a Senior Software Engineer with 5+ years of experience in .NET and cloud technologies. He leads the backend development team."
            },
            new Employee(){
                EmployeeId = 102, EmpName = "Sita", Salary = 55000,
                ImageUrl = "https://ui-avatars.com/api/?name=Sita&background=e07b54&color=fff&size=200&rounded=true&bold=true",
                Description = "Sita is a Full Stack Developer specializing in React and ASP.NET Core. She has delivered multiple client-facing web applications."
            },
            new Employee(){
                EmployeeId = 103, EmpName = "Gita", Salary = 65000,
                ImageUrl = "https://ui-avatars.com/api/?name=Gita&background=4caf7d&color=fff&size=200&rounded=true&bold=true",
                Description = "Gita is a Project Manager with expertise in Agile methodologies. She oversees project timelines and coordinates cross-functional teams."
            },
            new Employee(){
                EmployeeId = 104, EmpName = "Rita", Salary = 75000,
                ImageUrl = "https://ui-avatars.com/api/?name=Rita&background=9b59b6&color=fff&size=200&rounded=true&bold=true",
                Description = "Rita is a Data Analyst with strong skills in SQL and Power BI. She drives data-informed decisions across the organization."
            },
        };

        public IActionResult listObjectPassing()
        {
            return View(employeesList);
        }
        public IActionResult Details(int id)
        {
            var employee = employeesList.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null) return NotFound();
            return View(employee);
        }
        public IActionResult SearchEmp(int empId)
        {
            Employee emp = (from e in employeesList
                            where e.EmployeeId == empId
                            select e).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.Message = $"No employee found with ID {empId}.";
                return View(new Employee());
            }

            return View(emp);
        }
        public IActionResult display()
        {
            return View();
        }
        public IActionResult singleObjectPassing()
        {
            return View(obj);
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
