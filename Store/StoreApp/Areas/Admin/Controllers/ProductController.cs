using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager) => _manager = manager;

        public IActionResult Index() => View(_manager.ProductService.GetAllProducts(false));

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion dto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);

                dto.ImageUrl = $"/images/{file.FileName}";
                _manager.ProductService.CreateProduct(dto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private SelectList GetCategoriesSelectList() => new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate dto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                    await file.CopyToAsync(stream);

                dto.ImageUrl = $"/images/{file.FileName}";
                _manager.ProductService.UpdateOneProduct(dto);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
