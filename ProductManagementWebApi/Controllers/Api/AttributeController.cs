
using Microsoft.AspNetCore.Mvc;

using ProductManagement.Domain.Models.Base;
using ProductManagement.Services.Dto.Attribute;
using ProductManagement.Services.Service.Attributes;
using ProductManagementWebApi.Models;
using ProuctManagemetServices.Services.Mapper;
using Attribute = System.Attribute;


namespace ProductManagementWebApi.Controllers.Api
{

    public class AttributeController : MyBaseAttributesController
    {

        private readonly IAttributesService _attributesService;
        public AttributeController(IAttributesService attributesService)
        {
            _attributesService = attributesService;

        }



        [HttpPost]
        public BaseModelResult<int> AddAttribute(AttributeDto value)
        {
            var nodeAttribute = new Models.Attribute();

            if (string.IsNullOrWhiteSpace(value.Name))
                return InvalidResult<int>(1, "نام نمی تواند خالی باشد");
            if (nodeAttribute.ParentId == null)
            {
                nodeAttribute.Name = value.Name;
                var id = _attributesService.AddDto(value);
                return careateModelResult(id);

            }
            else
            {
                Models.Attribute parentAttribute = _attributesService.GetNodeAttribute(nodeAttribute);
                nodeAttribute.Name = value.Name;
                parentAttribute.subNodes.Add(nodeAttribute);

            }

            return careateModelResult(1);



        }



        [HttpGet]
        public async Task<BaseModelResult<IQueryable<Models.Attribute>>> GetAllAsync()
        {
            var result = await _attributesService.GetAttributeList();

            return careateModelResult(result);
        }


        [HttpGet("id")]

        public async Task<BaseModelResult<IList<Models.Attribute>>> GetAllAsync(int id)
        {
            var result = await _attributesService.GetAttributeDetailByParentId(id);

            return careateModelResult(result);
        }



        [HttpGet("title")]
        public async Task<BaseModelResult<IList<Models.Attribute>>> GetNodes(string Title)
        {
            var result = await _attributesService.GetAll(Title);
            return careateModelResult(result);
        }

        [HttpPut]
        public async Task<BaseModelResult<Models.Attribute>> UpdateAttribute(Models.Attribute attribute)
        {
            var result = await _attributesService.updateAttrbiute(attribute);
            return careateModelResult(result);
        }

        
        [HttpDelete("id")]
        public async Task DeleteAttribute(int id)
        {
             await _attributesService.DeleteByIdAsync(id);
         
        }
    }
}
