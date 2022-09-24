using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Service.CategoryService.Validation
{
    public interface ICategoryServiceValidation
    {
        Task<bool> IsExistCategoryByCode(string code);
        Task<bool> IsExistCategoryById(int id);
        Task<bool> HasAChild(int id);
        Task<bool> HasAProduct(int id);
        Task<bool> HasAParent(int id);
        
    }
}
