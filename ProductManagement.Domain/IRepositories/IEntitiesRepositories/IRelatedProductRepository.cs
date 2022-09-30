using ProductManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        Task Delete(RelatedProduct entity);

        Task<RelatedProduct> GetById(int id); 
        Task<IList<Product>> GetListOfProductsByBaseProductId(int id );
        Task<IList<int>> GetListOfProductsIdByBaseProductId(int id );
        Task<bool> Any(Expression<Func<RelatedProduct, bool>> predicate); 


    }
}
