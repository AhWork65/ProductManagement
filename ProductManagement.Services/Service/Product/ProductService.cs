using System.Text;
using GlobalErrorApp.Exceptions;
using Newtonsoft.Json;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Domain.Dto.Product;
using ProductManagement.Services.Domain.Product;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.AttributeDetail;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Services.IServices;
using ProductManagementDataAccess.Config;
using ProductManagementWebApi.Models;
using NotImplementedException = System.NotImplementedException;

namespace ProductManagement.Services.Services.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IProductValidationService _ProductValidationService;
        private readonly IAttributeDetailService _AttributeDetailService;
        private HttpClient _httpClient;

        public ProductService
            (
                IProductRepository productRepository,
                IProductValidationService productValidationService,
                IAttributeDetailService AttributeDetailService
            )
        {

            _ProductRepository = productRepository;
            _ProductValidationService = productValidationService;
            _AttributeDetailService = AttributeDetailService;
            _httpClient = new HttpClient();

        }


        public ProductDetailDTO ConvertToProductDetailDto(Product product)
        {

            return DtoMapper.MapTo<Product, ProductDetailDTO>(product);

        }

        public IList<ProductListDTO> ConvertToProductListDTO(IList<Product> products)
        {

            return DtoMapper.ListMapTo<Product, ProductListDTO>(products);

        }



        public async Task<Product> Create(ProductDTO entity)
        {


            var isRecordExists = await _ProductValidationService.IsRecordWithEnteredCodeExists(entity.Code);
            if (isRecordExists)
                throw new BadRequestException("code is not valid ");

            var product = DtoMapper.MapTo<ProductDTO, Product>(entity);
            return await _ProductRepository.Add(product);
        }

        public async Task<Product> GetById(int id)
        {
            await IsProductWithEnteredIdExists(id);
            return await _ProductRepository.FindEntity(mdl => mdl.Id == id);
        }

        public async Task<Product> GetByCode(string code)
        {

            await IsProductWithEnteredCodeExists(code);
            return await _ProductRepository.FindEntity(mdl => mdl.Code == code);

        }

        public async Task Update(ProductDTO entity)
        {
            try
            {
                var isRecordExists = await _ProductValidationService.IsRecordWithEnteredIdExists(entity.Id);
                if (!isRecordExists)
                    throw new BadRequestException("Product is not Exists ");

                var product = DtoMapper.MapTo<ProductDTO, Product>(entity);
                await _ProductRepository.Update(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void Delete(Product entity)
        {

            _ProductRepository.Delete(entity);

        }

        public async Task Delete(int productId)
        {

            await IsProductWithEnteredIdExists(productId);
            await _ProductRepository.DeleteById(productId);

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




        public async Task<ProductDetailDTO> GetDetailById(int id)
        {

            await IsProductWithEnteredIdExists(id);
            var product = await _ProductRepository.GetDetailById(id);

            return ConvertToProductDetailDto(product);

        }

        public async Task<ProductDetailDTO> GetDetailByCode(string code)
        {

            await IsProductWithEnteredCodeExists(code);
            var product = await _ProductRepository.GetDetailByCode(code);
            return ConvertToProductDetailDto(product);

        }


        public async Task<IList<ProductListDTO>> GetProductByClassification(int classificationId)
        {

            await IsProductWithEnteredClassificationExists(classificationId);
            var products = await _ProductRepository.FindList(mdl => mdl.Classification == classificationId);
            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetActiveProductByClassification(int classificationId)
        {

            await IsActiveProductWithEnteredClassificationExists(classificationId);
            var products = await _ProductRepository.FindActiveList(mdl => mdl.Classification == classificationId);
            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetInactiveProductByClassification(int classificationId)
        {
            await IsInactiveProductWithEnteredClassificationExists(classificationId);
            var products = await _ProductRepository.FindInactiveList(mdl => mdl.Classification == classificationId);
            return ConvertToProductListDTO(products);
        }


        public async Task<IList<ProductListDTO>> GetProductByCategory(int categoryId)
        {

            await IsProductWithEnteredCategoryExists(categoryId);

            var products = await _ProductRepository.FindList(mdl => mdl.CategoryId == categoryId);

            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetActiveProductByCategory(int categoryId)
        {


            await IsActiveProductWithEnteredCategoryExists(categoryId);

            var products = await _ProductRepository.FindActiveList(mdl => mdl.CategoryId == categoryId);

            return ConvertToProductListDTO(products);


        }

        public async Task<IList<ProductListDTO>> GetInactiveProductByCategory(int categoryId)
        {

            await IsInactiveProductWithEnteredCategoryExists(categoryId);

            var products = await _ProductRepository.FindInactiveList(mdl => mdl.CategoryId == categoryId);

            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetProductBySearch(int categoryId, int classification)
        {

            await IsProductWithEnteredFilterExists(categoryId, classification);

            var product = await _ProductRepository
                .FindList(mdl => mdl.CategoryId == categoryId & mdl.Classification == classification);
            return ConvertToProductListDTO(product);

        }


        public async Task<IList<ProductListDTO>> GetActiveProductBySearch(int categoryId, int classification)
        {
            await IsActiveProductWithEnteredFilterExists(categoryId, classification);

            var product = await _ProductRepository
                .FindActiveList(mdl => mdl.CategoryId == categoryId & mdl.Classification == classification);
            return ConvertToProductListDTO(product);

        }


        public async Task<IList<ProductListDTO>> GetInactiveProductBySearch(int categoryId, int classification)
        {

            await IsInactiveProductWithEnteredFilterExists(categoryId, classification);

            var product = await _ProductRepository
                .FindInactiveList(mdl => mdl.CategoryId == categoryId & mdl.Classification == classification);
            return ConvertToProductListDTO(product);

        }


        public async Task<IList<ProductListDTO>> GetProductByAttribute(ProductAttributeDetail attribute)
        {

            var product = await _ProductRepository.GetProductByAttribute(attribute);

            return ConvertToProductListDTO(product);

        }



        public async Task<IEnumerable<ProductListDTO>> GetProductBaseOnClassification(int ClassificationId)
        {
            if (ClassificationId > 3)
                return new List<ProductListDTO>();

            if (ClassificationId < 0)
                return new List<ProductListDTO>();

            var classificationList = await GetProductByClassification(ClassificationId);
            var ProductLists = classificationList.Union(await GetProductBaseOnClassification(ClassificationId + 1));
            return ProductLists;

        }


        public Task ChangeUnitStock(int id, int enteredUnitStock)
        {
            throw new NotImplementedException();
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

        public async Task AddAttributeToProduct(IList<ProductAttributesDTO> productAttributes)
        {
            if (productAttributes == null)
                throw new BadRequestException("Attributes is not Valid ");

            foreach (var item in productAttributes)
            {
                var newAttributeDetail = DtoMapper.MapTo<ProductAttributesDTO, ProductAttributeDetail>(item);
                newAttributeDetail.ProductId = item.ProductId;
                await _AttributeDetailService.Add(newAttributeDetail);

            }

        }

        public async Task AddImageToProduct(ProductSendImageDto productSendImage)
        {

            if (productSendImage == null)

                using (_httpClient)
                {
                    var studentJson = JsonConvert.SerializeObject(productSendImage);
                    var requstContent = new StringContent(studentJson, Encoding.UTF8, "application/json");
                    var responseTask = await _httpClient.PostAsync(AppSettingConfiguration.FileWebApiAddress, requstContent);
                }

        }

        // ----------------------------------------------------------------- 


        public async Task IsProductWithEnteredIdExists(int id)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredIdExists(id))
                throw new BadRequestException("product not exists");

        }

        public async Task IsProductWithEnteredCodeExists(string code)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredCodeExists(code))
                throw new BadRequestException("product not exists");

        }

        public async Task IsProductWithEnteredClassificationExists(int classification)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredClassificationExists(classification))
                throw new BadRequestException("product not exists");

        }

        public async Task IsActiveProductWithEnteredClassificationExists(int classification)
        {

            if (!await _ProductValidationService.IsActiveRecordWithEnteredClassificationExists(classification))
                throw new BadRequestException("product not exists");

        }


        public async Task IsInactiveProductWithEnteredClassificationExists(int classification)
        {

            if (!await _ProductValidationService.IsInactiveRecordWithEnteredClassificationExists(classification))
                throw new BadRequestException("product not exists");

        }



        public async Task IsProductWithEnteredCategoryExists(int categoryId)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredCategoryExists(categoryId))
                throw new BadRequestException("product not exists");

        }

        public async Task IsActiveProductWithEnteredCategoryExists(int categoryId)
        {

            if (!await _ProductValidationService.IsActiveRecordWithEnteredCategoryExists(categoryId))
                throw new BadRequestException("product not exists");

        }

        public async Task IsInactiveProductWithEnteredCategoryExists(int categoryId)
        {

            if (!await _ProductValidationService.IsInactiveRecordWithEnteredCategoryExists(categoryId))
                throw new BadRequestException("product not exists");

        }

        public async Task IsProductWithEnteredFilterExists(int categoryId, int classification)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredFilterExists(categoryId, classification))
                throw new BadRequestException("product not exists ");

        }

        public async Task IsActiveProductWithEnteredFilterExists(int categoryId, int classification)
        {

            if (!await _ProductValidationService.IsActiveRecordWithEnteredFilterExists(categoryId, classification))
                throw new BadRequestException("product not exists ");

        }

        public async Task IsInactiveProductWithEnteredFilterExists(int categoryId, int classification)
        {

            if (!await _ProductValidationService.IsInactiveRecordWithEnteredFilterExists(categoryId, classification))
                throw new BadRequestException("product not exists ");

        }
    }
}
