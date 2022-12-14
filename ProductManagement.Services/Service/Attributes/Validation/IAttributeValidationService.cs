using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Service.Attributes.Validation
{
   public interface IAttributeValidationService
    {
        Task<bool> IsExistAttributeById(int id);
        Task<bool> IsExistAttributeNodeById(int id);
        bool IsExistAttributeByName(string name,string value);
        Task<bool> IsExistAttributeByProductId(int id);
    }
}
