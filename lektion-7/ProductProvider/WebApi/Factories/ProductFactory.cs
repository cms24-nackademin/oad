using WebApi.Models;

namespace WebApi.Factories;

public static class ProductFactory
{
    public static ProductEntity Create(ProductRegistrationForm form)
    {
        var entity = new ProductEntity
        {
            ArticleNumber = form.ArticleNumber,
            Title = form.Title,
            Description = form.Description,
        };

        if (decimal.TryParse(form.Price, out decimal price)) {
            entity.Price = price;
        }

        return entity;        
    }

    public static Product Create(ProductEntity entity)
    {
        var product = new Product
        {
            Id = entity.Id,
            ArticleNumber = entity.ArticleNumber,
            Title = entity.Title,
            Description = entity.Description,
            Price = entity.Price
        };

        return product;
    }
}
