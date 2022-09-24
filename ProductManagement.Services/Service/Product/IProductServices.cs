using ProductManagement.Services.Dto.Product;
using ProductManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Models;

namespace ProductManagement.Services.Services.IServices
{
    public interface IProductServices
    {

        public Task Create(Product entity);
        public Task Update(Product entity);
        public void Delete(Product entity);
        public Task Delete(int categoryId);
        public Task<Product> GetById(int id);
        public Task<IList<Product>> GetAll();
        public Task<IList<Product>> GetAllActive();
        public Task<IList<Product>> GetAllInactive();
        Task ChangeUnitStock(int id , int enteredUnitStock ); 
        Task ChangeBaseUnitPrice(int id, int enteredPrice);
        Task<IList<Product>> GetProductByClassification(int classificationId);
        Task<IEnumerable<Product>> GetProductBaseOnClassification(int ClassificationId);

        Task<Product> GetProductByCode(string code);
        Task<IList<Product>> GetProductByCategory(int categoryId);
        Task<IList<Product>> GetProductByCategory(Category category);
        Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute);
        Task<Product> GetByIdWithAttributes(int productId);
        public bool IsIncreasingProductUpdateUnitStock(ProductUpdateUnitsInStockDTO dto);
        public void  IncreaseUnitsInStock(Product product, int enteredUnitInStock);
        public void  DeacreaseUnitsInStock(Product product, int enteredUnitInStock);
    }
}
