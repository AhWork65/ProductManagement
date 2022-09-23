
using System.ComponentModel;
using ProductManagement.Domain.Repositories.Base;
using ProductManagementWebApi.Models;
using Attribute= ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IAttributesRepository : IBaseRepository<Attribute>
    {
        Task<AttributeDto> updateAttrbiute(AttributeDto valueDto, int id);
        Task<Attribute> updateAttrbiute(Attribute attribute); 

        Task<bool> IsExsistAttrbiute(int id);

        Attribute GetNodeAttribute(AttributeDto valueDto);


        Task<IList<Attribute>> GetAttributeDetailByParentId(int id);

        Task<IList<Attribute>> GetAttributeList();

        Task<IList<Attribute>> GetAll(string title);

    }
}
