using Microsoft.AspNetCore.Mvc;
using Restaurant.Management.Shared.Common;
using Restaurant.Orchestrator.DTO.Command;

namespace Restaurant.Orchestrator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantOrchestratorController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ApiResponse<object?>>> CreateOrderAndReceipt([FromBody] CreateOrderCommand command)
        {
            //var result = await _serviceProvider.GetRequiredService<ICommandHandler<CreateRestaurantCommand>>().HandleAsync(command);
            //return Ok(result);
        }
    }
}
