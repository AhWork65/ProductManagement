
using System.ComponentModel;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;
using Attribute= ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IAttributesRepository : IBaseRepository<Attribute>
    {
       
        Attribute GetNodeAttribute(Attribute value);
        Task DeleteByIdAsync(int id);
        Task DeleteByParentId(int id);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);
        List<Attribute> GetAttributeList(List<Attribute> attributes);
        Task<List<Attribute>> GetAttributeListAsync();
        Task<bool> IsExistParent(string Title);

    }
}
