using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagementWebApi.Models;

namespace ProductManagement.DataAccess.Repositories
{
    public  class ProductRepository : BaseRepository<Product>,  IProductRepository
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Set<Product>();
        }

        public async  Task<IList<Product>> GetProductByClassification(int classificationId)
        {

            return await _dbSet.Where(mdl => mdl.Classification == classificationId).ToListAsync(); 

        }

        public async Task<Product> GetProductByCode(string code)
        {

            return await _dbSet.Where(mdl => mdl.Code == code).FirstAsync(); 

        }

        public async  Task<IList<Product>> GetProductByCategory(int categoryId)
        {

            return await _dbSet.Where(mdl => mdl.CategoryId == categoryId).ToListAsync(); 

        }

        public async  Task<IList<Product>> GetProductByCategory(Category category)
        {

            return await _dbSet.Where(mdl => mdl.Category == category).ToListAsync(); 

        }

        public async  Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute)
        {

            return await _dbSet.Where(mdl => mdl.ProductAttributeDetails.Contains(attribute)).ToListAsync();

        }

        public async  Task<Product> GetByIdWithAttributes(int productId)
        {

            return  await _dbSet
                .Include(mdl => mdl.ProductAttributeDetails)
                .ThenInclude(mdl => mdl.Attribute)
                .Where(mdl => mdl.Id == productId)
                .FirstAsync();

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
    }
}
