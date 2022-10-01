using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Service.Attributes.ValidationHandler
{
  public interface IAttributeValidationHandler
  {

      Task IsExistAttributeNodeByIdWithValidationHandler(int id);
      Task IsExistAttributeByNameWithValidationHandler(string Name,string value);

      Task IsExistAttributeByIdWithValidationHandler(int id);

      Task IsExistAttributeByProductIdWithValidationHandler(int id);
  }
}
