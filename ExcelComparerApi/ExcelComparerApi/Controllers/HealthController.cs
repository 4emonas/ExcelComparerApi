using Microsoft.AspNetCore.Mvc;

namespace ExcelComparerApi.Controllers
{
    public class HealthController : Controller
    {
        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok("status is fine.");
        }
    }
}
