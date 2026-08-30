using Restaurant.Management.Shared.Interfaces.Command;
using System.Text.Json.Serialization;

namespace Restaurant.Receipt.DTO.Command
{
    public class CreateReceiptCommand : ICommand
    {
        public int RestaurantCustomerId { get; set; }

        public int TargetRestaurantId { get; set; }

        public string? CustomerShippingAddress { get; set; }

        public List<CreateReceiptLineItemCommand> LineItems { get; set; } = new();
        public decimal TotalCost { get; set; }
    }

    public class CreateReceiptLineItemCommand
    {
        [JsonIgnore]
        public int RestaurantItemId { get; set; }
        public int RestaurantDishId { get; set; }
        public int OrderedQuantity { get; set; }
        public decimal DishUnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
