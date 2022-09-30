using GlobalErrorApp.Exceptions;
using ProductManagement.Domain.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Services.Service.CategoryService.Validation;
using ProductManagement.Services.Service.Product.Validation;

namespace ProductManagement.Services.Service.Product.ValidationHanlder
{
    public class ProductValidationHandler : IProductValidationHandler
    {

        private readonly IProductValidationService _ProductValidationService;
        private readonly ICategoryServiceValidation _CategoryValidationService;

        public ProductValidationHandler
            (
                IProductValidationService productValidationService ,
                ICategoryServiceValidation categoryValidationService
                )
        {
            
            _ProductValidationService = productValidationService;
            _CategoryValidationService = categoryValidationService;

        }
        public async Task IsCategoryWithEnteredIdExistsValidationHandler(int categoryId)
        {

            if (!await _CategoryValidationService.IsExistCategoryById(categoryId))
                throw new BadRequestException("Invalid Category");

        }


        public async Task IsProductWithEnteredIdExistsValidationHandler(int id)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredIdExists(id))
                throw new BadRequestException("Invalid Id");

        }

        public async Task IsProductWithEnteredCodeExistsValidationHandler(string code)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredCodeExists(code))
                throw new BadRequestException("Invalid Code");

        }

        public async Task IsEnteredCodeIsUniqueValidationHandler(string code)
        {
            if (await _ProductValidationService.IsRecordWithEnteredCodeExists(code))
                throw new BadRequestException("Invalid Code");

        }


        public async Task IsProductWithEnteredClassificationExistsValidationHandler(int classification)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredClassificationExists(classification))
                throw new BadRequestException("Invalid classification");

        }

        public async Task IsActiveProductWithEnteredClassificationExistsValidationHandler(int classification)
        {

            if (!await _ProductValidationService.IsActiveRecordWithEnteredClassificationExists(classification))
                throw new BadRequestException("Product Not Exists");

        }


        public async Task IsInactiveProductWithEnteredClassificationExistsValidationHandler(int classification)
        {

            if (!await _ProductValidationService.IsInactiveRecordWithEnteredClassificationExists(classification))
                throw new BadRequestException("Product Not Exists");

        }

        public void IsProductHaveSufficientInventoryForAnOrderValidationHandler(ProductManagementWebApi.Models.Product product, ProductUpdateUnitsInStockDTO obj)
        {

            if (!_ProductValidationService.IsSufficientInventory(product, obj))
                throw new BadRequestException("Not Enough Stocks in Inventory");

        }

        public async Task IsProductWithEnteredCategoryExistsValidationHandler(int categoryId)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredCategoryExists(categoryId))
                throw new BadRequestException("Invalid Category Id ");

        }

        public async Task IsActiveProductWithEnteredCategoryExistsValidationHandler(int categoryId)
        {

            if (!await _ProductValidationService.IsActiveRecordWithEnteredCategoryExists(categoryId))
                throw new BadRequestException("Product Not Exists");

        }

        public async Task IsInactiveProductWithEnteredCategoryExistsValidationHandler(int categoryId)
        {

            if (!await _ProductValidationService.IsInactiveRecordWithEnteredCategoryExists(categoryId))
                throw new BadRequestException("Product Not Exists");

        }

        public async Task IsProductWithEnteredFilterExistsValidationHandler(int categoryId, int classification)
        {

            if (!await _ProductValidationService.IsRecordWithEnteredFilterExists(categoryId, classification))
                throw new BadRequestException(" Invalid Filter ");

        }

        public async Task IsActiveProductWithEnteredFilterExistsValidationHandler(int categoryId, int classification)
        {

            if (!await _ProductValidationService.IsActiveRecordWithEnteredFilterExists(categoryId, classification))
                throw new BadRequestException("Product Not Exists");

        }

        public async Task IsInactiveProductWithEnteredFilterExistsValidationHandler(int categoryId, int classification)
        {

            if (!await _ProductValidationService.IsInactiveRecordWithEnteredFilterExists(categoryId, classification))
                throw new BadRequestException("Product Not Exists ");

        }
    }
}
