using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Data.Contexts;
using WebApi.Factories;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Services;

public class ProductService(DataContext context) : IProductService
{
    private readonly DataContext _context = context;

    public async Task<IResponseResult> CreateAsync(ProductRegistrationForm form)
    {
        if (form == null || string.IsNullOrEmpty(form.Title) || string.IsNullOrEmpty(form.Price))
            return ResponseResultFactory.Failure(statusCode: 400, message: "Invalid product form data.");

        try
        {
            var entity = ProductFactory.Create(form);

            if (await _context.Products.AnyAsync(x => x.Title == entity.Title))
                return ResponseResultFactory.Exists(message: "An product with the same title already exists.");

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            var product = ProductFactory.Create(entity);
            return ResponseResultFactory.Success(data: product);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResultFactory.Failure(statusCode: 500, message: "An error occurred while creating the product.");
        }
    }


    public async Task<IResponseResult> GetAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Products.FirstOrDefaultAsync(expression);
            if (entity == null)
                return ResponseResultFactory.NotFound();

            var product = ProductFactory.Create(entity);
            return ResponseResultFactory.Success(data: product);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResultFactory.Failure(statusCode: 500, message: "An error occurred while retrieving the product.");
        }
    }

    public async Task<IResponseResult> GetAllAsync()
    {
        try
        {
            var entities = await _context.Products.ToListAsync();
            if (entities == null)
                return ResponseResultFactory.NotFound();

            var products = new List<Product>();
            foreach(var entity in entities)
            {
                products.Add(ProductFactory.Create(entity));
            }
            
            return ResponseResultFactory.Success<IEnumerable<Product>>(data: products);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResultFactory.Failure(statusCode: 500, message: "An error occurred while retrieving the product.");
        }
    }

    public async Task<IResponseResult> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        try
        {
            var entities = await _context.Products.Where(expression).ToListAsync();
            if (entities == null)
                return ResponseResultFactory.NotFound();

            var products = new List<Product>();
            foreach (var entity in entities)
            {
                products.Add(ProductFactory.Create(entity));
            }

            return ResponseResultFactory.Success<IEnumerable<Product>>(data: products);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResultFactory.Failure(statusCode: 500, message: "An error occurred while retrieving the product.");
        }
    }
}
