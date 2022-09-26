
using ProductManagement.Services.Dto.Attribute;
using Attribute=ProductManagementWebApi.Models.Attribute;



namespace ProductManagement.Services.Service.Attributes
{
    public interface IAttributesService
    {
        Task UpdateDto(AttributeDto valuedto);
        int AddDto(AttributeDto entitiydto);
        AttributeDto GetNodeAttributeDto(Attribute value);
        Attribute GetNodeAttribute(Attribute value);
        Task DeleteByIdAsync(int id);

        Task DeleteById(int id);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);
        List<Attribute> GetAttributeList(List<Attribute> attributes);
        Task<List<Attribute>> GetAttributeListAsync();


    }
}
