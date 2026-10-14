using System.ComponentModel.DataAnnotations;
public class ProductDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    [Required]
    public string Category { get; set; }
}