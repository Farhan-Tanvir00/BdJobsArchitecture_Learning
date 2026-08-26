using Restaurant.Management.Shared.Interfaces.Command;

namespace Restaurant.Authentication.DTO.Commands
{
    public class RoleAsignCommand : ICommand
    {
        public string? AppUserName { get; set; }
        public string? UserRoleName { get; set; }
    }
}
