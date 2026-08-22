using Restaurant.Management.AggregateRoot.Aggrigates.Interfaces;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Interfaces.Commands;


namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand>
    {
        private readonly IRestaurentAggrigator _restaurantAggrigator;
        private readonly IUnitOfWork _unitOfWork;
        public CreateRestaurantCommandHandler(IRestaurentAggrigator restaurantAggrigator, IUnitOfWork unitOfWork)
        {
            _restaurantAggrigator = restaurantAggrigator;
            _unitOfWork = unitOfWork;
        }
        public async Task HandleAsync(CreateRestaurantCommand command)
        {
            var restaurant = _restaurantAggrigator.CreateRestaurant(command);

            _unitOfWork.RestaurantRepository.Add(restaurant);

            if(await _unitOfWork.SaveChangesAsync())
            {
                // Handle success
            }
            else
            {
                // Handle failure
            }
        }
    }
}
