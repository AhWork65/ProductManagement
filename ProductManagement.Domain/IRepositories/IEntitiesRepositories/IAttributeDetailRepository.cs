using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;
using Attribute = System.Attribute;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public interface IAttributeDetailRepository : IBaseRepository<ProductAttributeDetail> 
    {

        public Task<ProductAttributeDetail> GetByAttributesId(int attributeId);
        public Task<ProductAttributeDetail> GetByAttributesIdWithAttributes(int attributeId);
        public Task<ProductAttributeDetail> GetByProductId(int productId);
        public Task<ProductAttributeDetail> GetByProductIdWithAttributesValues(int productId);

        public Task<ProductAttributeDetail> GetAttributesByIdWithAttributesValues(int productAttributeId);
        
    }
}
