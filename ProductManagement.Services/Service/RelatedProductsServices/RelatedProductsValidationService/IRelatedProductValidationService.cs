using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Service.RelatedProductsServices.RelatedProductsValidationService
{
    public interface IRelatedProductValidationService
    {
        Task<bool> IsRecordWithEnteredIdExists(int id); 


    }
}
