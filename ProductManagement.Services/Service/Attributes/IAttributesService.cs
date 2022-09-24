
using ProductManagement.Services.Dto.Attribute;
using Attribute=ProductManagementWebApi.Models.Attribute;



namespace ProductManagement.Services.Service.Attributes
{
    public interface IAttributesService
    {
        Task DeleteByIdNodeAsync(int id);
        Task<Attribute> UpdateDto(AttributeDto valuedto);
        Task<Attribute> updateAttrbiute(Attribute value);
        AttributeDto GetNodeAttributeDto(Attribute value);
        Attribute GetNodeAttribute(Attribute value);
        Task<IList<Attribute>> GetAll(string title);
        Task<Attribute> AddAttribute(Attribute entity);
        Task DeleteByIdAsync(int id);
        int AddDto(AttributeDto entitiydto);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);
        Task<List<Attribute>> GetAttributeList();
        Task<IList<Attribute>> GetAll();
        Task<bool> IsExsistAttrbiute(int id);
        Task<bool> IsExsistAttrbiuteNode(int id);


    }
}
