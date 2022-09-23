
using Microsoft.EntityFrameworkCore.Infrastructure;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagementWebApi.Models;
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

        public async Task<AttributeDto> updateAttrbiute(AttributeDto valueDto, int id)
        {
            await _attributesRepository.updateAttrbiute(valueDto, id);

            return valueDto;
        }


        public int AddDto(AttributeDto entitiydto)
        {
            var entity = new Attribute()
            {
                Name = entitiydto.Name,
                //Value = entitiydto.Value,
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

        public Attribute GetNodeAttribute(AttributeDto valueDto)
        {
            return _attributesRepository.GetNodeAttribute(valueDto);
        }

        public async Task<IList<Attribute>> GetAll(string title)
        {


            return await _attributesRepository.GetAll(title);


        }
        //public Task<IEnumerable<AttributeDto>> GetCollectionNodes(string Title)
        //{
        //    return _attributesRepository.GetCollectionNodes(Title);
        //}
    }
}