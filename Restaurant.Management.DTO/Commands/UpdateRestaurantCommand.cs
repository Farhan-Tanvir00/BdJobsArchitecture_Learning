using Restaurant.Management.Shared.Interfaces.Command;
using System.Text.Json.Serialization;

namespace Restaurant.Management.DTO.Commands
{
    public class UpdateRestaurantCommand: ICommand
    {
        [JsonIgnore]
        public int RestaurantId { get; set; }

        public required string RestaurantName { get; set; }
        public required string RestaurantDescription { get; set; }
        public required string RestaurantCategory { get; set; }

        public string? RestaurantContactEmail { get; set; }
        public string? RestaurantContactNumber { get; set; }

        public string? RestaurantCity { get; set; }
        public string? RestaurantStreet { get; set; }
        public string? RestaurantPostalCode { get; set; }
    }
}
