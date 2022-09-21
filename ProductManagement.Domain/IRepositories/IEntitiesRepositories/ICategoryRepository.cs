using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {


        Task<IEnumerable<Category>> GetActiveChildCategory(int parrentId);
        Task<IEnumerable<Category>> GetInactiveChildCategory(int parrentId);
        Task<IEnumerable<Category>> GetActiveList();
        Task<IEnumerable<Category>> GetInactiveList();

    }
}
