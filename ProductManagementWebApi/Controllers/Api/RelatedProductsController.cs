using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Dto.RelatedProducts;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Service.RelatedProductsServices;
using ProductManagement.Services.Service.RelatedProductsServices.RelatedProductsValidationService;
using ProductManagementWebApi.Models;
using GlobalErrorApp.Exceptions;

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


        [HttpGet]
        [Route("[controller]/GetRelatedItems/ByBaseProductId/{baseProductId}")]
        public async Task<IActionResult> GetRelatedItemsByBaseProductId(int baseProductId)
        {

            return Ok(await _RelatedProductService.GetItemRelatedProductsIdByBaseProductId(baseProductId)); 

        }


        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> Add([FromBody] RelatedProductsCreationDTO relatedProductDTO)
        {
            await _RelatedProductService.Add(relatedProductDTO);

            return Ok("Created");

        }

        [HttpDelete]
        [Route("[controller]/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            await _RelatedProductService.Remove(id); 
            return Ok("Deleted");

        }




    }
}
