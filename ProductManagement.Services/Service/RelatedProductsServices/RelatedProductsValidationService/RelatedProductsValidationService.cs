using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;

namespace ProductManagement.Services.Service.RelatedProductsServices.RelatedProductsValidationService
{
    public class RelatedProductsValidationService : IRelatedProductValidationService
    {
        private readonly IRelatedProductRepository _RelatedProductRepository;

        public RelatedProductsValidationService(IRelatedProductRepository relatedProductRepository)
        {

            _RelatedProductRepository = relatedProductRepository;

        }

        public bool IsBaseProductAndRelatedProductAreDifferent(int baseProductId , int relatedProductId)
        {

            return (baseProductId != relatedProductId); 

        }

        public async Task<bool> IsRecordWithEnteredIdExists(int id)
        {

            return await _RelatedProductRepository.Any(mdl => mdl.Id == id); 

        }

        public async Task<bool> IsRecordWithEnteredBaseProductIdExists(int baseProductId)
        {

            return await _RelatedProductRepository.Any(mdl => mdl.BaseProductId == baseProductId);

        }
    }
}
