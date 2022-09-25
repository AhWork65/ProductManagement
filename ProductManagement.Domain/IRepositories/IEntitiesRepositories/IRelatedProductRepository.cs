using ProductManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Repositories.Base;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public interface IRelatedProductRepository
    {

        // Task<IList<RelatedProduct>> GetByBaseProductIdIwthRelatedProducts(int baseProductId);
        Task Add(RelatedProduct entityProduct);

        Task Delete(int id);
        Task<RelatedProduct> GetById(int id); 
        Task<IList<RelatedProduct>> GetByBaseProductId(int id );



    }
}
