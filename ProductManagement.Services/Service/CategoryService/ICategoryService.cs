using System.ComponentModel;
using ProductManagement.Domain.Dto.Category;
using ProductManagement.Domain.Models;
using ProductManagementWebApi.Models;


namespace ProductManagement.Services.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Category> Create(CategoryDto entity);
        Task Update(CategoryDto entity);
        void Delete(Category entity);
        Task Delete(int categoryId);
        Task<Category> GetById(int id);
        Task<IList<Category>> GetAll();
        Task<IList<Category>> GetAllActive();
        Task<IList<Category>> GetAllInactive();
        Task<IList<Category>> GetActiveChildCategory(int parrentId);
        Task<IList<Category>> GetInactiveChildCategory(int parrentId);


    }
}
