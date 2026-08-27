using Microsoft.EntityFrameworkCore;
using Restaurant.Authentication.AggregateRoot;
using Restaurant.Authentication.AggregateRoot.Constants;
using Restaurant.Authentication.Repository.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.Repository.Implementations
{
    public class RoleRepository : GenericRepository<RoleAggregateRoot>
    {
        private readonly RestaurantAuthenticationDbContext _context;

        public RoleRepository(RestaurantAuthenticationDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<RoleAggregateRoot?> GetRoleByNameAsync(string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            return role;
        }

        public async Task<RoleAggregateRoot?> GetDefaultRoleAsync()
        {
            var defaultRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == Roles.User);
            return defaultRole;
        }
    }
}
