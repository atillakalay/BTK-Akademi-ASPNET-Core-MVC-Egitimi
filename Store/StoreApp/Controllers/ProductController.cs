using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly RepositoryContext _repositoryContext;

        public ProductController(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = _repositoryContext.Products.ToList();
            return View(model);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = _repositoryContext.Products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }
    }
}