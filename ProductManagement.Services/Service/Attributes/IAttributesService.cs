﻿
using ProductManagement.Domain.Dto.Attribute;
using Attribute=ProductManagementWebApi.Models.Attribute;



namespace ProductManagement.Services.Service.Attributes
{
    public interface IAttributesService
    {
        Task UpdateDto(AttributeDto valuedto);
        Task AddDto(AttributeDto entitiydto);
      
        Attribute GetNodeAttribute(Attribute value);
        Task DeleteByIdAsync(int id);

        Task DeleteByParentId(int id);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);
        List<Attribute> GetAttributeList(List<Attribute> attributes);
        Task<List<Attribute>> GetAttributeListAsync();


    }
}
