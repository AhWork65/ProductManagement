using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Dto.Product;
using ProductManagement.Domain.Dto.RelatedProducts;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Service.RelatedProductsServices
{
    public interface IRelatedProductsService
    {
        Task Add(RelatedProductsCreationDTO entity);
        Task Remove(int relatedProductsID);
        Task<RelatedProduct> GetById(int relatedProductId);
        Task<IList<ProductListDTO>> GetItemRelatedProductsByBaseProductId(int BaseProductId);
        Task<IList<int>> GetItemRelatedProductsIdByBaseProductId(int baseProductId); 

    }
}
