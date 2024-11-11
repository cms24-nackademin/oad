using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class ProductRegistrationForm
{
    public string? ArticleNumber { get; set; }

    [Required]
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Required]
    public string Price { get; set; } = null!;

}
