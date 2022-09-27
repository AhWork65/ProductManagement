using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Models.Base;
using ProductManagement.Domain.Dto.Attribute;
using ProductManagement.Services.Service.Attributes;
using Attribute = ProductManagementWebApi.Models.Attribute;



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

        public async Task<BaseModelResult<string>> CreateAttribute(AttributeDto valuedto)
        {
            var nodeAttribute = new Models.Attribute();

            if (string.IsNullOrWhiteSpace(valuedto.Name))
                return InvalidResult<string>(1, "The name cannot be empty");

            if (nodeAttribute.ParentId == null)
            {
                await _attributesService.AddDto(valuedto);
                return careateModelResult("Insert Is OK....");
            }
            else
            {
                Attribute parentAttribute = _attributesService.GetNodeAttribute(nodeAttribute);
                parentAttribute.subNodes.Add(nodeAttribute);
            }

            return careateModelResult("Add is ok .....");
        }

        [HttpGet]
        public async Task<BaseModelResult<List<Models.Attribute>>> GetAllAsync()
        {
            List<Attribute> result = await _attributesService.GetAttributeListAsync();

            return careateModelResult(result);
        }

        [HttpGet("{id:int}")]

        public async Task<BaseModelResult<IList<Attribute>>> GetByIdAsync(int id)
        {

            var result = await _attributesService.GetAttributeDetailByParentId(id);
            return careateModelResult(result);
        }

        [HttpPut]
        public async Task<BaseModelResult<string>> UpdateAttribute(AttributeDto attributedto)
        {
            await _attributesService.UpdateDto(attributedto);
            return careateModelResult("Update is ok");
        }


        [HttpDelete("{id:int}")]
        public async Task<BaseModelResult<string>> DeleteAttribute(int id)
        {

            await _attributesService.DeleteByIdAsync(id);

            return careateModelResult("Delete is ok");
        }


        [HttpDelete("{id:int}")]

        public async Task<BaseModelResult<string>> DeleteParentAttribute(int id)
        {
            await _attributesService.DeleteByParentId(id);

            return careateModelResult("Delete is ok");
        }



    }
}
