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

        public Task<bool> IsExistAttributeById(int id)
        {
            return _attributesRepository.Any(a => a.ParentId == id);
        }

        public Task<bool> IsExistAttributeNodeById(int id)
        {
            return _attributesRepository.Any(a => a.Id == id);
        }
    }
}
