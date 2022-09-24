using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Services.Dto.Attribute;
using ProductManagementWebApi.Models;
using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Services.Service.Attributes
{
    public class AttributesService : IAttributesService
    {
        public readonly IAttributesRepository _attributesRepository;
        private readonly IMapper _mapper;

        public AttributesService(IAttributesRepository attributesRepository)
        {
            _attributesRepository = attributesRepository;
           
        }

        


        public int AddDto(AttributeDto value)
        {
            var entity = new Attribute
            {
                ParentId = value.ParentId,
                Name = value.Name,
             
            };

            return Add1(entity);
        }
        private int Add1(Attribute entity)
        {
            _attributesRepository.Add(entity);
            return entity.Id;
        }


        public async Task<IQueryable<Attribute>> GetAttributeList()
        {
            return await _attributesRepository.GetAttributeList();
        }


    
        public async Task<Attribute> AddAttribute(Attribute entity)
        {
          return  await _attributesRepository.Add(entity);
          
        }

        public async Task<IList<Attribute>> GetAll()
        {
            return await _attributesRepository.GetAll();
        }

        public async Task<IList<Attribute>> GetAttributeDetailByParentId(int id)
        {
            return await _attributesRepository.GetAttributeDetailByParentId(id);
        }

        public AttributeDto GetNodeAttributeDto(Attribute value)
        {
            var valuedto = _attributesRepository.GetNodeAttribute(value);
            return  _mapper.Map<Attribute, AttributeDto>(valuedto);
        }

        public Attribute GetNodeAttribute(Attribute value)
        {
            return _attributesRepository.GetNodeAttribute(value);
        }

        public async Task<IList<Attribute>> GetAll(string title)
        {


            return await _attributesRepository.GetAll(title);


        }

        public async Task DeleteByIdAsync(int id)
        {
            await _attributesRepository.DeleteByIdAsync(id);
        }
        public async Task<Attribute> updateAttrbiute(Attribute value)
        {
            var entity =await _attributesRepository.updateAttrbiute(value);
            return entity;
        }
    }
}