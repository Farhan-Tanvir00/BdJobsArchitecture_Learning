using Restaurant.Management.Shared.Interfaces.Command;


namespace Restaurant.Management.DTO.Commands
{
    public class CreateRestaurantCommand: ICommand
    {
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
