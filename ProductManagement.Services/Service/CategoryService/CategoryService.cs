using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalErrorApp.Exceptions;
using ProductManagement.Domain.Dto.Category;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Models;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.CategoryService;
using ProductManagement.Services.Service.CategoryService.Validation;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly ICategoryServiceValidation _CategoryServiceValidation;

        public CategoryService(ICategoryRepository categoryRepository,
            ICategoryServiceValidation categoryServiceValidation)
        {

            _CategoryRepository = categoryRepository;
            _CategoryServiceValidation = categoryServiceValidation;

        }

        public async Task<Category> Create(CategoryDto entity)
        {
            var category = DtoMapper.MapTo<CategoryDto, Category>(entity);

            if (await _CategoryServiceValidation.IsExistCategoryByCode(category.Code))
                throw new BadRequestException("Code is not Valid");


          return  await _CategoryRepository.Add(category);

        }


        public async Task Update(CategoryDto entity)
        {
            var category = DtoMapper.MapTo<CategoryDto, Category>(entity);

            if (! await _CategoryServiceValidation.IsExistCategoryById(category.Id))
                throw new BadRequestException("category Not Found");

            await _CategoryRepository.Update(category);

        }

        public void Delete(Category entity)
        {
            if (!_CategoryServiceValidation.IsExistCategoryById(entity.Id).Result)
                throw new NotFoundException("category Not Found");

            _CategoryRepository.Delete(entity);

        }



        public async Task Delete(int categoryId)
        {

            if (!await _CategoryServiceValidation.IsExistCategoryById(categoryId))
                throw new NotFoundException("category Not Found");

            if (await _CategoryServiceValidation.HasAChild(categoryId))
                throw new BadRequestException("category Has Child");

            if (await _CategoryServiceValidation.HasAProduct(categoryId))
                throw new BadRequestException("product is connected to the category");

            await _CategoryRepository.DeleteById(categoryId);

        }

        public async Task<Category> GetById(int id)
        {

            return await _CategoryRepository.GetById(id);

        }

        public async Task<IList<Category>> GetAll()
        {

            return await _CategoryRepository.GetAll();

        }

        public async Task<IList<Category>> GetAllActive()
        {
            return await _CategoryRepository.GetActiveList();
        }

        public async Task<IList<Category>> GetAllInactive()
        {

            return await _CategoryRepository.GetInactiveList();

        }


        public async Task<IList<Category>> GetActiveChildCategory(int parrentId)
        {
            return await _CategoryRepository.GetActiveChildCategory(parrentId);
        }

        public async Task<IList<Category>> GetInactiveChildCategory(int parrentId)
        {
            return await _CategoryRepository.GetInactiveChildCategory(parrentId);
        }
    }

}
