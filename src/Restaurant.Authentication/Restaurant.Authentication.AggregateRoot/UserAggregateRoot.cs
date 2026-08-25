using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Restaurant.Authentication.AggregateRoot
{
    public class UserAggregateRoot
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        public List<RoleAggregateRoot> Roles { get; set; } = new List<RoleAggregateRoot>();

    }
}
