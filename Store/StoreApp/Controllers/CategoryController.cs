using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private IServiceManager _manager;



        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetAllCategories(false);
            return View(model);
        }
    }
}