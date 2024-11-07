using ProductProvider.Domain.Factories;
using ProductProvider.Domain.Models;

namespace ProductProvider.Tests.Domain;

public class ResponseFactory_Tests
{

    [Fact]
    public void Success_ShouldReturnTrue()
    {
        // Act
        var result = ResponseFactory.Success();

        // Assert
        Assert.True(result.Success);

    }

    [Fact]
    public void Success_ShouldReturnTrueAndData()
    {
        // Arrange
        var product = new Product();

        // Act
        var result = ResponseFactory<Product>.Success(data: product);

        // Assert
        Assert.True(result.Success);
        Assert.IsType<Product>(result.Data);
    }


    [Fact]
    public void Failed_ShouldReturnFalseAndStatusCode400()
    {
        // Act
        var result = ResponseFactory.Failed();

        // Assert
        Assert.False(result.Success);
        Assert.Equal(400, result.StatusCode);

    }

    [Fact]
    public void NotFound_ShouldReturnFalseAndStatusCode404()
    {
        // Act
        var result = ResponseFactory.NotFound();

        // Assert
        Assert.False(result.Success);
        Assert.Equal(404, result.StatusCode);

    }

    [Fact]
    public void AlreadyExists_ShouldReturnFalseAndStatusCode409()
    {
        // Act
        var result = ResponseFactory.AlreadyExists();

        // Assert
        Assert.False(result.Success);
        Assert.Equal(409, result.StatusCode);

    }
}
