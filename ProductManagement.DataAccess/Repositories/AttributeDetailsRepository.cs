using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagementWebApi.Models;
using Attribute = System.Attribute;

namespace ProductManagement.DataAccess.Repositories
{
    public  class  AttributeDetailsRepository : IAttributeDetailRepository
    {
        private readonly Management_ProductsContext _Context;

        public AttributeDetailsRepository(Management_ProductsContext context)
        {

            _Context = context; 

        }
        public async  Task<ProductAttributeDetail> GetByAttributesId(int attributeId)
        {
            return await _Context.ProductAttributeDetails
                .Where(mdl => mdl.AttributeId == attributeId)
                .FirstAsync( ); 
        }
        public async Task<ProductAttributeDetail> GetByAttributesIdWithAttributes(int attributeId)
        {

            return await _Context.ProductAttributeDetails
                .Where(mdl => mdl.AttributeId == attributeId)
                .Include(mdl => mdl.Attribute)
                .FirstAsync(); 

        }

        public async  Task<ProductAttributeDetail> GetByProductId(int productId)
        {

            return await _Context.ProductAttributeDetails
                .Where(mdl => mdl.ProductId == productId)
                .FirstAsync(); 
        }

        public async  Task<ProductAttributeDetail> GetAttributesByIdWithAttributesValues(int productAttributeId)
        {

            return await _Context.ProductAttributeDetails
                .Where(mdl => mdl.Id == productAttributeId)
                .Include(mdl => mdl.Attribute)
                .FirstAsync();

        }

        public async Task<ProductAttributeDetail>  GetByProductIdWithAttributesValues(int productId)
        {

            return await _Context.ProductAttributeDetails
                .Where(mdl => mdl.ProductId == productId)
                .Include(mdl => mdl.Attribute)
                .FirstAsync();

        }

        public async  Task<ProductAttributeDetail> GetByIdWithAttributesValues(int productAttributeId)
        {

            return await _Context.ProductAttributeDetails
                .Where(mdl => mdl.Id == productAttributeId)
                .Include(mdl => mdl.Attribute)
                .FirstAsync(); 

        }

        public async Task<ProductAttributeDetail> GetById(int id)
        {

            return await _Context.ProductAttributeDetails
                .Where(mdl => mdl.Id == id)
                .FirstAsync(); 

        }

        public async  Task<IList<ProductAttributeDetail>> GetAll()
        {

            return await _Context.ProductAttributeDetails.ToListAsync(); 

        }

        public async  Task Add(ProductAttributeDetail entity)
        {
            await _Context.ProductAttributeDetails.AddAsync(entity); 
        }

        public void Delete(ProductAttributeDetail entity)
        {

            _Context.ProductAttributeDetails.Remove(entity); 

        }

        public async  Task DeleteById(int id)
        {

            var obj = await _Context.ProductAttributeDetails.FindAsync(id);
            _Context.ProductAttributeDetails.Remove(obj);

        }

        public async  Task<IList<ProductAttributeDetail>> FindList(Expression<Func<ProductAttributeDetail, bool>> predicate)
        {

            return await _Context.ProductAttributeDetails
                .Where(predicate)
                .ToListAsync(); 

        }

        public async  Task<ProductAttributeDetail> FindEntity(Expression<Func<ProductAttributeDetail, bool>> predicate)
        {

            return await _Context.ProductAttributeDetails
                .Where(predicate)
                .FirstAsync();

        }

        public Task Update(ProductAttributeDetail entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Any(Expression<Func<ProductAttributeDetail, bool>> predicate)
        {
            return await _Context.ProductAttributeDetails.AnyAsync(predicate);
        }

        public async Task<ProductAttributeDetail> FindById(int Id)
        {
            return await _Context.ProductAttributeDetails.FindAsync(Id); 
        }
    }
}
