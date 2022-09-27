using ProductManagement.Domain.Dto.Product;
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

        Task<Product> Create(Product entity);
        Task Update(Product entity);
        void Delete(Product entity);
        Task Delete(int categoryId);
        
        Task<IList<ProductListDTO>> GetAll();
        Task<IList<ProductListDTO>> GetAllActive();
        Task<IList<ProductListDTO>> GetAllInactive();
        Task<IList<ProductListDTO>> GetProductByCategory(int categoryId);
        Task<IList<ProductListDTO>> GetProductByCategory(Category category);
        Task<IList<ProductListDTO>> GetProductByClassification(int classificationId);
        Task<IEnumerable<Product>> GetProductBaseOnClassification(int ClassificationId);

        Task<Product> GetById(int id);
        Task<Product> GetProductByCode(string code);
        Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute);
        Task<Product> GetByIdWithAttributes(int productId);
        
        bool IsIncreasingProductUpdateUnitStock(ProductUpdateUnitsInStockDTO dto);
        void IncreaseUnitsInStock(Product product, int enteredUnitInStock);
        void DeacreaseUnitsInStock(Product product, int enteredUnitInStock);
        Task ChangeUnitStock(int id, int enteredUnitStock);
        Task ChangeBaseUnitPrice(int id, int enteredPrice);
    }
}
