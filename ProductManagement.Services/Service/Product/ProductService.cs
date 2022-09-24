using System.Collections;
using System.Linq;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Services.Dto.Product;
using ProductManagement.Services.Services.IServices;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Services.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository; 
        }

        public async Task Create(Product entity)
        {

           await _ProductRepository.Add(entity); 

        }

        public async Task Delete(int categoryId)
        {

            await _ProductRepository.DeleteById(categoryId); 

        }

        public async Task<Product> GetById(int id)
        {

             return await _ProductRepository.GetById(id); 

        }

        public async Task<IList<Product>> GetAll()
        {
            return await _ProductRepository.GetAll(); 
        }

        public async Task<IList<Product>> GetAllActive()
        {
            return await _ProductRepository.GetActiveList(); 
        }

        public async Task<IList<Product>> GetAllInactive()
        {
            return await _ProductRepository.GetInactiveList();
        }

        public Task ChangeUnitStock(int id, int enteredUnitStock)
        {
            throw new NotImplementedException();
        }

        public async Task ChangeUnitStock(Product entity , int enteredUnitInStock)
        {

            entity.UnitStock = enteredUnitInStock; 

        }

        public  bool IsIncreasingProductUpdateUnitStock(ProductUpdateUnitsInStockDTO dto)
        {

            return  dto.State == 1 ;

        }
        public  void IncreaseUnitsInStock(Product product, int enteredUnitInStock)
        {
            
            product.UnitStock += enteredUnitInStock; 

        }

        public  void DeacreaseUnitsInStock(Product product, int enteredUnitInStock)
        {

            product.UnitStock -= enteredUnitInStock;

        }

        public async Task ChangeBaseUnitPrice(int id, int enteredPrice)
        {
            
            var obj = await _ProductRepository.GetById(id);
            obj.BaseUnitPrice = enteredPrice;
            
        }

        public async Task<IList<Product>> GetProductByClassification(int classificationId)
        {
            return await _ProductRepository.GetProductByClassification(classificationId); 
        }

        public async Task<IEnumerable<Product>> GetProductBaseOnClassification(int ClassificationId)
        {
            if (ClassificationId > 3)
                return new List<Product>();

            if (ClassificationId < 0)
                return new List<Product>();

            var ClassificationList = await GetProductByClassification(ClassificationId);
            var ProductLists = ClassificationList.Union(await GetProductBaseOnClassification(ClassificationId + 1));
            return ProductLists;
        }


        public async Task<Product> GetProductByCode(string code)
        {
            return await _ProductRepository.GetProductByCode(code); 
        }

        public async Task<IList<Product>> GetProductByCategory(int categoryId)
        {

            return await _ProductRepository.GetProductByCategory(categoryId); 

        }

        public  async Task<IList<Product>> GetProductByCategory(Category category)
        {
            return await _ProductRepository.GetProductByCategory(category); 
        }


        public async Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute)
        {

            return await _ProductRepository.GetProductByAttribute(attribute); 

        }

        public async Task<Product> GetByIdWithAttributes(int productId)
        {

            return await _ProductRepository.GetByIdWithAttributes(productId); 

        }

        public Task Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            _ProductRepository.Delete(entity);
        }
    }
}
