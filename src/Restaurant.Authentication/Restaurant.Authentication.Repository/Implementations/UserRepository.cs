using Restaurant.Authentication.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.Repository.Implementations
{
    public class UserRepository: GenericRepository<UserAggregateRoot>
    {
        private readonly List<UserAggregateRoot> _users;
    }
}
