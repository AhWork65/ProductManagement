using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Dto.RelatedProducts;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagementWebApi.Models;
using GlobalErrorApp.Exceptions;
using ProductManagement.Services.Service.RelatedProductsServices.RelatedProductsValidationService;

namespace ProductManagement.Services.Service.RelatedProductsServices
{
    public class RelatedProductService : IRelatedProductsService
    {

        private readonly IRelatedProductRepository _RelatedProductRepository;
        private readonly IRelatedProductValidationService _RelatedProductValidationService; 
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IProductValidationService _ProductValidationService;
        private readonly HttpClient _httpClient; 

        public RelatedProductService
            (
                IRelatedProductRepository relatedProductRepository ,
                IUnitOfWork unitOfWork  ,
                IProductValidationService productIProductValidationService ,
                IRelatedProductValidationService relatedProductValidationService

                )
        {
            _ProductValidationService = productIProductValidationService; 
            _RelatedProductRepository = relatedProductRepository;
            _RelatedProductValidationService = relatedProductValidationService; 
            _UnitOfWork = unitOfWork;
            _httpClient = new HttpClient(); 

        }


        public RelatedProduct ConvertToRelatedProduct(RelatedProductsCreationDTO relatedProductsCreationDto)
        {

            return DtoMapper.MapTo<RelatedProductsCreationDTO, RelatedProduct>(relatedProductsCreationDto); 

        }


        public async Task Add(RelatedProductsCreationDTO entity)
        {

            await IsProductWithEnteredIdExists(entity.BaseProductId);
            await IsProductWithEnteredIdExists(entity.RelatedProductId);
            IsBaseProductAndRelatedProductDifferent(entity.BaseProductId , entity.RelatedProductId);

            var relatedProduct = ConvertToRelatedProduct(entity);
            await _RelatedProductRepository.Add(relatedProduct);

        }


        public async Task Remove(int relatedProductsID)
        {

            await IsRelatedProductWithEnteredIdExists(relatedProductsID); 
            await _RelatedProductRepository.Delete(relatedProductsID);

        }


        public async Task<RelatedProduct> GetById(int relatedProductId)
        {

            return await _RelatedProductRepository.GetById(relatedProductId);

        }


        public async Task<IList<RelatedProduct>> GetByBaseProductId(int BaseProductId)
        {

            return await _RelatedProductRepository.GetListOfProductsByBaseProductId(BaseProductId);

        }


        public async Task<IList<int>> GetItemRelatedProductsIdByBaseProductId(int baseProductId)
        {

            await IsProductWithEnteredIdExists(baseProductId);
            await IsRelatedProductWithEnteredBaseProductIdExists(baseProductId);

            return await  _RelatedProductRepository.GetListOfProductsIdByBaseProductId(baseProductId); 



        }

        

        // -----------------------------------------------------------------------------------


        public async Task IsProductWithEnteredIdExists(int productId)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredIdExists(productId))
                throw new BadRequestException(" RelatedProduct Not Exists"); 

        }

        public async Task IsRelatedProductWithEnteredIdExists(int id)
        {

            if (!await _RelatedProductValidationService.IsRecordWithEnteredIdExists(id))
                throw new BadRequestException(" Product Not Exists");

        }
        public void IsBaseProductAndRelatedProductDifferent(int baseProductId, int relatedProductId)
        {
            if (!_RelatedProductValidationService.IsBaseProductAndRelatedProductAreDifferent(baseProductId,
                    relatedProductId))
                throw new BadRequestException("Base product and Related Product are same items ");

        }

        public async Task IsRelatedProductWithEnteredBaseProductIdExists(int baseProductId)
        {

            if (!await _RelatedProductValidationService.IsRecordWithEnteredBaseProductIdExists(baseProductId))
                throw new BadRequestException("relatedProduct not exists"); 

        }
    }
}
