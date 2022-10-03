
using System.ComponentModel;
using ProductManagement.Domain.Dto.Attribute;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;
using Attribute= ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IAttributesRepository : IBaseRepository<Attribute>
    {

        Task<List<AttributeSubDto>> GetAttributeDetailByParentId(int id);
        Task<List<AttributeSubDto>> GetAttributeDetailByNodeId(int id);
        Task<List<AttributeSubDto>> GetAttributeListAsync();
        bool IsExistParent(string Title, string value);
        Task<List<AttributeSubDto>> GetAttributeListByProductId(int id);
        Task Delete(AttributeSubDto entity);

    }
}
