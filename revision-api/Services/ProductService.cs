using Microsoft.EntityFrameworkCore;

public class ProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<Product?> GetProductByIdAsync(int id)
{
    return await _context.Products.FindAsync(id);
}
public async Task<Product> CreateProductAsync(CreateProductDto dto)
{
    var product = new Product
    {
        Name = dto.Name,
        Price = dto.Price,
        Stock = dto.Stock,
        Category = dto.Category
    };

    _context.Products.Add(product);
    await _context.SaveChangesAsync();

    return product;
}
public async Task<bool> UpdateProductAsync(int id, UpdateProductDto dto)
{
    var product = await _context.Products.FindAsync(id);

    if (product == null)
        return false;

    product.Name = dto.Name;
    product.Price = dto.Price;
    product.Stock = dto.Stock;
    product.Category = dto.Category;

    await _context.SaveChangesAsync();
    return true;
}
public async Task<bool> DeleteProductAsync(int id)
{
    var product = await _context.Products.FindAsync(id);

    if (product == null)
        return false;

    _context.Products.Remove(product);
    await _context.SaveChangesAsync();

    return true;
}
}