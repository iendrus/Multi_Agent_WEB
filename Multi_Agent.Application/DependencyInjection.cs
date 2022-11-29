using Microsoft.Extensions.DependencyInjection;
using Multi_Agent.Application.Interfaces;
using Multi_Agent.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Agent.Application
{
    public static class DependencyInjection
    {
        // dodanie repozytoriów w konfiguracji programu
        //AddTransient - przy każdym uzyciu podowany jest nowy obiekt danego typu (są jeszcze AddScoped i AddSingleton)
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services.AddTransient<IPolicyService, PolicyService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
