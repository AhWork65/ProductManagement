using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Dto.Product;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Services.IServices;
using ProductManagement.Services.Service.AttributeDetail;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Controllers.Api
{

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _ProductServices;


        public ProductController
            (
                IProductServices productServices


            )
        {
            _ProductServices = productServices;

        }


        [HttpGet]
        [Route("[controller]/GetAll/")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _ProductServices.GetAll());

        }

        [HttpGet]
        [Route("[controller]/GetAllActive/")]
        public async Task<IActionResult> GetAllActive()
        {


            return Ok(await _ProductServices.GetAllActive());

        }


        [HttpGet]
        [Route("[controller]/GetAllInactive/")]
        public async Task<IActionResult> GetAllInactive()
        {

            return Ok(await _ProductServices.GetAllInactive());

        }


        [HttpGet]
        [Route("[controller]/GetByCategory/{categoryId}/")]
        public async Task<IActionResult> GetProductByCategory([FromRoute] int categoryId)
        {

            return Ok(await _ProductServices.GetProductByCategory(categoryId));

        }

        [HttpGet]
        [Route("[controller]/GetActiveByCategory/{categoryId}/")]
        public async Task<IActionResult> GetActiveProductByCategory([FromRoute] int categoryId)
        {

            return Ok(await _ProductServices.GetActiveProductByCategory(categoryId));

        }

        [HttpGet]
        [Route("[controller]/GetInactiveByCategory/{categoryId}/")]
        public async Task<IActionResult> GetInactiveProductByCategory([FromRoute] int categoryId)
        {

            return Ok(await _ProductServices.GetInactiveProductByCategory(categoryId));

        }



        [HttpGet]
        [Route("[controller]/GetByClassification/{classification}")]
        public async Task<IActionResult> GetProductByClassification([FromRoute] int classification)
        {

            return Ok(await _ProductServices.GetProductByClassification(classification));

        }

        [HttpGet]
        [Route("[controller]/GetActiveByClassification/{classification}")]
        public async Task<IActionResult> GetActiveProductByClassification([FromRoute] int classification)
        {

            return Ok(await _ProductServices.GetActiveProductByClassification(classification));

        }

        [HttpGet]
        [Route("[controller]/GetInactiveByClassification/{classification}")]
        public async Task<IActionResult> GetInactiveProductByClassification([FromRoute] int classification)
        {

            return Ok(await _ProductServices.GetInactiveProductByClassification(classification));

        }


        [HttpGet]
        [Route("[controller]/GetBaseOnClassification/{classification}")]
        public async Task<IActionResult> GetProductBaseOnClassification([FromRoute] int classification)
        {

            return Ok(await _ProductServices.GetProductBaseOnClassification(classification));

        }

        [HttpGet]
        [Route("[controller]/GetById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {

            return Ok(await _ProductServices.GetDetailById(id));

        }


        [HttpGet]
        [Route("[controller]/GetByCode/{code}")]
        public async Task<IActionResult> GetProductByCode([FromRoute] string code)
        {

            return Ok(await _ProductServices.GetDetailByCode(code));

        }

        

        [HttpGet]
        [Route("[controller]/GetDetail/CategoryAndClassification/{productId}")]
        public async Task<IActionResult> GetCategoryAndClassificationDetail(int productId)

        {
            return Ok(await _ProductServices.GetCategoryAndClassificationDetail(productId));

        }







        [HttpPost]
        [Route("[controller]/Add/")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO entity)
        {

            return Ok(await _ProductServices.Create(entity));

        }

        [HttpPost]
        [Route("[controller]/AddAttributeToProduct/")]
        public async Task AddAttributeToProduct(IList<ProductAttributesDTO> productAttributes)
        {
            await _ProductServices.AddAttributeToProduct(productAttributes);
        }


        [HttpPost]
        [Route("[controller]/AddImageToProduct/")]
        public async Task<IActionResult> AddImageToProduct(ProductSendImageDto productSendImage)
        {
            return await _ProductServices.AddImageToProduct(productSendImage);

        }


        [HttpPut]
        [Route("[controller]/Update/")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO entity)
        {
            await _ProductServices.Update(entity);
            return Ok("");
        }


        [HttpPut]
        [Route("[controller]/Update/UnitPrice/")]
        public async Task<IActionResult> UpdateBaseUnitPrice([FromBody] ProductUpdateUnitPriceDTO obj)
        {

            await _ProductServices.UpdateBaseUnitPrice(obj);
            return Ok("Updated !");

        }


        [HttpPut]
        [Route("[controller]/Update/UnitsStock/")]
        public async Task<IActionResult> UpdateUnitsStock(ProductUpdateUnitsInStockDTO dto)
        {
            await _ProductServices.UpdateUnitStock(dto);
            return Ok("Updated ! ");

        }


        [HttpDelete]
        [Route("[controller]/Delete/{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {

            await _ProductServices.Delete(id);

            return Ok();

        }





    }
}

