using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters requestParameters)
        {
            var requestParametersProducts = _manager.ProductService.GetAllProductsWithDetails(requestParameters);
            var totalCount = _manager.ProductService.GetAllProducts(trackChanges: false).Count();
            var requestParametersagination = new Pagination
            {
                CurrenPage = requestParameters.PageNumber,
                ItemsPerPage = requestParameters.PageSize,
                TotalItems = totalCount
            };
            var viewModel = new ProductListViewModel
            {
                Products = requestParametersProducts,
                Pagination = requestParametersagination
            };
            return View(viewModel);
        }

        public IActionResult Get([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, trackChanges: false);
            return View(model);
        }
    }
}
