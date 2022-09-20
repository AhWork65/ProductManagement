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

       // Task<bool> HasAChild(int id ); // Logic  
       // Task<bool> HasAProduct(int id ); // Logic 
        Task<IEnumerable<Category>> GetActiveChildCategory(int parrentId );
        Task<IEnumerable<Category>> GetInactiveChildCategory(int parrentId );
        Task<IEnumerable<Category>> GetActiveList();
        Task<IEnumerable<Category>> GetInactiveList();
    }
}
