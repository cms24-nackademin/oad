namespace WebApi.Interfaces;

public interface IBaseResponseResult
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}

public interface IResponseResult : IBaseResponseResult
{
}

public interface IResponseResult<T> : IResponseResult
{
    public T? Data { get; set; }
}