using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;
using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.Repositories.EntitiesRepositories
{
    public  interface IProductRepository : IBaseRepository<Product>
    {

        Task<IList<Product>> GetProductByClassification(int classificationId);
        Task<Product> GetProductByCode(string code);
        
        Task<IList<Product>> GetProductByCategory(int categoryId);
        Task<IList<Product>> GetProductByCategory(Category category);

        Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute);

        Task<Product> GetByIdWithAttributes(int productId); 

        Task<IList<Product>> GetActiveList();
        Task<IList<Product>> GetInactiveList();
       



    }
}
