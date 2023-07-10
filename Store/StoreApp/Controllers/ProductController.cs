using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var model = _repositoryManager.Product.GetAllProducts(false);
            return View(model);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = _repositoryManager.Product.GetOneProduct(id, false);
            return View(model);
        }
    }
}