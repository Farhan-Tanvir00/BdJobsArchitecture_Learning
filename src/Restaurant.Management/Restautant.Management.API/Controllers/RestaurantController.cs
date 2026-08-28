using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.DTO.Constants;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;


namespace Restautant.Management.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController: ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public RestaurantController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<ApiResponse<List<RestaurantDTO>>>> GetAllRestaurants()
        {
            var query = new GetAllRestaurantQuery();
            var result = await _serviceProvider.GetRequiredService<IQueryHandler<GetAllRestaurantQuery, ApiResponse<List<RestaurantDTO>>>>().HandleAsync(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApiResponse<RestaurantDTO>>> GetRestaurantById([FromRoute] int id)
        {
            var query = new GetOneRestaurantQuery { RestaurantId = id };
            var result = await _serviceProvider.GetRequiredService<IQueryHandler<GetOneRestaurantQuery, ApiResponse<RestaurantDTO>>>().HandleAsync(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<object?>>> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<CreateRestaurantCommand>>().HandleAsync(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<object?>>> DeleteRestaurant([FromRoute] int id)
        {
            var command = new DeleteRestaurantCommand { RestaurantId = id };
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<DeleteRestaurantCommand>>().HandleAsync(command);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ApiResponse<object?>>> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand command)
        {
            command.RestaurantId = id;
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<UpdateRestaurantCommand>>().HandleAsync(command);
            return Ok(result);
        }

        [HttpPatch]
        [Route("ActiveDelivery/{id}")]
        public async Task<ActionResult<ApiResponse<object?>>> ActiveDelivery([FromRoute] int id)
        {
            var command = new ActiveDeliveryRestaurantCommand { RestaurantId = id };
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<ActiveDeliveryRestaurantCommand>>().HandleAsync(command);
            return Ok(result);
        }

        //[HttpPost("Search")]
        //public async Task<ActionResult<ApiResponse>> SearchRestaurants([FromQuery] string? name,
        //    [FromQuery] string? category, [FromQuery] bool? hasDelivery)
        //{
        //    var restaurants = await _restaurantDetailsService.SearchRestaurants(name, category, hasDelivery);
        //    return Ok(restaurants);
        //}

    }
}
