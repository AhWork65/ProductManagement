using ProductManagementDomain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProuctManagemetServices.Services.IServices
{
    internal interface IProductService : IActiveableEntitesDataService<Product>
    {
        Task<Product> GetWithAttributesById(int id);
        Task<IEnumerable<Product>> GetAllWithAttributes();
        Task<Product> GetActiveWithAttributesById(int id);
        Task<Product> GetDeactiveWithAttributesById(int id);
        Task<Product> FindActiveWithAttributesEntity(Expression<Func<Product, bool>> predicate);
        Task<Product> FindDeactiveWithAttributesEntity(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>> FindActiveListWithAttributes(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>> FindDeactiveListWithAttributes(Expression<Func<Product, bool>> predicate);
    }
}
