
using ProductManagement.Services.Dto.Attribute;
using Attribute=ProductManagementWebApi.Models.Attribute;



namespace ProductManagement.Services.Service.Attributes
{
    public interface IAttributesService
    {

        Task<Attribute> updateAttrbiute(Attribute value);
        AttributeDto GetNodeAttributeDto(Attribute value);
        Attribute GetNodeAttribute(Attribute value);
        Task<IList<Attribute>> GetAll(string title);
        Task<Attribute> AddAttribute(Attribute entity);
        Task DeleteByIdAsync(int id);
        int AddDto(AttributeDto entitiydto);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);
        Task<IQueryable<Attribute>> GetAttributeList();
        Task<IList<Attribute>> GetAll();




    }
}
