
using System.ComponentModel;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;
using Attribute= ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IAttributesRepository : IBaseRepository<Attribute>
    {
        int AddDto(Attribute entitiy);
        Task AddAsync(Attribute entity);
        Task<Attribute> updateAttrbiute(Attribute value);
        Task<bool> IsExsistAttrbiute(int id);
        Task<bool> IsExsistAttrbiuteNode(int id);
        Attribute GetNodeAttribute(Attribute value);

        Task DeleteByIdAsync(int id);
        Task DeleteByIdNodeAsync(int id);
        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);

        Task<List<Attribute>> GetAttributeList();

        Task<IList<Attribute>> GetAll(string title);
        Task<IList<Attribute>> GetAll();
		
	
    }
}
