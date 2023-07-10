using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}