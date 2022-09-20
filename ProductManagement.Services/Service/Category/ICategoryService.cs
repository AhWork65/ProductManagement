using System.ComponentModel;
using ProductManagementWebApi.Models;


namespace ProductManagement.Services.Service.Services
{
    public interface ICategoryService
    {
        public Task Create(Category entity);
        public Task Update(Category entity);
        public void Delete(Category entity);
        public Task Delete(int categoryId);
        public Task<Category> GetById(int id);
        public Task<IEnumerable<Category>> GetAll();
        public Task<IEnumerable<Category>> GetAllActive();
        public Task<IEnumerable<Category>> GetAllInactive();
        public Task<bool> HasAChild(int categoryId);
        public Task<bool> HasAProduct(int categoryId);

    }
}
