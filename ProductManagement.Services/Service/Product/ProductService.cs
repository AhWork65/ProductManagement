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

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _ProductRepository.GetAll(); 
        }

        public async Task<IEnumerable<Product>> GetAllActive()
        {
            return await _ProductRepository.GetActiveList(); 
        }

        public async Task<IEnumerable<Product>> GetAllInactive()
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

        public async Task<IEnumerable<Product>> GetProductByClassification(int classificationId)
        {

            return await _ProductRepository.GetProductByClassification(classificationId); 

        }

        public async Task<IList<Product>> GetProductBaseOnClassification(int ClassificationId)
        {

            IList<Product> products = new List<Product>();
            for (int i = 0; i <= ClassificationId; i++)
            {
                var product = await _ProductRepository.GetProductByClassification(i);
                foreach (var item in product) products.Append<Product>(item);
            }

            return products; 
        }
        public async Task<Product> GetProductByCode(string code)
        {

            return await _ProductRepository.GetProductByCode(code); 

        }

        public async Task<IEnumerable<Product>> GetProductByCategory(int categoryId)
        {

            return await _ProductRepository.GetProductByCategory(categoryId); 

        }

        public  async Task<IEnumerable<Product>> GetProductByCategory(Category category)
        {
            return await _ProductRepository.GetProductByCategory(category); 
        }


        public async Task<IEnumerable<Product>> GetProductByAttribute(ProductAttributeDetail attribute)
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
