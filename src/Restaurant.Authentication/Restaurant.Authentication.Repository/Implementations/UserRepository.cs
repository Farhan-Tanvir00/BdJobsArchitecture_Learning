using Microsoft.EntityFrameworkCore;
using Restaurant.Authentication.AggregateRoot;
using Restaurant.Authentication.Repository.Persistance;

namespace Restaurant.Authentication.Repository.Implementations
{
    public class UserRepository: GenericRepository<UserAggregateRoot>
    {
        private readonly RestaurantAuthenticationDbContext _context;

        public UserRepository(RestaurantAuthenticationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserAggregateRoot?> GetByUserNameAsync(string userName)
        {
            var user = await _context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }

    }
}
