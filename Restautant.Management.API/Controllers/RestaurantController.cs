using Microsoft.AspNetCore.Mvc;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Commands;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;


namespace Restautant.Management.Controllers
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
        public async Task<ActionResult<ApiResponse<List<RestaurantDTO>>>> GetAllRestaurants()
        {
            var query = new GetAllRestaurantQuery();
            var restaurants = await _serviceProvider.GetRequiredService<IQueryHandler<GetAllRestaurantQuery, ApiResponse<List<RestaurantDTO>>>>().HandleAsync(query);
            return Ok(restaurants);
        }

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<ApiResponse>> GetRestaurantById([FromBody] GetOneRestaurantQuery query)
        //{
        //    //GetOneRestaurantQuery
        //    var restaurant = await _restaurantDetailsService.GetRestaurantByIdAsync(query.Id);
        //    return Ok(restaurant);
        //}

        [HttpPost]
        public async Task<ActionResult<ApiResponse<object?>>> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<CreateRestaurantCommand>>().HandleAsync(command);
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<ApiResponse>> DeleteRestaurant([FromRoute] int id)
        //{
        //    await _restaurantDetailsService.DeleteRestaurantAsync(id);
        //    return NoContent();
        //}

        //[HttpPatch("{id}")]
        //public async Task<ActionResult<ApiResponse>> UpdateRestaurant([FromRoute] int id, [FromBody] RestaurantDTO restaurant)
        //{
        //    await _restaurantDetailsService.UpdateRestaurantAsync(id, restaurant);
        //    return NoContent();
        //}

        //[HttpPost("Search")]
        //public async Task<ActionResult<ApiResponse>> SearchRestaurants([FromQuery] string? name,
        //    [FromQuery] string? category, [FromQuery] bool? hasDelivery)
        //{
        //    var restaurants = await _restaurantDetailsService.SearchRestaurants(name, category, hasDelivery);
        //    return Ok(restaurants);
        //}

    }
}
