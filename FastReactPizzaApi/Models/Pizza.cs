using System.ComponentModel.DataAnnotations;
using static FastReactPizzaApi.Common.DataValidationConstants.Pizza;

namespace FastReactPizzaApi.Models;

public class Pizza
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(MaxNameLength)]
    public string Name { get; set; } = null!;
    [Required]
    [Range(MinUnitPrice, MaxUnitPrice,ErrorMessage = "Price must be between 0 and 100")]
    public int UnitPrice { get; set; }
    
    public IEnumerable<string> Ingredients { get; set; } = null!;
    public bool SoldOut { get; set; }
    [Required]
    public string ImageUrl { get; set; } = null!;
    
    
}


// {
// "id": 1,
// "name": "Margherita",
// "unitPrice": 8,
// "ingredients": ["tomato", "mozzarella", "basil"],
// "soldOut": false,
// "imageUrl": "https://picsum.photos/400/300?random=1"
// },