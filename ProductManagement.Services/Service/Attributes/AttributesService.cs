
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Services.Dto.Attribute;
using Attribute = ProductManagementWebApi.Models.Attribute;
namespace ProductManagement.Services.Service.Attributes
{
    public class AttributesService : IAttributesService
    {
        public readonly IAttributesRepository _attributesRepository;

        public AttributesService(IAttributesRepository attributesRepository)
        {
            _attributesRepository = attributesRepository;
        }

        public Task<Attribute> GetById(int id)
        {
            return _attributesRepository.GetById(id); 
        }

        public async Task<Attribute> updateAttrbiute(Attribute attribute)
        {
            await _attributesRepository.Update(attribute);
          
            return attribute;
        }

        public int AddDto(AttributeDto entitiydto)
        {
            var entity = new Attribute()
            {
                Name = entitiydto.Name,
                Value = entitiydto.Value,
                ParentId = entitiydto.ParentId
            };
            return Add(entity);
        }

        public async Task<IList<Attribute>> GetAttributeList()
        {
            return await _attributesRepository.GetAttributeList();
        }


        private int Add(Attribute entity)
        {
             _attributesRepository.Add(entity);
             return entity.Id;
        }

        public async Task<IList<Attribute>> GetAll()
        {
            return await _attributesRepository.GetAll();
        }

        public async Task<IList<Attribute>> GetAttributeDetailByParentId(int id)
        {
            return await _attributesRepository.GetAttributeDetailByParentId(id);
        }
    }
}
