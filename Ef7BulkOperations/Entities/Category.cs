using System.ComponentModel.DataAnnotations.Schema;

namespace Ef7BulkOperations.Entities;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;
    public List<Product> Products { get; set; } = new();
}
