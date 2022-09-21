using ProductManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Repositories.Base;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IRelatedProductRepository :IBaseRepository<RelatedProduct>
    {

       public Task<IEnumerable<RelatedProduct>> GetByBaseProductIdIwthRelatedProducts(int baseProductId);


    }
}
