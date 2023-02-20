using Ef7BulkOperations.Entities;
using Ef7BulkOperations.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ef7BulkOperations.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPatch]
    [Route("classic-update/{categoryId:guid}")]
    public async Task<IActionResult> EfClassicUpdateAsync(Guid categoryId)
    {
        await _productService.EfClassicUpdateAsync(categoryId);
        return Ok();
    }


    [HttpPatch]
    [Route("bulk-update/{categoryId:guid}")]
    public async Task<IActionResult> Ef7BulkUpdateAsync(Guid categoryId)
    {
        await _productService.Ef7BulkUpdateAsync(categoryId);
        return Ok();
    }

    [HttpDelete]
    [Route("delete/{categoryId:guid}")]
    public async Task<IActionResult> Ef7BulkDeleteAsync(Guid categoryId)
    {
        await _productService.Ef7BulkDeleteAsync(categoryId);
        return NoContent();
    }
}
