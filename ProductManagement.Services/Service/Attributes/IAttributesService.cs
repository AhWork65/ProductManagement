using Attribute = ProductManagementWebApi.Models.Attribute;
using ProductManagement.Services.Dto.Attribute;


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
    }
}
