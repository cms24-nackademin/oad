using ProductProvider.Domain.Models;

namespace ProductProvider.Domain.Factories;

public class ResponseFactory<T> : ResponseFactory
{
    public static ResponseResult<T> Success(T data, int statusCode = 200, string? message = null!)
    {
        return new ResponseResult<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    public static ResponseResult<T> NotFound(T data, int statusCode = 200, string? message = null!)
    {
        return new ResponseResult<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }
}

public class ResponseFactory : BaseResponseFactory
{

}
