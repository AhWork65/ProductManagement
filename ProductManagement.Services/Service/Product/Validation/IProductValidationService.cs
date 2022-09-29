using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Dto.Product;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Service.Product.Validation
{
    public interface IProductValidationService
    {

        
        Task<bool> IsRecordWithEnteredIdExists(int id);
        Task<bool> IsRecordWithEnteredCodeExists(string code);
        Task<bool> IsRecordWithEnteredClassificationExists(int classificationId);
        Task<bool> IsActiveRecordWithEnteredClassificationExists(int classificationId);
        Task<bool> IsInactiveRecordWithEnteredClassificationExists(int classificationId);
        Task<bool> IsRecordWithEnteredCategoryExists(int categoryId);
        Task<bool> IsActiveRecordWithEnteredCategoryExists(int categoryId);
        Task<bool> IsInactiveRecordWithEnteredCategoryExists(int categoryId);
        Task<bool> IsRecordWithEnteredFilterExists(int categoryId , int classification);
        Task<bool> IsActiveRecordWithEnteredFilterExists(int categoryId , int classification);
        Task<bool> IsInactiveRecordWithEnteredFilterExists(int categoryId , int classification);

        bool IsSufficientInventory(ProductManagementWebApi.Models.Product product, ProductUpdateUnitsInStockDTO productDto);


    }
}
