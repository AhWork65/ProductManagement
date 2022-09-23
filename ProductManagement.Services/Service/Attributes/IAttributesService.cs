using Attribute = ProductManagementWebApi.Models.Attribute;
using ProductManagement.Services.Dto;
using ProductManagementWebApi.Models;


namespace ProductManagement.Services.Service.Attributes
{
    public interface IAttributesService
    {
        Task<Attribute> GetById(int id); 
        Task<Attribute> updateAttrbiute(Attribute attribute);
        int AddDto(AttributeDto entitiydto);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);
        Task<IList<Attribute>> GetAttributeList();
        Task<IList<Attribute>> GetAll();
        Task<IList<Attribute>> GetAll(string title); 
         Attribute GetNodeAttribute(AttributeDto valueDto); 
    }
}
