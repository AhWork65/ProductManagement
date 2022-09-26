using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Models;
using ProductManagementWebApi.Models;

namespace ProductManagement.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>,  ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IList<Category>> GetActiveChildCategory(int parrentId)
        {
            return await _dbSet.Where(mdl => mdl.ParentId == parrentId)
                .Where(mdl => mdl.IsActive == true)
                .ToListAsync();

        }

        public async  Task<IList<Category>> GetInactiveChildCategory(int parrentId)
        {
            return await _dbSet.Where(mdl => mdl.ParentId == parrentId)
                .Where(mdl => mdl.IsActive == false)
                .ToListAsync();
        }

        public  async Task<IList<Category>> GetActiveList()
        {

            return await _dbSet.Where(mdl => mdl.IsActive == true).ToListAsync();

        }

        public async  Task<IList<Category>> GetInactiveList()
        {
            return await _dbSet.Where(mdl => mdl.IsActive == false).ToListAsync();
        }


    }
}
