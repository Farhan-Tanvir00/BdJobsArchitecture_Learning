using Restaurant.Authentication.DTO.Commands;
using Restaurant.Authentication.DTO.Entity;


namespace Restaurant.Authentication.AggregateRoot
{
    public class UserAggregateRoot : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        public List<RoleAggregateRoot> Roles { get; set; } = new List<RoleAggregateRoot>();


        public UserAggregateRoot CreateNewUser(UserRegisterCommand command)
        {
            return new UserAggregateRoot
            {
                UserName = command.AppUserName,
                Email = command.AppUserEmail,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.AppUserPassword)
            };
        }

        public UserAggregateRoot AddInitialRole(UserAggregateRoot user, RoleAggregateRoot role)
        {
            user.Roles.Add(role);
            return user;
        }


    }
}
