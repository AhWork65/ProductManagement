using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Services.Service.CategoryService;
using ProductManagement.Services.Service.CategoryService.Validation;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly ICategoryServiceValidation _CategoryServiceValidation;

        public CategoryService
        (
            ICategoryRepository categoryRepository,
            ICategoryServiceValidation categoryServiceValidation

        )
        {

            _CategoryRepository = categoryRepository;
            _CategoryServiceValidation = categoryServiceValidation
                ;

        }

        public async Task<Category> Create(Category entity)
        {
            if (await _CategoryServiceValidation.IsExistCategoryByCode(entity.Code))
                throw new Exception("Code is not Valid");


          return  await _CategoryRepository.Add(entity);

        }


        public async Task Update(Category entity)
        {

            if (! await _CategoryServiceValidation.IsExistCategoryById(entity.Id))
                throw new Exception("category Not Found");

            await _CategoryRepository.Update(entity);

        }

        public void Delete(Category entity)
        {
            if (!_CategoryServiceValidation.IsExistCategoryById(entity.Id).Result)
                throw new Exception("category Not Found");

            _CategoryRepository.Delete(entity);

        }



        public async Task Delete(int categoryId)
        {

            if (!await _CategoryServiceValidation.IsExistCategoryById(categoryId))
                throw new EntryPointNotFoundException("category Not Found");

            if (await _CategoryServiceValidation.HasAChild(categoryId))
                throw new Exception("category Has Child");

            if (await _CategoryServiceValidation.HasAProduct(categoryId))
                throw new Exception("product is connected to the category");

            await _CategoryRepository.DeleteById(categoryId);

        }

        public async Task<Category> GetById(int id)
        {

            return await _CategoryRepository.GetById(id);

        }

        public async Task<IEnumerable<Category>> GetAll()
        {

            return await _CategoryRepository.GetAll();

        }

        public async Task<IEnumerable<Category>> GetAllActive()
        {
            return await _CategoryRepository.GetActiveList();
        }

        public async Task<IEnumerable<Category>> GetAllInactive()
        {

            return await _CategoryRepository.GetInactiveList();

        }


        public async Task<IEnumerable<Category>> GetActiveChildCategory(int parrentId)
        {
            return await _CategoryRepository.GetActiveChildCategory(parrentId);
        }

        public async Task<IEnumerable<Category>> GetInactiveChildCategory(int parrentId)
        {
            return await _CategoryRepository.GetInactiveChildCategory(parrentId);
        }
    }

}
