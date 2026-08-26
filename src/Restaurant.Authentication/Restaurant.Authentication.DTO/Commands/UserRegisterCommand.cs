using Restaurant.Management.Shared.Interfaces.Command;


namespace Restaurant.Authentication.DTO.Commands
{
    public class UserRegisterCommand : ICommand
    {
        public string? AppUserName { get; set; }
        public string? AppUserEmail { get; set; }
        public string? AppUserPassword { get; set; }
    }
}
