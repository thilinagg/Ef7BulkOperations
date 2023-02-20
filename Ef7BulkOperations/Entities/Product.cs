using System.ComponentModel.DataAnnotations.Schema;

namespace Ef7BulkOperations.Entities;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Title { get; set; } = default!;
    public bool IsOutOfStock { get; set; }
    public DateTime LastUpdatedDateTime { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = new();
}
