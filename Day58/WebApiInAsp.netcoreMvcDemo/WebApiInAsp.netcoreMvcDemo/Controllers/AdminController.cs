using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiInAsp.netcoreMvcDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public AdminController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var employees = await _employeeService.GetAllEmployeeBasicInfoAsync(1, int.MaxValue, null);
            var names = employees
                .Select(e => $"{e.FirstName} {e.LastName}".Trim())
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .ToList();

            return Ok(names);
        }
    }
}
