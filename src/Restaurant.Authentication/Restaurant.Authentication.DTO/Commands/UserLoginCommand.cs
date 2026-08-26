using Restaurant.Management.Shared.Interfaces.Command;


namespace Restaurant.Authentication.DTO.Commands
{
    public class UserLoginCommand : ICommand
    {
        public string? AppUserName { get; set; }
        public string? Password { get; set; }
    }
}
