
using System.Linq.Expressions;
using ProductManagementWebApi.Models;
using Attribute=ProductManagementWebApi.Models.Attribute;



namespace ProductManagement.Services.Service.Attributes
{
    public interface IAttributesService
    {
        Attribute GetNodeAttribute(AttributeDto valueDto);

        Task<IList<Attribute>> GetAll(string title);


        Task<AttributeDto> updateAttrbiute(AttributeDto valueDto, int id);
        int AddDto(AttributeDto entitiydto);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);
        Task<IList<Attribute>> GetAttributeList();
        Task<IList<Attribute>> GetAll();



    }
}
