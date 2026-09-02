using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Order.DTO.Commands;
using Restaurant.Order.DTO.DTO;
using Restaurant.Order.DTO.Query;

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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApiResponse<object>>> GetRestaurantOrderById([FromRoute] int id)
        {
            var query = new GetOrderByIdQuery { Id = id };
            var result = await _serviceProvider.GetRequiredService<IQueryHandler<GetOrderByIdQuery, ApiResponse<OrderDto>>>().HandleAsync(query);
            return Ok(result);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<object?>>> CreateRestaurantOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<CreateOrderCommand>>().HandleAsync(command);
            return Ok(result);
        }
    }
}
