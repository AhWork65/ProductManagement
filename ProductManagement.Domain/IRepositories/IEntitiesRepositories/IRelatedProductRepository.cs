using ProductManagementWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.IRepositories.IEntitiesRepositories
{
    public  interface IRelatedProductRepository
    {

        Task<IEnumerable<RelatedProduct>> GetByBaseProductIdIwthRelatedProducts(int baseProductId);


    }
}
