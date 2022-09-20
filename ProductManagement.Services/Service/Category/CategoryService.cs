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

        public Task Update(Category entity)
        {

            throw new NotImplementedException();

        }

        public  void Delete(Category entity)
        {
            
              _CategoryRepository.Delete(entity);

        }

        public async  Task Delete(int categoryId)
        {
           
           await _CategoryRepository.DeleteById(categoryId);

        }

        public async  Task<Category> GetById(int id)
        {

            return await _CategoryRepository.GetById(id); 

        }

        public async Task<IEnumerable<Category>> GetAll()
        {

          return await  _CategoryRepository.GetAll(); 

        }

        public async  Task<IEnumerable<Category>> GetAllActive()
        {
            return await _CategoryRepository.GetActiveList(); 
        }

        public async Task<IEnumerable<Category>> GetAllInactive()
        {

            return await _CategoryRepository.GetInactiveList(); 

        }

        public async  Task<bool> HasAChild(int categoryId)
        {
            var objs =  await _CategoryRepository
                .FindList(mdl => mdl.ParentId == categoryId);
            if (objs == null || objs.Count == 0  )      
                return false;
            return true; 
        }

        public async  Task<bool> HasAProduct(int categoryId)
        {
            var objs = await  _ProductRepository
                .FindList(mdl => mdl.CategoryId == categoryId);
            if (objs == null || objs.Count == 0)
                return false;
            return true; 
        }
    }
}
