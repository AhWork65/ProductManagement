using System.ComponentModel;
using ProductManagement.Domain.Models;
using ProductManagementWebApi.Models;


namespace ProductManagement.Services.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Category> Create(Category entity);
        Task Update(Category entity);
        void Delete(Category entity);
        Task Delete(int categoryId);
        Task<Category> GetById(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetAllActive();
        Task<IEnumerable<Category>> GetAllInactive();
        Task<IEnumerable<Category>> GetActiveChildCategory(int parrentId);
        Task<IEnumerable<Category>> GetInactiveChildCategory(int parrentId);


    }
}
