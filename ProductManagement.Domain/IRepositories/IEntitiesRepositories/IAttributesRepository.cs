
using System.ComponentModel;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;
using Attribute= ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IAttributesRepository : IBaseRepository<Attribute>
    {

        Task<Attribute> updateAttrbiute(Attribute value);
        Task<bool> IsExsistAttrbiute(int id);

        Attribute GetNodeAttribute(Attribute value);

        Task DeleteByIdAsync(int id);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);

        Task<IQueryable<Attribute>> GetAttributeList();

        Task<IList<Attribute>> GetAll(string title);
        Task<IList<Attribute>> GetAll();
    }
}
