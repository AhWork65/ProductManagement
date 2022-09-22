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
        private  readonly  IAttributesService _attributesService;
        public AttributeController( IAttributesService attributesService)
        {
            _attributesService=attributesService;
        }
        
      

        //[HttpPost]
        //public async Task Add(Models.Attribute entity)
        //{

        //    await _Context.Attributes.AddAsync(entity);

        //}


        [HttpPost]
        public BaseModelResult<int> Add(AttributeDto attributes)
        {

            //if (string.IsNullOrWhiteSpace(attributes.Value))
            //    return InvalidResult<int>(1, "مقدار نمی تواند خالی باشد");

            if (string.IsNullOrWhiteSpace(attributes.Name))
                return InvalidResult<int>(1, "نام نمی تواند خالی باشد");

            var id = _attributesService.AddDto(attributes);


            return careateModelResult(id);
        }


        [HttpGet]
        public async Task<BaseModelResult<IList<Models.Attribute>>> GetAllAsync()
        {
            var result = await _attributesService.GetAttributeList();

            return careateModelResult(result);
        }


        [HttpGet]
        [Route("[controller]/GetAllAsync/{id:int}")]
        public async Task<BaseModelResult<IList<Models.Attribute>>> GetAllAsync(int id)
        {
            var result = await _attributesService.GetAttributeDetailByParentId(id);

            return careateModelResult(result);
        }

        [HttpPut]
        public async Task Update(Models.Attribute attribute)
        {
             await _attributesService.updateAttrbiute(attribute);
          
        }

    }
}
