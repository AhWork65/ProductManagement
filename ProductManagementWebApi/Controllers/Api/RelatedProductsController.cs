using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Services.Dto.RelatedProducts;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Service.RelatedProductsServices;
using ProductManagement.Services.Service.RelatedProductsServices.RelatedProductsValidationService;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Controllers.Api
{

    [ApiController]
    public class RelatedProductsController : ControllerBase
    {

        private readonly IRelatedProductsService _RelatedProductService;
        private readonly IRelatedProductValidationService _RelatedProductValidationService;
        private readonly IProductValidationService _ProductValidationService;

        public RelatedProductsController
            (
                IRelatedProductsService relatedProductService,
                IRelatedProductValidationService relatedProductValidationService,
                IProductValidationService productValidationService
                )
        {

            _RelatedProductService = relatedProductService;
            _RelatedProductValidationService = relatedProductValidationService;
            _ProductValidationService = productValidationService;

        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> Add([FromBody] RelatedProductsCreationDTO relatedProductDTO)
        {

            var newRelatedProductObj = DtoMapper.MapTo<RelatedProductsCreationDTO, RelatedProduct>(relatedProductDTO);
            if (!ModelState.IsValid) return BadRequest("Invalid Values");

            await _RelatedProductService.Add(newRelatedProductObj);
            return Ok("Created ");

        }

        [HttpDelete]
        [Route("[controller]/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var isRecordWithEnteredIdExists = await _RelatedProductValidationService.IsRecordWithEnteredIdExists(id);
            if (!isRecordWithEnteredIdExists) return BadRequest("Entity Does not exists");

            var obj = await _RelatedProductService.GetById(id);
            await _RelatedProductService.Remove(obj);
            return Ok("Deleted");

        }


        [HttpPost]
        [Route("[controller]/AddToRelatedProduct/")]
        public async Task<IActionResult> AddToRelatedProduct(AddToRelatedProductDTO dto)
        {

            var isRecordWithEnteredIdExists =
               await _RelatedProductValidationService.IsRecordWithEnteredIdExists(dto.RelatedProductId);
            if (!isRecordWithEnteredIdExists) return BadRequest("Related Product does not exists ");

            var isProductWithEnteredIdExists =
               await _ProductValidationService.IsRecordWithEnteredIdExists(dto.RelatedEntityId);
            if (!isProductWithEnteredIdExists) return BadRequest("Product does not exists");

            await _RelatedProductService.AddToRelatedProduct(dto.RelatedProductId, dto.RelatedEntityId);

            return Ok();
        }



    }
}
