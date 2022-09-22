
using System.ComponentModel;
using ProductManagement.Domain.Repositories.Base;
using Attribute= ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IAttributesRepository : IBaseRepository<Attribute>
    {
        Task<Attribute> updateAttrbiute(Attribute attribute);
        Task<bool> IsExsistAttrbiute(int id);
      


        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);
        Task<IList<Attribute>> GetAttributeList();

    }
}
