using System.Text;
using GlobalErrorApp.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Domain.Dto.Product;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.AttributeDetail;
using ProductManagement.Services.Service.CategoryService.Validation;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Service.Product.ValidationHanlder;
using ProductManagement.Services.Services.IServices;
using ProductManagementDataAccess.Config;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Services.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IProductValidationHandler _ProductValidationHandler;
        private readonly IAttributeDetailService _AttributeDetailService;
        private readonly IUnitOfWork _UnitOfWork;

        private HttpClient _httpClient;

        public ProductService
            (
                IProductRepository productRepository,
                IProductValidationHandler productValidationHandler,
                IAttributeDetailService AttributeDetailService,
                IUnitOfWork unitOfWork
            )
        {

            _ProductRepository = productRepository;
            _ProductValidationHandler = productValidationHandler;
            _AttributeDetailService = AttributeDetailService;
            _UnitOfWork = unitOfWork;
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

        public ProductCategoryAndClassificationDetailDTO ConvertToProductCategoryAndClassificationDetailDto(
            Product product)
        {

            return DtoMapper.MapTo<Product, ProductCategoryAndClassificationDetailDTO>(product);

        }

        public async Task<Product> Create(ProductDTO entity)
        {

            await _ProductValidationHandler.IsEnteredCodeIsUniqueValidationHandler(entity.Code);
            await _ProductValidationHandler.IsCategoryWithEnteredIdExistsValidationHandler(entity.CategoryId);

            var product = DtoMapper.MapTo<ProductDTO, Product>(entity);
            return await _ProductRepository.Add(product);

        }


        public async Task<Product> GetById(int id)
        {

            await _ProductValidationHandler.IsProductWithEnteredIdExistsValidationHandler(id);

            return await _ProductRepository.FindEntity(mdl => mdl.Id == id);
        }


        public async Task<Product> GetByCode(string code)
        {

            await _ProductValidationHandler.IsProductWithEnteredCodeExistsValidationHandler(code);

            return await _ProductRepository.FindEntity(mdl => mdl.Code == code);

        }


        public async Task Update(ProductDTO entity)
        {
            await _ProductValidationHandler.IsProductWithEnteredIdExistsValidationHandler(entity.Id);
            await _ProductValidationHandler.IsCategoryWithEnteredIdExistsValidationHandler(entity.CategoryId);

            var product = DtoMapper.MapTo<ProductDTO, Product>(entity);
            await _ProductRepository.Update(product);


        }

        public void Delete(Product entity)
        {

            _ProductRepository.Delete(entity);

        }

        public async Task Delete(int productId)
        {

            await _ProductValidationHandler.IsProductWithEnteredIdExistsValidationHandler(productId);
            await _ProductRepository.DeleteById(productId);

        }

        public async Task<ProductCategoryAndClassificationDetailDTO> GetCategoryAndClassificationDetail(int productId)
        {

            await _ProductValidationHandler.IsProductWithEnteredIdExistsValidationHandler(productId);
            var product = await _ProductRepository.GetById(productId);

            return ConvertToProductCategoryAndClassificationDetailDto(product);

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

            await _ProductValidationHandler.IsProductWithEnteredIdExistsValidationHandler(id);
            var product = await _ProductRepository.GetDetailById(id);

            return ConvertToProductDetailDto(product);

        }

        public async Task<ProductDetailDTO> GetDetailByCode(string code)
        {

            await _ProductValidationHandler.IsProductWithEnteredCodeExistsValidationHandler(code);
            var product = await _ProductRepository.GetDetailByCode(code);
            return ConvertToProductDetailDto(product);

        }


        public async Task<IList<ProductListDTO>> GetProductByClassification(int classificationId)
        {

            await _ProductValidationHandler.IsProductWithEnteredClassificationExistsValidationHandler(classificationId);
            return await GetProductByClassificationBase(classificationId);

        }

        private async Task<IList<ProductListDTO>> GetProductByClassificationBase(int classificationId)
        {

            var products = await _ProductRepository.FindList(mdl => mdl.Classification == classificationId);
            return ConvertToProductListDTO(products);
        }

        public async Task<IList<ProductListDTO>> GetActiveProductByClassification(int classificationId)
        {

            await _ProductValidationHandler.IsProductWithEnteredClassificationExistsValidationHandler(classificationId);
            await _ProductValidationHandler.IsActiveProductWithEnteredClassificationExistsValidationHandler(classificationId);

            var products = await _ProductRepository.FindActiveList(mdl => mdl.Classification == classificationId);
            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetInactiveProductByClassification(int classificationId)
        {

            await _ProductValidationHandler.IsProductWithEnteredClassificationExistsValidationHandler(classificationId);
            await _ProductValidationHandler.IsInactiveProductWithEnteredClassificationExistsValidationHandler(classificationId);

            var products = await _ProductRepository.FindInactiveList(mdl => mdl.Classification == classificationId);
            return ConvertToProductListDTO(products);
        }


        public async Task<IList<ProductListDTO>> GetProductByCategory(int categoryId)
        {


            await _ProductValidationHandler.IsProductWithEnteredCategoryExistsValidationHandler(categoryId);
            var products = await _ProductRepository.FindList(mdl => mdl.CategoryId == categoryId);

            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetActiveProductByCategory(int categoryId)
        {

            await _ProductValidationHandler.IsProductWithEnteredCategoryExistsValidationHandler(categoryId);
            await _ProductValidationHandler.IsActiveProductWithEnteredCategoryExistsValidationHandler(categoryId);

            var products = await _ProductRepository.FindActiveList(mdl => mdl.CategoryId == categoryId);

            return ConvertToProductListDTO(products);


        }

        public async Task<IList<ProductListDTO>> GetInactiveProductByCategory(int categoryId)
        {

            await _ProductValidationHandler.IsProductWithEnteredCategoryExistsValidationHandler(categoryId);
            await _ProductValidationHandler.IsInactiveProductWithEnteredCategoryExistsValidationHandler(categoryId);

            var products = await _ProductRepository.FindInactiveList(mdl => mdl.CategoryId == categoryId);

            return ConvertToProductListDTO(products);

        }

        public async Task<IList<ProductListDTO>> GetProductBySearch(int categoryId, int classification)
        {

            await _ProductValidationHandler.IsProductWithEnteredFilterExistsValidationHandler(categoryId, classification);

            var product = await _ProductRepository
                .FindList(mdl => mdl.CategoryId == categoryId & mdl.Classification == classification);
            return ConvertToProductListDTO(product);

        }


        public async Task<IList<ProductListDTO>> GetActiveProductBySearch(int categoryId, int classification)
        {

            await _ProductValidationHandler.IsProductWithEnteredFilterExistsValidationHandler(categoryId, classification);
            await _ProductValidationHandler.IsActiveProductWithEnteredFilterExistsValidationHandler(categoryId, classification);

            var product = await _ProductRepository
                .FindActiveList(mdl => mdl.CategoryId == categoryId & mdl.Classification == classification);
            return ConvertToProductListDTO(product);

        }


        public async Task<IList<ProductListDTO>> GetInactiveProductBySearch(int categoryId, int classification)
        {


            await _ProductValidationHandler.IsProductWithEnteredFilterExistsValidationHandler(categoryId, classification);
            await _ProductValidationHandler.IsInactiveProductWithEnteredFilterExistsValidationHandler(categoryId, classification);

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

            var classificationList = await  GetProductByClassificationBase(ClassificationId); ;
            var ProductLists = classificationList.Union(await GetProductBaseOnClassification(ClassificationId - 1));
            return ProductLists;

        }


        public async Task UpdateUnitStock(ProductUpdateUnitsInStockDTO obj)
        {

 
            await _ProductValidationHandler.IsProductWithEnteredIdExistsValidationHandler(obj.Id);
            var product = await _ProductRepository.GetById(obj.Id);

            await _ProductRepository.Update(product);

            if (obj.State == 1) await IncreaseUnitsInStock(product, obj);
            else if (obj.State == 0) await DeacreaseUnitsInStock(product, obj);


        }



        public async Task IncreaseUnitsInStock(Product product, ProductUpdateUnitsInStockDTO obj)
        {

            product.UnitStock += obj.Quantity;
            await _UnitOfWork.SaveChangesAsync();


        }

        public async Task DeacreaseUnitsInStock(Product product, ProductUpdateUnitsInStockDTO obj)
        {

            _ProductValidationHandler.IsProductHaveSufficientInventoryForAnOrderValidationHandler(product, obj);
            product.UnitStock -= obj.Quantity;
            await _UnitOfWork.SaveChangesAsync();


        }

        public async Task UpdateBaseUnitPrice(ProductUpdateUnitPriceDTO obj)
        {

            await  _ProductValidationHandler.IsProductWithEnteredIdExistsValidationHandler(obj.Id);


            var product = await _ProductRepository.GetById(obj.Id);
            product.BaseUnitPrice = obj.BaseUnitPrice;
            await _UnitOfWork.SaveChangesAsync();

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

        public async Task<ObjectResult> AddImageToProduct(ProductSendImageDto productSendImage)
        {

            _ProductValidationHandler.IsValidProductSendImageInputValue(productSendImage);

                using (_httpClient)
                {
                    var studentJson = JsonConvert.SerializeObject(productSendImage);
                    var requstContent = new StringContent(studentJson, Encoding.UTF8, "application/json");
                    var responseTask = await _httpClient.PostAsync(AppSettingConfiguration.FileWebApiAddress, requstContent);
                return new ObjectResult(null)
                {
                    StatusCode = (int?)responseTask.StatusCode
                };
            }

        }
    }
}
