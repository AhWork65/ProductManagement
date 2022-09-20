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
        // Task ChangeUnitStock(int id , int enteredUnitStock ); // Logic 
        // Task ChangeBaseUnitPrice(int id, int enteredPrice);  // Logic 
        Task<IEnumerable<Product>> GetProductByClassification(int classificationId);
        Task<Product> GetProductByCode(string code);
        
        Task<IEnumerable<Product>> GetProductByCategory(int categoryId);
        Task<IEnumerable<Product>> GetProductByCategory(Category category);

        Task<IEnumerable<Product>> GetProductByAttribute(ProductAttributeDetail attribute);

        Task<Product> GetByIdWithAttributes(int productId); 

        Task<IEnumerable<Product>> GetActiveList();
        Task<IEnumerable<Product>> GetInactiveList();
       



    }
}
