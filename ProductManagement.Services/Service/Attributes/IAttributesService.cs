using Attribute=ProductManagementWebApi.Models.Attribute;
using ProductManagement.Services.Dto.Attribute;


namespace ProductManagement.Services.Service.Attributes
{
    public interface IAttributesService 
      {
          Task<Attribute> updateAttrbiute(Attribute attribute);
           int AddDto(AttributeDto entitiydto);
          IQueryable<Attribute> GetAll();
    }
}
