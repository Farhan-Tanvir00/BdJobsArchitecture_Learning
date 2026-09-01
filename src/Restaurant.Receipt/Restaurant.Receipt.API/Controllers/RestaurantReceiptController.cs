using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Receipt.DTO.Command;
using Restaurant.Shared.Interfaces.ServiceBus;

namespace Restaurant.Receipt.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantReceiptController: ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public RestaurantReceiptController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        //[HttpGet]
        //[Route("{id}")]
        //public async Task<ActionResult<ApiResponse<object>>> GetRestaurantById([FromRoute] int id)
        //{
        //    var query = new GetOrderByIdQuery { Id = id };
        //    var result = await _serviceProvider.GetRequiredService<IQueryHandler<GetOrderByIdQuery, ApiResponse<OrderDto>>>().HandleAsync(query);
        //    return Ok(result);
        //}

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ApiResponse<object?>>> CreateRestaurantReceipt([FromBody] CreateReceiptCommand command)
        {
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<CreateReceiptCommand>>().HandleAsync(command);
            return Ok(result);
        }
    }  
}
