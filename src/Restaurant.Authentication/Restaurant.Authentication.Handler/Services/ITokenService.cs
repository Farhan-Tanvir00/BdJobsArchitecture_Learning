using Restaurant.Authentication.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.Handler.Services
{
    public interface ITokenService
    {
        string GenerateToken(UserAggregateRoot user);
    }
}
