using System.ComponentModel.DataAnnotations;
public class UpdateProductDto
{
    [Required]
    public required string Name{get; set;}
    public decimal Price { get; set; }
    public int Stock { get; set; }
    [Required]
    public required string Category { get; set; }
}