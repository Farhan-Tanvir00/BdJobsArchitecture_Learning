using Microsoft.AspNetCore.Mvc;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Order.DTO.Commands;

namespace Restaurant.Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestasurantOrderController: ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public RestasurantOrderController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<ApiResponse<object>>> GetRestaurantById([FromRoute] int id)
        //{
        //    var query = new GetOneRestaurantQuery { RestaurantId = id };
        //    var result = await _serviceProvider.GetRequiredService<IQueryHandler<GetOneRestaurantQuery, ApiResponse<RestaurantDTO>>>().HandleAsync(query);
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<ActionResult<ApiResponse<object?>>> CreateRestaurant([FromBody] CreateOrderCommand command)
        {
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<CreateOrderCommand>>().HandleAsync(command);
            return Ok(result);
        }
    }
}
