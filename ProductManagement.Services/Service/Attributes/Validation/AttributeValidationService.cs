using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;

namespace ProductManagement.Services.Service.Attributes.Validation
{
    public class AttributeValidationService:IAttributeValidationService
    {
        public readonly IAttributesRepository _attributesRepository;

        public AttributeValidationService(IAttributesRepository attributesRepository)
        {
            _attributesRepository = attributesRepository;

        }

        public async Task<bool> IsExistAttributeById(int id)
        {
            return await _attributesRepository.Any(a => a.ParentId == id);
        }

     

        public async Task<bool> IsExistAttributeNodeById(int id)
        {
            return await _attributesRepository.Any(a => a.Id == id);
        }

        public bool IsExistAttributeByName(string name,string value)
        {
            return  _attributesRepository.IsExistParent(name,value);
        }

        public async Task<bool> IsExistAttributeByProductId(int id)
        {
            return await _attributesRepository.Any(e => e.ProductAttributeDetails.Any(e => e.ProductId == id));
        }
    }
}
