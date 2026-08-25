using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Authentication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController: ControllerBase
    {

        //public AccountsController()
        //{
          
        //}

        //[HttpPost("register")]
        //public async Task<ActionResult<AuthResponseDTO?>> Register([FromBody] RegisterDTO registerDTO)
        //{
        //    var result = await _authService.RegisterAsync(registerDTO);
        //    return Ok(result);
        //}

        //[HttpPost("login")]
        //public async Task<ActionResult<AuthResponseDTO?>> Login([FromBody] LoginDTO loginDTO)
        //{
        //    var result = await _authService.LoginAsync(loginDTO);
        //    return Ok(result);
        //}

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
