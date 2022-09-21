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
        private readonly Management_ProductsContext _Context;

        public RelatedProductsRepository(Management_ProductsContext  context)
        {
                
            _Context = context;

        }
        public async  Task<RelatedProduct> GetById(int id)
        {

            return await _Context.RelatedProducts.FindAsync(id);

        }

        public async  Task<IEnumerable<RelatedProduct>> GetAll()
        {

            return await _Context.RelatedProducts.ToListAsync(); 

        }

        public async  Task Add(RelatedProduct entity)
        {

            await  _Context.RelatedProducts.AddAsync(entity); 

        }

        public void Delete(RelatedProduct entity)
        {

            _Context.RelatedProducts.Remove(entity); 

        }

        public async  Task DeleteById(int id)
        {
            
            var obj = await _Context.RelatedProducts.FindAsync(id);
            _Context.RelatedProducts.Remove(obj); 

        }

        
        public async Task<IList<RelatedProduct>> FindList(Expression<Func<RelatedProduct, bool>> predicate)
        {

            return await _Context.RelatedProducts.Where(predicate).ToListAsync(); 

        }

        public async Task<RelatedProduct> FindEntity(Expression<Func<RelatedProduct, bool>> predicate)
        {

            return await _Context.RelatedProducts.Where(predicate).FirstAsync();

        }

        public Task Update(RelatedProduct entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Any(Expression<Func<RelatedProduct, bool>> predicate)
        {
            return await _Context.RelatedProducts.AnyAsync(predicate);
        }

        public async Task<IEnumerable<RelatedProduct>> GetByBaseProductIdIwthRelatedProducts(int baseProductId)
        {

            return await _Context.RelatedProducts
                .Where(mdl => mdl.BaseProductId == baseProductId)
                .Include(mdl => mdl.RelatedProductNavigation)
                .ToListAsync(); 

        }
    }
}
