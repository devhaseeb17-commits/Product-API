using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

public ProductsController(ProductService productService)
{
    _productService = productService;
}
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetProductsAsync();
        var productDtos = products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Category = product.Category
        }).ToList();
        return Ok(productDtos);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Category = product.Category
        };
        return Ok(productDto);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto product)
    {
       var newProduct = await _productService.CreateProductAsync(product);

return CreatedAtAction(
    nameof(GetProduct),
    new { id = newProduct.Id },
    newProduct);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto product)
    {
        var updated = await _productService.UpdateProductAsync(id, product);

if (!updated)
    return NotFound();

return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
       var deleted = await _productService.DeleteProductAsync(id);

if (!deleted)
    return NotFound();

return NoContent();
    }
}