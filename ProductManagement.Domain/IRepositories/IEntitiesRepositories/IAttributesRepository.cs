using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementWebApi.Models;
using ProductManagement.Domain.Repositories.Base;
using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IAttributesRepository : IBaseRepository<Attribute>
    {

        Task<IEnumerable<Attribute>> GetAttributeDetailByParentId(int parentId);
        Task<IEnumerable<Attribute>> GetAttributeList();
    }
}
