using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagementWebApi.Models;

namespace ProductManagement.DataAccess.Repositories
{
    public  class ProductRepository : BaseRepository<Product>,  IProductRepository
    {

        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public async Task<Product> GetDetailById(int id)
        {

            return await _dbSet
                .Include(mdl => mdl.ProductAttributeDetails)
              
                .FirstAsync(mdl => mdl.Id == id); 


        }

        public async Task<Product> GetDetailByCode(string code)
        {

            return await _dbSet
                .Include(mdl => mdl.ProductAttributeDetails)
                .ThenInclude(mdl => mdl.Attribute)
                .FirstAsync(mdl => mdl.Code == code);

        }

        public async Task<Product> FindActive(Expression<Func<Product, bool>> predicate)
        {

            return await _dbSet
                .Where(predicate)
                .Where(mdl => mdl.IsActive == true & mdl.Category.IsActive == true)
                .FirstOrDefaultAsync(); 
        }

        public async Task<Product> FindInactive(Expression<Func<Product, bool>> predicate)
        {
            return await _dbSet
                .Where(predicate)
                .Where(mdl => mdl.IsActive == false)
                .FirstOrDefaultAsync();
        }


        public async  Task<IList<Product>> GetActiveList()
        {

            return await _dbSet
                .Where(mdl => mdl.IsActive == true && mdl.Category.IsActive == true)
                .ToListAsync(); 

        }

        public async  Task<IList<Product>> GetInactiveList()
        {

            return await _dbSet
                .Where(mdl => mdl.IsActive == false )
                .ToListAsync();

        }

        public async Task<IList<Product>> FindActiveList(Expression<Func<Product, bool>> predicate)
        {

            return await _dbSet
                .Where(predicate)
                .Where(mdl => mdl.IsActive == true & mdl.Category.IsActive == true)
                .ToListAsync(); 

        }

        public async Task<IList<Product>> FindInactiveList(Expression<Func<Product, bool>> predicate)
        {
            return await _dbSet
                .Where(predicate)
                .Where(mdl => mdl.IsActive == false)
                .ToListAsync();
        }

        public async Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute)
        {

            return await _dbSet.Where(mdl => mdl.ProductAttributeDetails.Contains(attribute)).ToListAsync();

        }
    }
}
