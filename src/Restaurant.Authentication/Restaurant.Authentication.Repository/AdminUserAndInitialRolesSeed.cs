using Restaurant.Authentication.AggregateRoot;
using Restaurant.Authentication.AggregateRoot.Constants;
using Restaurant.Authentication.Repository.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Authentication.Repository
{
    public class AdminUserAndInitialRolesSeed
    {
        private readonly RestaurantAuthenticationDbContext _restaurentDbContext;
        public AdminUserAndInitialRolesSeed(RestaurantAuthenticationDbContext restaurentDbContext)
        {
            _restaurentDbContext = restaurentDbContext;
        }
        public async Task SeedAsync()
        {
            if (!await _restaurentDbContext.Database.CanConnectAsync())
                return;

            if (!_restaurentDbContext.Roles.Any())
            {
                var roles = new List<RoleAggregateRoot>
                {
                    new RoleAggregateRoot { Name = Roles.Admin },
                    new RoleAggregateRoot { Name = Roles.Owner },
                    new RoleAggregateRoot { Name = Roles.User },
                };

                _restaurentDbContext.Roles.AddRange(roles);
                await _restaurentDbContext.SaveChangesAsync();
            }

            if (!_restaurentDbContext.Users.Any())
            {
                var adminRole = await _restaurentDbContext.Roles
                    .FirstAsync(r => r.Name == Roles.Admin);

                var user = new UserAggregateRoot
                {
                    UserName = "Farhan",
                    Email = "farhan.tanvir@example.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("12345"),
                    Roles = new List<RoleAggregateRoot> { adminRole }
                };

                _restaurentDbContext.Users.Add(user);
                await _restaurentDbContext.SaveChangesAsync();
            }
        }
    }
}
