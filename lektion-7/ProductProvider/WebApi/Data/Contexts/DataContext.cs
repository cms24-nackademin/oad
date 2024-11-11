using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ProductEntity> Products { get; set; }
}
