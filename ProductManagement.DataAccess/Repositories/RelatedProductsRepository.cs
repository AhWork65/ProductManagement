using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;

namespace ProductManagement.DataAccess.Repositories
{
    public class RelatedProductsRepository : IRelatedProductRepository
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<RelatedProduct> _dbSet;

        public RelatedProductsRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Set<RelatedProduct>(); 
        }

        public async Task Add(RelatedProduct entity)
        {

            await _dbSet.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync(); 

        }

        public async Task Delete(int id)
        {

            var obj = await _dbSet.FindAsync(id);
            _dbSet.Remove(obj);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task Delete(RelatedProduct entity)
        {

            _dbSet.Remove(entity);
            await _unitOfWork.SaveChangesAsync(); 
        }

        public async Task<RelatedProduct> GetById(int id)
        {

            return await _dbSet.FindAsync(id); 

        }

        public async Task<IList<Product>> GetListOfProductsByBaseProductId(int id)
        {

            return await _dbSet.Where(mdl => mdl.BaseProductId == id)
                .Select(mdl => mdl.RelatedProductNavigation)
                .ToListAsync();

        }

        public async Task<IList<int>> GetListOfProductsIdByBaseProductId(int id)
        {

            return await _dbSet
                .Where(mdl => mdl.BaseProductId == id)
                .Select(mdl => mdl.RelatedProductId)
                .ToListAsync();

        }

        public async Task<bool> Any(Expression<Func<RelatedProduct, bool>> predicate)
        {

            return await _dbSet.AnyAsync(predicate); 

        }

        
        
    }
}
