using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalErrorApp.Exceptions;
using ProductManagement.Services.Service.Attributes.Validation;

namespace ProductManagement.Services.Service.Attributes.ValidationHandler
{
    public class AttributeValidationHandler:IAttributeValidationHandler
    {
        private  readonly IAttributeValidationService _attributeValidationService;

        public AttributeValidationHandler(IAttributeValidationService attributeValidationService)
        {
            _attributeValidationService = attributeValidationService;
        }

   

        public async Task IsExistAttributeByNameWithValidationHandler(string Name,string value)
        {
           if(_attributeValidationService.IsExistAttributeByName(Name,value))
                  throw new BadRequestException("The value entered is Repeat");
        }

        public async Task IsExistAttributeByProductIdWithValidationHandler(int id)
        {
            if (!await _attributeValidationService.IsExistAttributeByProductId(id))
                throw new BadRequestException("Not Found Details attribute product by Id");
        }

        public async Task IsExistAttributeNodeByIdWithValidationHandler(int id)
        {
            if (!await _attributeValidationService.IsExistAttributeNodeById(id))
                throw new BadRequestException("The value Node entered is not Exist");
        }

        public async Task IsExistAttributeByIdWithValidationHandler(int id)
        {
            if (!await _attributeValidationService.IsExistAttributeById(id))
                throw new BadRequestException("The value ParentNode entered is not Exist");
        }




    }
}
