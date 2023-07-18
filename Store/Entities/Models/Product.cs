namespace Entities.Models;
public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; } = String.Empty;
    public decimal? Price { get; set; }
    public string? Summary { get; set; } = String.Empty;
    public string? ImageUrl { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }


}