using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Repositories.EntitiesRepositories;
using ProductManagement.Services.Service.Services;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Services.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _CategoryRepository;
        public readonly IProductRepository _ProductRepository;

        public CategoryService
        (
            ICategoryRepository categoryRepository,
            IProductRepository productRepository

        )
        {

            _CategoryRepository = categoryRepository;
            _ProductRepository = productRepository;

        }

        public async Task Create(Category entity)
        {

            await _CategoryRepository.Add(entity);

        }


        public async Task Update(Category entity)
        {
            await _CategoryRepository.Update(entity);
            // await new NotImplementedException();

        }

        public void Delete(Category entity)
        {

            _CategoryRepository.Delete(entity);

        }

        public async Task Delete(int categoryId)
        {

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

        public async Task<bool> HasAChild(int categoryId)
        {
            return await _CategoryRepository
                .Any(mdl => mdl.ParentId == categoryId);
        }

        public async Task<bool> HasAProduct(int categoryId)
        {
            return await _ProductRepository
                .Any(mdl => mdl.CategoryId == categoryId);

        }

        public async Task<bool> HasAParent(int id)
        {
            var entity = await _CategoryRepository.FindById(id);
            return (entity.ParentId != null);
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
