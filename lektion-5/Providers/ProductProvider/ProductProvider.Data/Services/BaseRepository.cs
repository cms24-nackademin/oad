using ProductProvider.Data.Interfaces;
using ProductProvider.Domain.Factories;
using ProductProvider.Domain.Models;

namespace ProductProvider.Data.Services;

public abstract class BaseRepository<T> : IBaseRepository<T>
{
    private readonly List<T> _items = [];


    public virtual ResponseResult<T> Create(T entity)
    {
        _items.Add(entity);
        return ResponseFactory<T>.Success(entity);
    }

    public virtual ResponseResult<IEnumerable<T>> GetAll()
    {
        return ResponseFactory<IEnumerable<T>>.Success(_items);
    }

    public virtual ResponseResult<T> GetOne(Func<T, bool> predicate)
    {
        var entity = _items.FirstOrDefault(predicate);

        if (entity != null)
        {
            return ResponseFactory<T>.Success(entity);
        }

        return ResponseFactory<T>.NotFound(entity!);

    }
}
