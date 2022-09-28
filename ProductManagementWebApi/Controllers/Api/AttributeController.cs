using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Models.Base;
using ProductManagement.Domain.Dto.Attribute;
using ProductManagement.Services.Service.Attributes;
using Attribute = ProductManagementWebApi.Models.Attribute;



namespace ProductManagementWebApi.Controllers.Api
{

    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IAttributesService _attributesService;

        public AttributeController(IAttributesService attributesService)
        {
            _attributesService = attributesService;

        }


        [HttpPost]
        [Route("[controller]/CreateAttribute")]
        public async Task<IActionResult>  CreateAttribute(AttributeDto valuedto) {
            
            await _attributesService.AddDto(valuedto);
            return Ok();
        }

        [HttpPut]
        [Route("[controller]/UpdateAttribute")]
        public async Task<IActionResult> UpdateAttribute(AttributeDto attributedto)
        {
            await _attributesService.UpdateDto(attributedto);
            return Ok();

        }


        [HttpGet]
        [Route("[controller]/GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
           return Ok(await _attributesService.GetAttributeListAsync());

        
        }

        [HttpGet]
        [Route("[controller]/GetByIdAsync/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var obj_attr=await _attributesService.GetAttributeDetailByParentId(id);
           return Ok(obj_attr);
        }

        [HttpGet]
        [Route("[controller]/GetAttributeListByProductId/{id:int}")]
        public async Task<IActionResult> GetAttributeListByProductId(int id)
        {

           return Ok(await _attributesService.GetAttributeListByProductId(id));
           

        }

 

        [HttpDelete]
        [Route("[controller]/DeleteAttribute/{id:int}")]
        public async Task<IActionResult> DeleteAttribute(int id)
        {
            await _attributesService.DeleteByIdAsync(id);
            return Ok();
        }


        [HttpDelete]
        [Route("[controller]/DeleteParentAttribute/{id:int}")]
        public async Task<IActionResult> DeleteParentAttribute(int id)
        {
         
            await _attributesService.DeleteByParentId(id);
            return Ok();

        }




    }
}
