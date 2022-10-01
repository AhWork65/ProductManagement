using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Service.CategoryService.ValidationHanlder
{
    public interface ICategoryValidationHanlder
    {
        Task IsExistsCategoryWithCodeValidationHandler(string  code);
        Task NotExistsCategoryWithIdValidationHandler(int id);
        Task CategoryHasAChildValidationHandler(int id);
        Task CategoryHasAProductValidationHandler(int id);

    }
}
