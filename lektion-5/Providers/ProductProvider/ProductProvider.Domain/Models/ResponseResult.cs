namespace ProductProvider.Domain.Models;


public class ResponseResult<T> : ResponseResult
{
    public T? Data { get; set; }
}


public class ResponseResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}