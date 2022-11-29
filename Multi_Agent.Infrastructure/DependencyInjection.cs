using Microsoft.Extensions.DependencyInjection;
using Multi_Agent.Domain.Interfaces;
using Multi_Agent.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IPolicyRepository, PolicyRepository>();
            return services;

        }
    }
}
