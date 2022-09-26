using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Service.RelatedProductsServices
{
    public interface IRelatedProductsService
    {
        Task Add(RelatedProduct entity);
        Task AddToRelatedProduct(int relatedProductId, int relatedEntityId); 
        Task Remove(int relatedProductsID);
        Task Remove(RelatedProduct entity); 
        Task<RelatedProduct> GetById(int relatedProductId);
        Task<IList<RelatedProduct>> GetByBaseProductId(int BaseProductId);

    }
}
