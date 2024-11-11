using WebApi.Factories;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Tests;

public class ResponseResultFactory_Tests
{
    private ProductEntity _entityWithData = new ProductEntity
    {
        Id = 1,
        Title = "Test Product",
        Price = 200
    };


    [Fact]
    public void Success_ShouldReturnSuccessTrueAndStatusCode200()
    {
        // Act
        var result = ResponseResultFactory.Success();

        // Assert
        Assert.IsAssignableFrom<IResponseResult>(result);
        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void SuccessWithStatusCode201_ShouldReturnSuccessTrueAndStatusCode201()
    {
        // Act
        var result = ResponseResultFactory.Success(statusCode: 201);

        // Assert
        Assert.IsAssignableFrom<IResponseResult>(result);
        Assert.True(result.Success);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void SuccessWithProductEntity_ShouldReturnSuccessTrueAndStatusCode200AndData()
    {
        // Act
        var result = ResponseResultFactory.Success(data: _entityWithData);

        // Assert
        Assert.IsAssignableFrom<IResponseResult<ProductEntity>>(result);
        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(_entityWithData, ((IResponseResult<ProductEntity>)result).Data);
    }

    [Fact]
    public void Failure_ShouldReturnSuccessFalseAndStatusCode400()
    {
        // Act
        var result = ResponseResultFactory.Failure();

        // Assert
        Assert.IsAssignableFrom<IResponseResult>(result);
        Assert.False(result.Success);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void Exists_ShouldReturnSuccessFalseAndStatusCode409()
    {
        // Act
        var result = ResponseResultFactory.Exists();

        // Assert
        Assert.IsAssignableFrom<IResponseResult>(result);
        Assert.False(result.Success);
        Assert.Equal(409, result.StatusCode);
    }

    [Fact]
    public void NotFound_ShouldReturnSuccessFalseAndStatusCode404()
    {
        // Act
        var result = ResponseResultFactory.NotFound();

        // Assert
        Assert.IsAssignableFrom<IResponseResult>(result);
        Assert.False(result.Success);
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public void SuccessWithNullData_ShouldReturnSuccessTrueAndStatusCode200()
    {
        // Act
        var result = ResponseResultFactory.Success<ProductEntity>(data: null!);

        // Assert
        Assert.IsAssignableFrom<IResponseResult<ProductEntity>>(result);
        Assert.True(result.Success);
        Assert.Equal(200, result.StatusCode);
        Assert.Null(((IResponseResult<ProductEntity>)result).Data);
    }

    [Fact]
    public void ExistsWithProductEntity_ShouldReturnSuccessFalseAndStatusCode409AndData()
    {
        // Act
        var result = ResponseResultFactory.Exists(data: _entityWithData);

        // Assert
        Assert.IsAssignableFrom<IResponseResult<ProductEntity>>(result);
        Assert.False(result.Success);
        Assert.Equal(409, result.StatusCode);
        Assert.Equal(_entityWithData, ((IResponseResult<ProductEntity>)result).Data);
    }

    [Fact]
    public void NotFoundWithProductEntity_ShouldReturnSuccessFalseAndStatusCode404AndData()
    {
        // Act
        var result = ResponseResultFactory.NotFound(data: _entityWithData);

        // Assert
        Assert.IsAssignableFrom<IResponseResult<ProductEntity>>(result);
        Assert.False(result.Success);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal(_entityWithData, ((IResponseResult<ProductEntity>)result).Data);
    }
}
