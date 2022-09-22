using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Models.Base;
using ProductManagement.Services.Dto.Attribute;
using ProductManagement.Services.Service.Attributes;

namespace ProductManagementWebApi.Controllers.Api
{
 
    public class AttributeController : MyBaseAttributesController
    {
        public readonly Management_ProductsContext _Context;
        private  readonly  IAttributesService _attributesService;
        public AttributeController(Management_ProductsContext context, IAttributesService attributesService)
        {
            _attributesService=attributesService;
            _Context = context;
        }
        
      

        [HttpPost]
     
        public async Task Add(Models.Attribute entity)
        {

            await _Context.Attributes.AddAsync(entity);

        }


        [HttpPost]
        public BaseModelResult<int> Add(AttributeDto attributes)
        {

            if (string.IsNullOrWhiteSpace(attributes.Value))
                return InvalidResult<int>(1, "مقدار نمی تواند خالی باشد");

            if (string.IsNullOrWhiteSpace(attributes.Name))
                return InvalidResult<int>(1, "نام نمی تواند خالی باشد");

            var id = _attributesService.AddDto(attributes);


            return careateModelResult(id);
        }


        [HttpGet]
        public async Task<BaseModelResult<List<Models.Attribute>>> GetAllAsync()
        {
            var result = await _attributesService.GetAll().ToListAsync();

            return careateModelResult(result);
        }

        [HttpPut]
        public async Task Update(Models.Attribute attribute)
        {
             await _attributesService.updateAttrbiute(attribute);
          
        }

    }
}
