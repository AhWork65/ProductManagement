using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalErrorApp.Exceptions;
using ProductManagement.Services.Service.CategoryService.Validation;
using NotImplementedException = System.NotImplementedException;

namespace ProductManagement.Services.Service.CategoryService.ValidationHanlder
{
    public class CategoryValidationHanlder: ICategoryValidationHanlder
    {
        private readonly ICategoryServiceValidation _CategoryServiceValidation;

        public CategoryValidationHanlder(ICategoryServiceValidation categoryServiceValidation)
        {
            _CategoryServiceValidation = categoryServiceValidation;
        }

        public async Task IsExistsCategoryWithCodeValidationHandler(string code)
        {
            if (await _CategoryServiceValidation.IsExistCategoryByCode(code))
                throw new BadRequestException("Code is not Valid");
        }

        public async Task NotExistsCategoryWithIdValidationHandler(int id)
        {
            if (!await _CategoryServiceValidation.IsExistCategoryById(id))
                throw new BadRequestException("category Not Found");
        }

        public async Task CategoryHasAChildValidationHandler(int id)
        {
            if (await _CategoryServiceValidation.HasAChild(id))
                throw new BadRequestException("category Has Child");
        }

        public async Task CategoryHasAProductValidationHandler(int id)
        {
            if (await _CategoryServiceValidation.HasAProduct(id))
                throw new BadRequestException("product is connected to the category");
        }
    }
}
