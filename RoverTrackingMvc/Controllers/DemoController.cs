using Microsoft.AspNetCore.Mvc;

namespace RoverTrackingMvc.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
