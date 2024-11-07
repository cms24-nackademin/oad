namespace ProductProvider.Domain.Models;

public class Product
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Description { get; set; }

}