using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("")]
        public IActionResult Index(ProductRequestParameters productRequestParameters)
        {
            var model = _manager.ProductService.GetAllProductsWithDetails(productRequestParameters);
            return View(model);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}