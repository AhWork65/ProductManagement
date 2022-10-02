using GlobalErrorApp.Exceptions;
using ProductManagement.Domain.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Service.Product.ValidationHanlder
{
    public interface IProductValidationHandler
    {

        Task IsCategoryWithEnteredIdExistsValidationHandler(int categoryId);
        Task IsProductWithEnteredIdExistsValidationHandler(int id);
        Task IsProductWithEnteredCodeExistsValidationHandler(string code);
        Task IsEnteredCodeIsUniqueValidationHandler(string code);
        Task IsProductWithEnteredClassificationExistsValidationHandler(int classification);
        Task IsActiveProductWithEnteredClassificationExistsValidationHandler(int classification);
        Task IsInactiveProductWithEnteredClassificationExistsValidationHandler(int classification);
        void IsProductHaveSufficientInventoryForAnOrderValidationHandler(ProductManagementWebApi.Models.Product product, ProductUpdateUnitsInStockDTO obj);
        Task IsProductWithEnteredCategoryExistsValidationHandler(int categoryId);
        Task IsActiveProductWithEnteredCategoryExistsValidationHandler(int categoryId);
        Task IsInactiveProductWithEnteredCategoryExistsValidationHandler(int categoryId);
        Task IsProductWithEnteredFilterExistsValidationHandler(int categoryId, int classification);
        Task IsActiveProductWithEnteredFilterExistsValidationHandler(int categoryId, int classification);
        Task IsInactiveProductWithEnteredFilterExistsValidationHandler(int categoryId, int classification);
        Task IsValidProductSendImageInputValue(ProductSendImageDto productSendImageDto);

    }
    
}
