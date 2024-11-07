using ProductProvider.Data.Interfaces;

namespace ProductProvider.Data.Services;


public class ProductRepository<T> : BaseRepository<T>, IProductRepository<T>
{

}
