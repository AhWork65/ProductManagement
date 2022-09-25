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
        public async Task<bool> IsRecordWithEnteredIdExists(int id)
        {

            return await _RelatedProductRepository.Any(mdl => mdl.Id == id);

        }
    }
}
