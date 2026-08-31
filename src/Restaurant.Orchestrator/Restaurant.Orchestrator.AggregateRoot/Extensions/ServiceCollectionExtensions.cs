using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Orchestrator.AggregateRoot.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOrchestratorAggregateRoot(this IServiceCollection services)
        {
            services.AddScoped<OrchestratorAggregateRoot>();
        }
    }
}
