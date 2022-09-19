using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductManagementDataAccess.App_Context;
using ProductManagementDataAccess.Repositories.Repository.Base;
using ProductManagementDomain.IRepository.IModelRepository;
using ProductManagementDomain.Models.Entites;

namespace ProductManagementDataAccess.Repositories.Repository
{
    public class ProductRepository : ActiveableEntitesRepository<Product>, IProductRepository
    {
        public ProductRepository(ManagementProductsContext context) : base(context)
        {
        }

        public async Task<Product> GetWithAttributesById(int id)
        {

            return await db
                .Include(mdl => mdl.ProductAttributeDetails)
                .Where(mdl => mdl.Id == id)
                .FirstAsync();

        }

        public async Task<IEnumerable<Product>> GetAllWithAttributes()
        {

            return await db
                .Include(mdl => mdl.ProductAttributeDetails)
                .ToListAsync();
        }

        public async Task<Product> GetActiveWithAttributesById(int id)
        {

            return await db
                .Include(mdl => mdl.ProductAttributeDetails)
                .Where(mdl => mdl.IsActive == true)
                .Where(mdl => mdl.Id == id)
                .FirstAsync();
        }

        public async Task<Product> GetDeactiveWithAttributesById(int id)
        {

            return await db
                .Include(mdl => mdl.ProductAttributeDetails)
                .Where(mdl => mdl.IsActive == false)
                .Where(mdl => mdl.Id == id)
                .FirstAsync();

        }

        public async Task<Product> FindActiveWithAttributesEntity(Expression<Func<Product, bool>> predicate)
        {

            return await db
                .Include(mdl => mdl.ProductAttributeDetails)
                .Where(mdl => mdl.IsActive == true)
                .Where(predicate)
                .FirstAsync();
        }

        public async Task<Product> FindDeactiveWithAttributesEntity(Expression<Func<Product, bool>> predicate)
        {

            return await db
                .Include(mdl => mdl.ProductAttributeDetails)
                .Where(mdl => mdl.IsActive == false)
                .Where(predicate)
                .FirstAsync();

        }

        public async Task<IEnumerable<Product>> FindActiveListWithAttributes(Expression<Func<Product, bool>> predicate)
        {

            return await db
                .Include(mdl => mdl.ProductAttributeDetails)
                .Where(mdl => mdl.IsActive == true)
                .Where(predicate)
                .ToListAsync();

        }

        public async Task<IEnumerable<Product>> FindDeactiveListWithAttributes(Expression<Func<Product, bool>> predicate)
        {

            return await db
                .Include(mdl => mdl.ProductAttributeDetails)
                .Where(mdl => mdl.IsActive == false)
                .Where(predicate)
                .ToListAsync();

        }
    }
}
