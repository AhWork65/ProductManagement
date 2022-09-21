using ProductManagement.Services.Dto.Product;
using ProductManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Services.IServices
{
    public interface IProductServices
    {

        public Task Create(Product entity);
        public Task Update(Product entity);
        public void Delete(Product entity);
        public Task Delete(int categoryId);
        public Task<Product> GetById(int id);
        public Task<IEnumerable<Product>> GetAll();
        public Task<IEnumerable<Product>> GetAllActive();
        public Task<IEnumerable<Product>> GetAllInactive();
        Task ChangeUnitStock(int id , int enteredUnitStock ); 
        Task ChangeBaseUnitPrice(int id, int enteredPrice);
        Task<IEnumerable<Product>> GetProductByClassification(int classificationId);
        Task<Product> GetProductByCode(string code);
        Task<IEnumerable<Product>> GetProductByCategory(int categoryId);
        Task<IEnumerable<Product>> GetProductByCategory(Category category);
        Task<IEnumerable<Product>> GetProductByAttribute(ProductAttributeDetail attribute);
        Task<Product> GetByIdWithAttributes(int productId);
        public bool IsIncreasingProductUpdateUnitStock(ProductUpdateUnitsInStockDTO dto);
        public void  IncreaseUnitsInStock(Product product, int enteredUnitInStock);
        public void  DeacreaseUnitsInStock(Product product, int enteredUnitInStock);
    }
}
