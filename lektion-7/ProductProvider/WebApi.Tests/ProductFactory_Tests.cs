using WebApi.Factories;
using WebApi.Models;

namespace WebApi.Tests;

public class ProductFactory_Tests
{
    private ProductRegistrationForm _formWithData = new ProductRegistrationForm
    {
        Title = "Test Product",
        Price = "200"
    };
    private ProductEntity _entityWithData = new ProductEntity
    {
        Id = 1,
        Title = "Test Product",
        Price = 200
    };

    [Fact]
    public void Create_ShouldReturnProductEntity_FromProductRegistrationForm()
    {
        // Act
        var result = ProductFactory.Create(_formWithData);

        // Assert
        Assert.IsType<ProductEntity>(result);
    }

    [Fact]
    public void Create_ShouldReturnProduct_FromProductEntity()
    {
        // Act
        var result = ProductFactory.Create(_entityWithData);

        // Assert
        Assert.IsType<Product>(result);
    }
}
