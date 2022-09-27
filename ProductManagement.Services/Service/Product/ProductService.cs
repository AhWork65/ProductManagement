using GlobalErrorApp.Exceptions;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Domain.Dto.Product;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Services.IServices;
using ProductManagementWebApi.Models;
using NotImplementedException = System.NotImplementedException;

namespace ProductManagement.Services.Services.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IProductValidationService _ProductValidationService;

        public ProductService
            (
                IProductRepository productRepository,
                IProductValidationService productValidationService
            )
        {

            _ProductRepository = productRepository;
            _ProductValidationService = productValidationService;

        }

        public ProductListDTO ConvertToProductListDTO(Product product)
        {

            return DtoMapper.MapTo<Product, ProductListDTO>(product);

        }

        public IList<ProductListDTO> ConvertToProductListDTO(IList<Product> products)
        {

            return DtoMapper.ListMapTo<Product, ProductListDTO>(products);

        }

        public async Task<Product> Create(Product entity)
        {

            var isRecordExists = await _ProductValidationService.IsRecordWithEnteredCodeExists(entity.Code);
            if (!isRecordExists)
                throw new BadRequestException("code is not valid ");

            return await _ProductRepository.Add(entity);


        }

        public Task Update(Product entity)
        {

            throw new NotImplementedException();

        }

        public void Delete(Product entity)
        {

            _ProductRepository.Delete(entity);

        }

        public async Task Delete(int categoryId)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredIdExists(categoryId))
                throw new BadRequestException("Product not found");

            await _ProductRepository.DeleteById(categoryId);

        }



        public async Task<IList<ProductListDTO>> GetAll()
        {

            var products = await _ProductRepository.GetAll();
            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetAllActive()
        {

            var products = await _ProductRepository.GetActiveList();
            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetAllInactive()
        {

            var products = await _ProductRepository.GetInactiveList();
            return ConvertToProductListDTO(products);
        }




        public async Task<Product> GetById(int id)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredIdExists(id))
                throw new BadRequestException("Product  not found ");

            return await _ProductRepository.GetById(id);

        }

        public async Task<Product> GetProductByCode(string code)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredCodeExists(code))
                throw new BadRequestException("product not found ");

            return await _ProductRepository.GetProductByCode(code);

        }


        public async Task<IList<ProductListDTO>> GetProductByClassification(int classificationId)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredClassificationExists(classificationId))
                throw new BadRequestException("product not found "); 

            var products = await _ProductRepository.GetProductByClassification(classificationId);
            return ConvertToProductListDTO(products);

        }

        public async Task<IEnumerable<Product>> GetProductBaseOnClassification(int ClassificationId)
        {
            //     // if (ClassificationId > 3)
            //     //     return new List<Product>();
            //     //
            //     // if (ClassificationId < 0)
            //     //     return new List<Product>();
            //     //
            //     // var ClassificationList = await GetProductByClassification(ClassificationId);
            //     // var ProductLists = ClassificationList.Union(await GetProductBaseOnClassification(ClassificationId + 1));
            //     // return ProductLists;
            throw new NotImplementedException();
 
        }




        public async Task<IList<ProductListDTO>> GetProductByCategory(int categoryId)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredCategoryExists(categoryId))
                throw new BadRequestException("Product not found ");

            var products = await _ProductRepository.GetProductByCategory(categoryId);

            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetProductByCategory(Category category)
        {

            var products = await _ProductRepository.GetProductByCategory(category);
            return ConvertToProductListDTO(products);

        }


        public async Task<IList<Product>> GetProductByAttribute(ProductAttributeDetail attribute)
        {

            return await _ProductRepository.GetProductByAttribute(attribute);

        }

        public async Task<Product> GetByIdWithAttributes(int productId)
        {

            return await _ProductRepository.GetByIdWithAttributes(productId);

        }



        public Task ChangeUnitStock(int id, int enteredUnitStock)
        {
            throw new NotImplementedException();
        }


        public async Task ChangeUnitStock(Product entity, int enteredUnitInStock)
        {

            entity.UnitStock = enteredUnitInStock;

        }

        public bool IsIncreasingProductUpdateUnitStock(ProductUpdateUnitsInStockDTO dto)
        {

            return dto.State == 1;

        }
        public void IncreaseUnitsInStock(Product product, int enteredUnitInStock)
        {

            product.UnitStock += enteredUnitInStock;

        }

        public void DeacreaseUnitsInStock(Product product, int enteredUnitInStock)
        {

            product.UnitStock -= enteredUnitInStock;

        }

        public async Task ChangeBaseUnitPrice(int id, int enteredPrice)
        {

            var obj = await _ProductRepository.GetById(id);
            obj.BaseUnitPrice = enteredPrice;

        }
    }
}
