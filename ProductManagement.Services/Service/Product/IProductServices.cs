using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Dto.Product;
using ProductManagementWebApi.Models;


namespace ProductManagement.Services.Services.IServices
{
    public interface IProductServices
    {

        Task<Product> Create(ProductDTO entity);
        Task<Product> GetById(int id); 
        Task<Product> GetByCode(string code);
        Task Update(ProductDTO entity);
        void Delete(Product entity);
        Task Delete(int categoryId);

        Task<ProductCategoryAndClassificationDetailDTO> GetCategoryAndClassificationDetail(int productId); 

        Task<IList<ProductListDTO>> GetAll();
        Task<IList<ProductListDTO>> GetAllActive();
        Task<IList<ProductListDTO>> GetAllInactive();
        Task<IList<ProductListDTO>> GetProductByCategory(int categoryId);
        Task<IList<ProductListDTO>> GetActiveProductByCategory(int categoryId);
        Task<IList<ProductListDTO>> GetInactiveProductByCategory(int categoryId);
        Task<IList<ProductListDTO>> GetProductBySearch(int categoryId, int classification); 
        Task<IList<ProductListDTO>> GetActiveProductBySearch(int categoryId, int classification); 
        Task<IList<ProductListDTO>> GetInactiveProductBySearch(int categoryId, int classification); 

        Task<IList<ProductListDTO>> GetProductByClassification(int classificationId);
        Task<IList<ProductListDTO>> GetActiveProductByClassification(int classificationId);
        Task<IList<ProductListDTO>> GetInactiveProductByClassification(int classificationId);
        Task<IList<ProductListDTO>> GetProductByAttribute(ProductAttributeDetail attribute);
        Task<IEnumerable<ProductListDTO>> GetProductBaseOnClassification(int ClassificationId);

        Task<ProductDetailDTO> GetDetailById(int id);
        Task<ProductDetailDTO> GetDetailByCode(string code);
        
 
        Task UpdateUnitStock(ProductUpdateUnitsInStockDTO obj);
        Task UpdateBaseUnitPrice(ProductUpdateUnitPriceDTO obj);
        Task AddAttributeToProduct(IList<ProductAttributesDTO> productAttributes);
        Task<ObjectResult> AddImageToProduct(ProductSendImageDto productSendImage);
    }
}
