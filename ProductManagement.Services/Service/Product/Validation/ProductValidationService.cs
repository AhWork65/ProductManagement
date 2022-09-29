using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.DataAccess.Repositories;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Domain.Dto.Product;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Service.Product.Validation
{
    public class ProductValidationService : IProductValidationService
    {

        private readonly IProductRepository _ProductRepository;



        public ProductValidationService
            (
            IProductRepository productRepository
            )
        {
            _ProductRepository = productRepository;

        }


        public async Task<bool> IsRecordWithEnteredIdExists(int id)
        {

            return await _ProductRepository.Any(mdl => mdl.Id == id);

        }

        public async Task<bool> IsRecordWithEnteredCodeExists(string code)
        {

            return await _ProductRepository.Any(mdl => mdl.Code == code);

        }


        public async Task<bool> IsRecordWithEnteredClassificationExists(int classificationId)
        {

            return await _ProductRepository.Any(mdl => mdl.Classification == classificationId);

        }


        public async Task<bool> IsActiveRecordWithEnteredClassificationExists(int classificationId)
        {

            return await _ProductRepository
                .Any(mdl => mdl.Classification == classificationId & mdl.IsActive == true);

        }


        public async Task<bool> IsInactiveRecordWithEnteredClassificationExists(int classificationId)
        {

            return await _ProductRepository
                .Any(mdl => mdl.Classification == classificationId & mdl.IsActive == false);

        }


        public async Task<bool> IsRecordWithEnteredCategoryExists(int categoryId)
        {

            return await _ProductRepository.Any(mdl => mdl.CategoryId == categoryId);

        }


        public async Task<bool> IsActiveRecordWithEnteredCategoryExists(int categoryId)
        {

            return await _ProductRepository
                .Any(mdl => mdl.CategoryId == categoryId & mdl.IsActive == true);

        }


        public async Task<bool> IsInactiveRecordWithEnteredCategoryExists(int categoryId)
        {
            return await _ProductRepository
                .Any(mdl => mdl.CategoryId == categoryId & mdl.IsActive == true);

        }


        public async Task<bool> IsRecordWithEnteredFilterExists(int categoryId, int classification)
        {

            return await _ProductRepository.Any(mdl => mdl.CategoryId == categoryId & mdl.Classification == classification);

        }

        public async Task<bool> IsActiveRecordWithEnteredFilterExists(int categoryId, int classification)
        {

            return await _ProductRepository
                .Any(mdl => mdl.CategoryId == categoryId & mdl.Classification == classification & mdl.IsActive == true);

        }


        public async Task<bool> IsInactiveRecordWithEnteredFilterExists(int categoryId, int classification)
        {
            return await  _ProductRepository
                .Any(mdl => mdl.CategoryId == categoryId & mdl.Classification == classification & mdl.IsActive == false);
        }


        public Task<bool> IsRecordWithEnteredAttributeExists(int attributeId)
        {
            throw new NotImplementedException();
        }



        public bool IsSufficientInventory
            (ProductManagementWebApi.Models.Product product, ProductUpdateUnitsInStockDTO productDto)
        {

            if (product.UnitStock < productDto.Quantity)
                return false;
            return true;

        }
    }
}
