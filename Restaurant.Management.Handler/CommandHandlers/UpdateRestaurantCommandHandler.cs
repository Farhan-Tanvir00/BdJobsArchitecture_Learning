using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Shared.Interfaces.Commands;


namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class UpdateRestaurantCommandHandler : ICommandHandler<UpdateRestaurantCommand>
    {
        public Task HandleAsync(UpdateRestaurantCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
