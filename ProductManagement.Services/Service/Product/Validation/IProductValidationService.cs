﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Services.Dto.Product;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Service.Product.Validation
{
    public interface IProductValidationService
    {

        bool IsIdExists(int ProductId);
        bool IsCodeExists(string ProductCode);
        bool IsClassificationExists(int classificationId);
        Task<bool> IsCategoryExists(int categoryId); // To be deleted 
        Task<bool> IsCategoryExists(Category category); // To be deleted  
        Task<bool> IsAttributeExists(int attributeId); // To be deleted 
        Task<bool> IsAttributeExists(ProductAttributeDetail attributeId); // To be deleted 


        bool IsRecordExists(ProductManagementWebApi.Models.Product product);
        bool IsRecordExists(IList<ProductManagementWebApi.Models.Product> products);

        Task<bool> IsRecordWithEnteredIdExists(int id);
        Task<bool> IsRecordWithEnteredCodeExists(string code);
        Task<bool> IsRecordWithEnteredClassificationExists(int classificationId);
        Task<bool> IsRecordWithEnteredCategoryExists(int categoryId);
        Task<bool> IsRecordWithEnteredCategoryExists(Category categoryId);
        


        bool IsModelValid(ProductManagementWebApi.Models.Product product);
        bool IsSufficientInventory(ProductManagementWebApi.Models.Product product, ProductUpdateUnitsInStockDTO productDto);


    }
}
