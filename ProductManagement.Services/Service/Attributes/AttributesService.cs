using AutoMapper;
using GlobalErrorApp.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Dto.Attribute;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.Attributes.Validation;
using ProductManagement.Services.Service.Attributes.ValidationHandler;
using ProductManagementWebApi.Models;

using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Services.Service.Attributes
{
    public class AttributesService : IAttributesService
    {
        public readonly IAttributesRepository _attributesRepository;
        public readonly IAttributeValidationHandler _attributeValidationHandler;
        

        public AttributesService
        (

            IAttributesRepository attributesRepository,
            IAttributeValidationHandler attributeValidationHandler
        )
        {
            _attributesRepository = attributesRepository;
            _attributeValidationHandler = attributeValidationHandler;

        }

        public async Task UpdateDto(AttributeDto valuedto)
        {
       
            var entity = DtoMapper.MapTo<AttributeDto, Attribute>(valuedto);
            await _attributeValidationHandler.IsExistAttributeNodeByIdWithValidationHandler(entity.Id);
            await _attributesRepository.Update(entity);
        }

        public async Task AddDto(AttributeDto valuedto)
        {
            var entity = DtoMapper.MapTo<AttributeDto, Attribute>(valuedto);

            await _attributeValidationHandler.IsExistAttributeByNameWithValidationHandler(valuedto.Name,valuedto.Value);
            await _attributesRepository.Add(entity);
        }

        public List<Attribute> GetAttributeList(List<Attribute> attributes)
        {
            int z = 0;
            List<Attribute> Lists = new List<Attribute>();
            if (attributes.Count > 0)
            {
                Lists.AddRange(attributes);
            }
            foreach (Attribute a in attributes)
            {
                var dbNode = _attributesRepository.GetNodeAttribute(a);
                if (dbNode.subNodes == null)
                {
                    z++;
                    continue;
                }

                List<Attribute> subnodes = dbNode.subNodes.ToList();
                dbNode.subNodes = GetAttributeList(subnodes);
                Lists[z] = dbNode;
                z++;
            }

            return Lists;
        }

        public async Task<List<Attribute>> GetAttributeListAsync()
        {
            return GetAttributeList(await  _attributesRepository.GetAttributeListAsync());

        }


        public async Task<IList<Attribute>> GetAttributeDetailByParentId(int id)
        {
            await _attributeValidationHandler.IsExistAttributeByIdWithValidationHandler(id);
            await _attributeValidationHandler.IsExistAttributeNodeByIdWithValidationHandler(id);

            return await _attributesRepository.GetAttributeDetailByParentId(id);
        }



        public async Task DeleteByIdAsync(int id)
        {
            var subNodes = await _attributesRepository.GetAttributeDetailByParentId(id);
            if(subNodes == null)
                return;

            await _attributeValidationHandler.IsExistAttributeNodeByIdWithValidationHandler(id);

            await _attributesRepository.DeleteById(id);
        }

        public async Task DeleteByParentId(int id)
        {

            await _attributeValidationHandler.IsExistAttributeByIdWithValidationHandler(id);

            var entityList =await _attributesRepository.GetAttributeDetailByParentId(id);

            if (entityList == null)
                return;

            foreach (var e in entityList)
            {
                if (e.ParentId != null)
                {
                    _attributesRepository.Delete(e);
                }
            }

            await _attributesRepository.DeleteById(id);
        }

        public async Task<List<Attribute>> GetAttributeListByProductId(int id)
        {
            await _attributeValidationHandler.IsExistAttributeByProductIdWithValidationHandler(id);
            return await _attributesRepository.GetAttributeListByProductId(id);
        }
    }
}