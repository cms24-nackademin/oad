using System.Linq.Expressions;
using WebApi.Models;

namespace WebApi.Interfaces
{
    public interface IProductService
    {
        Task<IResponseResult> CreateAsync(ProductRegistrationForm form);
        Task<IResponseResult> GetAllAsync();
        Task<IResponseResult> GetAllAsync(Expression<Func<ProductEntity, bool>> expression);
        Task<IResponseResult> GetAsync(Expression<Func<ProductEntity, bool>> expression);
    }
}