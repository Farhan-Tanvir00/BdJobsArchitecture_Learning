using Restaurant.Management.Shared.Interfaces.Command;
using System.Text.Json.Serialization;

namespace Restaurant.Orchestrator.DTO.Command
{
    public class CreateOrderCommand : ICommand
    {
        public int RestaurantCustomerId { get; set; }

        public int TargetRestaurantId { get; set; }

        public string? CustomerShippingAddress { get; set; }

        public List<CreateOrderLineItemCommand> LineItems { get; set; } = new();
    }

    public class CreateOrderLineItemCommand
    {
        [JsonIgnore]
        public int RestaurantItemId { get; set; }
        public int RestaurantDishId { get; set; }
        public int OrderedQuantity { get; set; }
        public decimal DishUnitPrice { get; set; }
    }
}
