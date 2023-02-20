namespace Ef7BulkOperations.Interfaces;

public interface IProductService
{
    Task EfClassicUpdateAsync(Guid categoryId);

    Task Ef7BulkUpdateAsync(Guid categoryId);

    Task Ef7BulkDeleteAsync(Guid categoryId);
}
