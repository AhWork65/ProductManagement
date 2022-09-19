using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProductManagementDataAccess.App_Context;
using ProductManagementDataAccess.Repositories.Repository.Base;
using ProductManagementDomain.IRepository.Base;

namespace ProductManagementDataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTest(this IServiceCollection services)
        {
             services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        }
    }
}
