using GlobalErrorApp.Exceptions;
using ProductManagement.Domain.Dto.Category;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Models;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.CategoryService;
using ProductManagement.Services.Service.CategoryService.Validation;
using ProductManagement.Services.Service.CategoryService.ValidationHanlder;

namespace ProductManagement.Services.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly ICategoryValidationHanlder _CategoryValidationHanlder;

        public CategoryService(ICategoryRepository categoryRepository,
            ICategoryServiceValidation categoryServiceValidation,
            ICategoryValidationHanlder categoryValidationHanlder)
        {

            _CategoryRepository = categoryRepository;
            _CategoryValidationHanlder = categoryValidationHanlder;
        }

        public async Task<Category> Create(CategoryDto entity)
        {
            var category = DtoMapper.MapTo<CategoryDto, Category>(entity);
            await _CategoryValidationHanlder.IsExistsCategoryWithCodeValidationHandler(category.Code);
            return await _CategoryRepository.Add(category);
        }


        public async Task Update(CategoryDto entity)
        {
            var category = DtoMapper.MapTo<CategoryDto, Category>(entity);
            await _CategoryValidationHanlder.NotExistsCategoryWithIdValidationHandler(category.Id);
            await _CategoryRepository.Update(category);

        }

        public void Delete(Category entity)
        {
            _CategoryValidationHanlder.NotExistsCategoryWithIdValidationHandler(entity.Id);
            _CategoryRepository.Delete(entity);

        }



        public async Task Delete(int categoryId)
        {

            await _CategoryValidationHanlder.NotExistsCategoryWithIdValidationHandler(categoryId);
            await _CategoryValidationHanlder.CategoryHasAChildValidationHandler(categoryId);
            await _CategoryValidationHanlder.CategoryHasAProductValidationHandler(categoryId);
            await _CategoryRepository.DeleteById(categoryId);

        }

        public async Task<CategoryDto> GetById(int id)
        {
            return DtoMapper.MapTo<Category, CategoryDto>(await _CategoryRepository.GetById(id)); 
        }

        public async Task<IList<CategoryDto>> GetAll()
        {
            return DtoMapper.ListMapTo<Category, CategoryDto>(await _CategoryRepository.GetAll());

        }

        public async Task<IList<CategoryDto>> GetAllActive()
        {
            return DtoMapper.ListMapTo<Category, CategoryDto>(await _CategoryRepository.GetActiveList());
        }

        public async Task<IList<CategoryDto>> GetAllInactive()
        {
            return DtoMapper.ListMapTo<Category, CategoryDto>(await _CategoryRepository.GetInactiveList());

        }


        public async Task<IList<CategoryDto>> GetActiveChildCategory(int parrentId)
        {
            return DtoMapper.ListMapTo<Category, CategoryDto>(await _CategoryRepository.GetActiveChildCategory(parrentId));
        }

        public async Task<IList<CategoryDto>> GetInactiveChildCategory(int parrentId)
        {
            return DtoMapper.ListMapTo<Category, CategoryDto>(await _CategoryRepository.GetInactiveChildCategory(parrentId));
        }
    }

}
