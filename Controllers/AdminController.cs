using Microsoft.AspNetCore.Mvc;

namespace ParcelTrackingSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
