using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ProductManagement.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTest(this IServiceCollection services)
        {
            // services.AddScoped<ITestManager, TestManager>();
            // services.AddScoped<ITestService, TestService>();
        }
    }
}
