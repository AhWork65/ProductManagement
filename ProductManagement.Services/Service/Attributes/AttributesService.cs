﻿using AutoMapper;
using GlobalErrorApp.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagement.Domain.Dto.Attribute;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.Attributes.Validation;
using ProductManagementWebApi.Models;

using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Services.Service.Attributes
{
    public class AttributesService : IAttributesService
    {
        public readonly IAttributesRepository _attributesRepository;
        public readonly IAttributeValidationService _attributeValidationService;
        

        public AttributesService
        (

            IAttributesRepository attributesRepository,
            IAttributeValidationService attributeValidationService
        )
        {
            _attributesRepository = attributesRepository;
            _attributeValidationService = attributeValidationService;

        }

        public async Task UpdateDto(AttributeDto valuedto)
        {
       
            var entity = DtoMapper.MapTo<AttributeDto, Attribute>(valuedto);
            if (!_attributeValidationService.IsExistAttributeNodeById(entity.Id).Result)
                throw new BadRequestException("The value entered is not Valid");

            await _attributesRepository.Update(entity);
        }

        public async Task AddDto(AttributeDto valuedto)
        {
            var entity = DtoMapper.MapTo<AttributeDto, Attribute>(valuedto);

            if (_attributeValidationService.IsExistAttributeByName(valuedto.Name).Result)
         
                   throw new BadRequestException("Dont Repeate Attribute ....");

            await _attributesRepository.Add(entity);
            
           
        }

        public List<Attribute> GetAttributeList(List<Attribute> attributes)
        {
            return _attributesRepository.GetAttributeList(attributes);
        }

        public Task<List<Attribute>> GetAttributeListAsync()
        {
            return _attributesRepository.GetAttributeListAsync();
        }


        public async Task<IList<Attribute>> GetAttributeDetailByParentId(int id)
        {
            if (!await _attributeValidationService.IsExistAttributeById(id))
                       throw new BadRequestException("This Attribute is not Valid");
            return await _attributesRepository.GetAttributeDetailByParentId(id);
        }


        public Attribute GetNodeAttribute(Attribute value)
        {
            return _attributesRepository.GetNodeAttribute(value);
        }


        public async Task DeleteByIdAsync(int id)
        {
            if (!await _attributeValidationService.IsExistAttributeNodeById(id))
                    throw new BadRequestException("This Attribute is not Valid");
            await _attributesRepository.DeleteByIdAsync(id);
        }

        public async Task DeleteByParentId(int id)
        {
            if (!await _attributeValidationService.IsExistAttributeById(id))
                throw new BadRequestException("This Attribute is not Valid");

            await _attributesRepository.DeleteByParentId(id);
        }
    }
}