using Microsoft.AspNetCore.Mvc;
using Restaurant.Authentication.DTO.Commands;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;

namespace Restaurant.Authentication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController: ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        public AccountsController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<object?>>> Register([FromBody] UserRegisterCommand command)
        {
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<UserRegisterCommand>>().HandleAsync(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<object?>>> Login([FromBody] UserLoginCommand command)
        {
            var result = await _serviceProvider.GetRequiredService<ICommandHandler<UserLoginCommand>>().HandleAsync(command);
            return Ok(result);
        }

        //[HttpPost("asignRole")]
        ////[Authorize(Roles = "Admin")]
        //public async Task<ActionResult<string>> AsignRole([FromBody] RoleAsignDTO roleAsignDTO)
        //{
        //    var result = await _authService.AssignRoleAsync(roleAsignDTO);
        //    return Ok(result);
        //}

        //[HttpGet]
        ////[Authorize(Roles = "Admin")]
        //public async Task<ActionResult<UserDTO>> GetAllUsers()
        //{
        //    var result = await _authService.GetAllUsers();
        //    return Ok(result);
        //}

        //[HttpPost("Search")]
        ////[Authorize(Roles = "Admin")]
        //public async Task<ActionResult<IEnumerable<UserDTO>>> SearchUsers([FromQuery] string? name, [FromQuery] string? email)
        //{
        //    var result = await _authService.SearchUsers(name, email);
        //    return Ok(result);
        //}
    }
}
