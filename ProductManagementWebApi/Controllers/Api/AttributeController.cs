using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Models.Base;


using ProductManagement.Services.Service.Attributes;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Controllers.Api
{

    public class AttributeController : MyBaseAttributesController
    {
     
        private readonly IAttributesService _attributesService;
        public AttributeController( IAttributesService attributesService)
        {
            _attributesService = attributesService;
           
        }


        [HttpPost]
        public BaseModelResult<int> Add(AttributeDto attributeDto)
        {

            var nodeAttribute = new Models.Attribute();

            if (string.IsNullOrWhiteSpace(attributeDto.Name))
                return InvalidResult<int>(1, "نام نمی تواند خالی باشد");
            if (nodeAttribute.ParentId == null)
            {
                nodeAttribute.Name = attributeDto.Name;
                var id = _attributesService.AddDto(attributeDto);
                return careateModelResult(id);

            }
            else
            {
                Models.Attribute parentAttribute = _attributesService.GetNodeAttribute(attributeDto);
                nodeAttribute.Name = attributeDto.Name;
                parentAttribute.subNodes.Add(nodeAttribute);
            }

            return careateModelResult(1);



        }


        [HttpGet]
        public async Task<BaseModelResult<IList<Models.Attribute>>> GetAllAsync()
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

        [HttpPut("id")]
     
        public async Task<BaseModelResult<AttributeDto>> Update(AttributeDto attributeDto,int id)
        {
        var result= await _attributesService.updateAttrbiute(attributeDto,id);

            return careateModelResult(result);
        }

    }
}
