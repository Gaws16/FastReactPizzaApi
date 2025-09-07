using System.ComponentModel.DataAnnotations.Schema;

namespace FastReactPizzaApi.Models;

public class Order
{
    //TODO: Add validation
    public string Id { get; set; } = string.Empty;
    public string Customer { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    

    public decimal OrderPrice { get; set; }
    public bool Priority { get; set; }
    public decimal PriorityPrice { get; set; }
    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime EstimatedDelivery { get; set; }

    
    
}



