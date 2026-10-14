using System.ComponentModel.DataAnnotations;
public class CreateProductDto
{
    [Required]
    [StringLength(
    100,
    MinimumLength =3,
    ErrorMessage ="Product Name must be between 3 and 100 characters")]
    public string Name{get; set;}
    [Range(0.01, double.MaxValue,
    ErrorMessage ="Price must be above 1$")]
    public decimal Price { get; set; }
    [Range(0, int.MaxValue,ErrorMessage = "Stock cannot be negative.")]
    public int Stock { get; set; }
    [Required]
    public string Category { get; set; }

}