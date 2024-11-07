using ProductProvider.Domain.Models;

namespace ProductProvider.Data.Interfaces
{
    public interface IBaseRepository<T>
    {
        ResponseResult<T> Create(T entity);
        ResponseResult<IEnumerable<T>> GetAll();
        ResponseResult<T> GetOne(Func<T, bool> predicate);
    }
}