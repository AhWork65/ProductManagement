using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Service.RelatedProductsServices
{
    public class RelatedProductService : IRelatedProductsService
    {

        private readonly IRelatedProductRepository _RelatedProductRepository;

        public RelatedProductService(IRelatedProductRepository relatedProductRepository)
        {

            _RelatedProductRepository = relatedProductRepository; 

        }

        public async Task Add(RelatedProduct entity)
        {

            await _RelatedProductRepository.Add(entity); 


        }

        public async Task AddToRelatedProduct(int relatedProductId, int relatedEntityId)
        {

            var obj = await _RelatedProductRepository.GetById(relatedEntityId);
            obj.RelatedProductId = relatedEntityId; 

        }

        public async Task Remove(int relatedProductsID)
        {

            await _RelatedProductRepository.Delete(relatedProductsID); 

        }

        public async Task<RelatedProduct> GetById(int relatedProductId)
        {

           return await _RelatedProductRepository.GetById(relatedProductId);

        }

        public async Task<IList<RelatedProduct>> GetByBaseProductId(int BaseProductId)
        {

           return await _RelatedProductRepository.GetByBaseProductId(BaseProductId); 

        }
    }
}
