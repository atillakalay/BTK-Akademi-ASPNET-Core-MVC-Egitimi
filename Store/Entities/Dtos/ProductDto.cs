using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage = "ProductName is required.")]
        public string? ProductName { get; init; } = String.Empty;
        [Required(ErrorMessage = "Price is required.")]
        public decimal? Price { get; init; }
        [Required(ErrorMessage = "Summary is required.")]
        public string? Summary { get; init; } = String.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; init; }
    }
}
