using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Dto.Product;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;
using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.Repositories.EntitiesRepositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {

        Task<Product> GetDetailById(int id);
        Task<Product> GetDetailByCode(string code);
        Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute);
        Task<Product> FindActive(Expression<Func<Product, bool>> predicate);
        Task<Product> FindInactive(Expression<Func<Product, bool>> predicate);
        Task<IList<Product>> GetActiveList();
        Task<IList<Product>> GetInactiveList();
        Task<IList<Product>> FindActiveList(Expression<Func<Product, bool>> predicate);
        Task<IList<Product>> FindInactiveList(Expression<Func<Product, bool>> predicate);


    }
}
