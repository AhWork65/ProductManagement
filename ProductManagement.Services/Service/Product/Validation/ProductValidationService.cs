﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.DataAccess.Repositories;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Services.Dto.Product;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Service.Product.Validation
{
    public class ProductValidationService : IProductValidationService
    {

        private readonly IProductRepository _ProductRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IAttributesRepository _AttributeRepository; 


        public ProductValidationService
            (
            IProductRepository productRepository ,
            ICategoryRepository categoryRepository  , 
            IAttributesRepository attributeRepository
            )
        {

            _ProductRepository = productRepository;
            _CategoryRepository = categoryRepository;
            _AttributeRepository = attributeRepository;

        }
        public  bool IsIdExists(int ProductId)
        {

            return
                ProductId != null && ProductId > 0;

        }

        public bool IsCodeExists(string productCode)
        {

            productCode = productCode.Trim(); 
            return
                productCode != null && productCode != ""; 

        }

        public bool IsClassificationExists(int classificationId)
        {

            return (classificationId != null) && (classificationId >= 0 && classificationId < 4);
            
        }

        public async Task<bool> IsCategoryExists(int categoryId)
        {

            return await  _CategoryRepository.Any(mdl => mdl.Id == categoryId); 

        }

        public Task<bool> IsCategoryExists(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAttributeExists(int attributeId)
        {

            return await _AttributeRepository.Any(mdl => mdl.Id == attributeId); 

        }

        public Task<bool> IsAttributeExists(ProductAttributeDetail attributeId)
        {
            throw new NotImplementedException();
        }

        public bool IsRecordExists(ProductManagementWebApi.Models.Product product)
        {

            return product != null; 

        }

        public bool IsRecordExists(IList<ProductManagementWebApi.Models.Product> products)
        {

            return products.Count() != 0;

        }

        public async Task<bool> IsRecordWithEnteredIdExists(int id)
        {

            return await  _ProductRepository.Any(mdl => mdl.Id == id); 

        }

        public async Task<bool> IsRecordWithEnteredCodeExists(string code)
        {

            return await _ProductRepository.Any(mdl => mdl.Code == code); 

        }

        public async Task<bool> IsRecordWithEnteredClassificationExists(int classificationId)
        {

            return await _ProductRepository.Any(mdl => mdl.Classification == classificationId); 

        }

        public Task<bool> IsRecordWithEnteredCategoryExists(int categoryId)
        {

            return _ProductRepository.Any(mdl => mdl.CategoryId == categoryId); 

        }

        public Task<bool> IsRecordWithEnteredCategoryExists(Category categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsRecordWithEnteredAttributeExists(int attributeId)
        {
            throw new NotImplementedException();
        }

      

        public bool IsModelValid(ProductManagementWebApi.Models.Product product)
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