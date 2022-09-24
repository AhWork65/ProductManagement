
using Microsoft.AspNetCore.Mvc;

using ProductManagement.Domain.Models.Base;
using ProductManagement.Services.Dto.Attribute;
using ProductManagement.Services.Service.Attributes;
using ProductManagementWebApi.Models;
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
        public BaseModelResult<string> AddAttribute(AttributeDto valuedto)
        {
            var nodeAttribute = new Models.Attribute();

            if (string.IsNullOrWhiteSpace(valuedto.Name))
                return InvalidResult<string>(1, "نام نمی تواند خالی باشد");

            

            if (nodeAttribute.ParentId == null)
            {
                nodeAttribute.Name = valuedto.Name;
                nodeAttribute.Value = valuedto.Value;
                _attributesService.AddDto(valuedto);
                return careateModelResult("درج انجام شد");

            }
            else
            {
                Models.Attribute parentAttribute = _attributesService.GetNodeAttribute(nodeAttribute);
                nodeAttribute.Name = valuedto.Name;
                nodeAttribute.Value = valuedto.Value;
                parentAttribute.subNodes.Add(nodeAttribute);
            }

        
            return careateModelResult("درج انجام شد");



        }



        [HttpGet]
        public async Task<BaseModelResult<List<Models.Attribute>>> GetAllAsync()
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
        public async Task<BaseModelResult<Models.Attribute>> UpdateAttribute(AttributeDto attributedto)
        {
            var result = await _attributesService.UpdateDto(attributedto);
            return careateModelResult(result);
        }


        [HttpDelete("id")]
        public async Task<BaseModelResult<string>> DeleteAttribute(int id)
        {
            if (!await _attributesService.IsExsistAttrbiute(id))

                return careateModelResult("Not found");



            await _attributesService.DeleteByIdAsync(id);

            return careateModelResult("Delete is ok");
        }



        [HttpDelete("id")]
        public async Task<BaseModelResult<string>> DeleteNodeAttribute(int id)
        {
            if (!await _attributesService.IsExsistAttrbiuteNode(id))

                return careateModelResult("Not found");



            await _attributesService.DeleteByIdNodeAsync(id);

            return careateModelResult("Delete is ok");
        }
    }
}
