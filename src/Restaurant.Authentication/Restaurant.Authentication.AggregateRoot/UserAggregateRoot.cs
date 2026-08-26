using Restaurant.Authentication.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Restaurant.Authentication.AggregateRoot
{
    public class UserAggregateRoot : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }

        public List<RoleAggregateRoot> Roles { get; set; } = new List<RoleAggregateRoot>();

    }
}
