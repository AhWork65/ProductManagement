using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Repositories.EntitiesRepositories;

namespace ProductManagement.Services.Service.CategoryService.Validation
{
    public class CategoryServiceValidation : ICategoryServiceValidation
    {
        public readonly ICategoryRepository _CategoryRepository;
        public readonly IProductRepository _ProductRepository;

        public CategoryServiceValidation(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _CategoryRepository = categoryRepository;
            _ProductRepository = productRepository;
        }

        public async Task<bool> IsExistCategoryByCode(string code)
        {
            return await _CategoryRepository.Any(c => c.Code == code);
        }

        public async Task<bool> IsExistCategoryById(int id)
        {
            return await _CategoryRepository.Any(e => e.Id == id);
        }

        public async Task<bool> HasAChild(int id)
        {
            return await _CategoryRepository.Any(e => e.ParentId == id);
        }

        public async Task<bool> HasAProduct(int id)
        {
            return await _ProductRepository.Any(e => e.CategoryId == id);
        }

        public async Task<bool> HasAParent(int id)
        {
            
            var entity = await _CategoryRepository.FindById(id);
            return (entity.ParentId != null);
        }
    }

}
