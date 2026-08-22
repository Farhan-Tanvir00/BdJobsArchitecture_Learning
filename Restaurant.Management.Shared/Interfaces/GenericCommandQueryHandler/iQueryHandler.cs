using Restaurant.Management.Shared.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
