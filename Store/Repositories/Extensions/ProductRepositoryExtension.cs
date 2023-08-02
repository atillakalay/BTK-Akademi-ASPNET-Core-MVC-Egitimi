using Entities.Models;

namespace Repositories.Extensions
{
    public static class ProductRepositoryExtension
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products,
            int? categoryId)
        {
            return categoryId is null ? products : products.Where(prd => prd.CategoryId == categoryId);
        }

        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products,
            string? searchTerm)
        {
            return string.IsNullOrWhiteSpace(searchTerm)
                ? products
                : products.Where(prd => prd.ProductName.ToLower().Contains(searchTerm.ToLower()));
        }

        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,
            int minPrice, int maxPrice, bool isValidPrice)
        {
            return isValidPrice
                ? products.Where(prd => prd.Price >= minPrice && prd.Price <= maxPrice)
                : products;
        }

        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products, int pageNumber, int pageSize)
        {
            return products.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
