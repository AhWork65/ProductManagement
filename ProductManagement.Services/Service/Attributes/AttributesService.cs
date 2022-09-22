
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

        public IQueryable<Attribute> GetAll()
        {
           return _attributesRepository.GetAll();
        }


        private int Add(Attribute entity)
        {
             _attributesRepository.Add(entity);
             return entity.Id;
        }
    }
}
