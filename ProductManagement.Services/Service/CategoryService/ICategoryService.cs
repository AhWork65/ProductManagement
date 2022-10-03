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
        Task<CategoryDto> GetById(int id);
        Task<IList<CategoryDto>> GetAll();
        Task<IList<CategoryDto>> GetAllActive();
        Task<IList<CategoryDto>> GetAllInactive();
        Task<IList<CategoryDto>> GetActiveChildCategory(int parrentId);
        Task<IList<CategoryDto>> GetInactiveChildCategory(int parrentId);


    }
}
