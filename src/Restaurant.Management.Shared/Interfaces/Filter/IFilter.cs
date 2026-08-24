using Restaurant.Management.Shared.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Restaurant.Management.Shared.Interfaces.Filter
{
    public interface IFilter<T, TQuery>
    {
        Expression<Func<T, bool>> Build(TQuery query);
    }
}
