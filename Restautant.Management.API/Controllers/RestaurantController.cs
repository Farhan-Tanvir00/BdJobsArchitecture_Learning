using Microsoft.AspNetCore.Mvc;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.DTO.Common;
using Restaurant.Management.Shared.Interfaces.Commands;


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
        //[HttpGet]
        //public async Task<ActionResult<ApiResponse> GetAllRestaurants()
        //{
        //    // GetAllRestaurantQuery
        //    var restaurants = await _restaurantManagementHandler.GetAllRestaurantsAsync();
        //    return Ok(restaurants);
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<ApiResponse>> GetRestaurantById([FromBody] GetOneRestaurantQuery query)
        //{
        //    //GetOneRestaurantQuery
        //    var restaurant = await _restaurantDetailsService.GetRestaurantByIdAsync(query.Id);
        //    return Ok(restaurant);
        //}

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            await _serviceProvider.GetRequiredService<ICommandHandler<CreateRestaurantCommand>>().HandleAsync(command);
            //return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
            return Ok();
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
