using Ef7BulkOperations.Entities;
using Ef7BulkOperations.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ef7BulkOperations.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task EfClassicUpdateAsync(Guid categoryId)
    {
        var products = await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();

        foreach (var product in products)
        {
            product.IsOutOfStock = true;
            product.LastUpdatedDateTime = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }

    public async Task Ef7BulkUpdateAsync(Guid categoryId)
    {
        await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .ExecuteUpdateAsync(update => update
                .SetProperty(p => p.IsOutOfStock, true)
                .SetProperty(p => p.LastUpdatedDateTime, DateTime.UtcNow));
    }

    public async Task Ef7BulkDeleteAsync(Guid categoryId)
    {
        await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .ExecuteDeleteAsync();
    }
}
