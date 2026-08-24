using Restaurant.Management.Shared.Interfaces.Command;

namespace Restaurant.Management.DTO.Commands
{
    public class DeleteRestaurantCommand: ICommand
    {
        public int RestaurantId { get; set; }
    }
}
