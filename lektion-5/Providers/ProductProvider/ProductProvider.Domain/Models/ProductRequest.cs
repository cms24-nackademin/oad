namespace ProductProvider.Domain.Models;

public class ProductRequest
{
    public string Title { get; set; } = null!;
    public decimal Price { get; set; } 
    public string? Description { get; set; }
}
