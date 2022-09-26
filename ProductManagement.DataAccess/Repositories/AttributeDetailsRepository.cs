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
    public class AttributeDetailsRepository : BaseRepository<ProductAttributeDetail>, IAttributeDetailRepository
    {

        public AttributeDetailsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<ProductAttributeDetail> GetByAttributesId(int attributeId)
        {
            return await _dbSet
                .Where(mdl => mdl.AttributeId == attributeId)
                .FirstAsync();
        }
        public async Task<ProductAttributeDetail> GetByAttributesIdWithAttributes(int attributeId)
        {

            return await _dbSet
                .Where(mdl => mdl.AttributeId == attributeId)
                .Include(mdl => mdl.Attribute)
                .FirstAsync();

        }

        public async Task<ProductAttributeDetail> GetByProductId(int productId)
        {

            return await _dbSet
                .Where(mdl => mdl.ProductId == productId)
                .FirstAsync();
        }

        public async Task<ProductAttributeDetail> GetAttributesByIdWithAttributesValues(int productAttributeId)
        {

            return await _dbSet
                .Where(mdl => mdl.Id == productAttributeId)
                .Include(mdl => mdl.Attribute)
                .FirstAsync();

        }

        public async Task<ProductAttributeDetail> GetByProductIdWithAttributesValues(int productId)
        {

            return await _dbSet
                .Where(mdl => mdl.ProductId == productId)
                .Include(mdl => mdl.Attribute)
                .FirstAsync();

        }

        public async Task<ProductAttributeDetail> GetByIdWithAttributesValues(int productAttributeId)
        {

            return await _dbSet
                .Where(mdl => mdl.Id == productAttributeId)
                .Include(mdl => mdl.Attribute)
                .FirstAsync();

        }

    }
}
