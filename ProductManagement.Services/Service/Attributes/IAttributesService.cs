
using ProductManagement.Domain.Dto.Attribute;
using Attribute=ProductManagementWebApi.Models.Attribute;



namespace ProductManagement.Services.Service.Attributes
{
    public interface IAttributesService
    {
        Task UpdateDto(AttributeDto valuedto);
        Task AddDto(AttributeDto entitiydto);
        Task DeleteByIdAsync(int id);
        Task DeleteByParentId(int id);
        Task<List<AttributeSubDto>> GetAttributeDetailByParentId(int id);
        Task<List<AttributeSubDto>> GetAttributeDetailByNodeId(int id);
        Task<List<AttributeSubDto>> GetAttributeListAsync();

        Task<List<AttributeSubDto>> GetAttributeListByProductId(int id);
    }
}
