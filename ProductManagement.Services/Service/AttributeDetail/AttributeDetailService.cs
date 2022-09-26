using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.IRepositories.IEntitiesRepositories;
using ProductManagementWebApi.Models;

namespace ProductManagement.Services.Service.AttributeDetail
{
    public class AttributeDetailService : IAttributeDetailService
    {
        private readonly IAttributeDetailRepository _AttributeDetailRepository;

        public AttributeDetailService
            (
                IAttributeDetailRepository attributeDetailRepository
            )
        {

            _AttributeDetailRepository = attributeDetailRepository; 

        }
        public async Task Add(ProductAttributeDetail entity)
        {

             await  _AttributeDetailRepository.Add(entity); 

        }
    }
}
