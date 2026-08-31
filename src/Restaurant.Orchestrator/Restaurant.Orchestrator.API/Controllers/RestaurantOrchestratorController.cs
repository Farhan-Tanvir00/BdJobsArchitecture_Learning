using Microsoft.AspNetCore.Mvc;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Orchestrator.DTO.Command;

namespace Restaurant.Orchestrator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantOrchestratorController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public RestaurantOrchestratorController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<object?>>> CreateOrderWiseReceipt([FromBody] CreateOrderWiseReceiptCommand command)
        {
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<CreateOrderWiseReceiptCommand>>().HandleAsync(command);
            return Ok(result);
        }
    }
}
