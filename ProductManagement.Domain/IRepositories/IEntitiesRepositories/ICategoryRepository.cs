using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface ICategoryRepository : IBaseRepository<Category>
    {


        Task<IList<Category>> GetActiveChildCategory(int parrentId );
        Task<IList<Category>> GetInactiveChildCategory(int parrentId );
        Task<IList<Category>> GetActiveList();
        Task<IList<Category>> GetInactiveList();
    }
}
