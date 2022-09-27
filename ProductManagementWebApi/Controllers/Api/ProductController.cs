using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Dto.Product;
using ProductManagement.Services.Domain.Product;
using ProductManagement.Services.Service.Attributes;
using ProductManagement.Services.Service.CategoryService.Validation;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Services.IServices;
using ProductManagement.Services.Mapper;
using ProductManagement.Services.Service.AttributeDetail;
using ProductManagementWebApi.Models;
using Attribute = ProductManagementWebApi.Models.Attribute;

namespace ProductManagementWebApi.Controllers.Api
{

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _ProductServices;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IProductValidationService _ProductValidationService;
        private readonly ICategoryServiceValidation _CategoryValidationService;
        private readonly IAttributesService _AttributeService;
        private readonly IAttributeDetailService _AttributeDetailService;

        public ProductController
            (
                IProductServices productServices,
                IUnitOfWork unitOfWork,
                IProductValidationService productValidationService,
                ICategoryServiceValidation categoryServiceValidation,
                IAttributesService attributeService,
                IAttributeDetailService AttributeDetailService

            )
        {
            _ProductServices = productServices;
            _ProductValidationService = productValidationService;
            _CategoryValidationService = categoryServiceValidation;
            _AttributeService = attributeService;
            _AttributeDetailService = AttributeDetailService;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("[controller]/getall/")]
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
        [Route("[controller]/GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            return Ok(await _ProductServices.GetById(id));

        }


        [HttpGet]
        [Route("[controller]/GetByCode/{code}")]
        public async Task<IActionResult> GetByCode([FromRoute] string code)
        {

            return Ok(await _ProductServices.GetProductByCode(code));

        }


        [HttpGet]
        [Route("[controller]/GetByCategoryId/{categoryId}/")]
        public async Task<IActionResult> GetByCategory([FromRoute] int categoryId)
        {

            return Ok(await _ProductServices.GetProductByCategory(categoryId)); 

        }


        [HttpGet]
        [Route("[controller]/GetByClassification/{classification}")]
        public async Task<IActionResult> GetByClassification([FromRoute] int classification)
        {
            
            return Ok(await _ProductServices.GetProductByClassification(classification));

        }

        [HttpGet]
        [Route("[controller]/GetBaseOnClassification/{classification}")]
        public async Task<IActionResult> GetBaseOnClassification([FromRoute] int classification)
        {

            var isClassificationIdExists = _ProductValidationService.IsClassificationExists(classification);
            if (!isClassificationIdExists) return BadRequest("classificationId does not exists");

            var isRecordWithClassificationExists =
                await _ProductValidationService.IsRecordWithEnteredClassificationExists(classification);
            if (!isRecordWithClassificationExists) return BadRequest("Record does not exists");

            var objs = await _ProductServices.GetProductBaseOnClassification(classification);
            return Ok(objs);

        }


        [HttpGet]
        [Route("[controller]/GetById/withAttributes/{id}")]
        public async Task<IActionResult> GetByIdWithAttributes([FromRoute] int id)
        {

            var isIdExists = _ProductValidationService.IsIdExists(id);
            if (!isIdExists) return BadRequest("id does not exists");

            var isRecordExists = await _ProductValidationService.IsRecordWithEnteredIdExists(id);
            if (!isRecordExists) return BadRequest("record does not exists ");

            var obj = await _ProductServices.GetByIdWithAttributes(id);
            return Ok(obj);

        }


        [HttpPost]
        [Route("[controller]/Update/UnitsOfStock/")]
        public async Task<IActionResult> UpdateUnitsOfStock(ProductUpdateUnitsInStockDTO dto)
        {

            var isIdExists = _ProductValidationService.IsIdExists(dto.Id);
            if (!isIdExists) return BadRequest("id does not exists");

            var isRecordWithEnterdIdExists = await _ProductValidationService.IsRecordWithEnteredIdExists(dto.Id);
            if (!isRecordWithEnterdIdExists) return BadRequest("record does not exists");

            var product = await _ProductServices.GetById(dto.Id);

            var IsSufficientInventory = _ProductValidationService.IsSufficientInventory(product, dto);
            if (!IsSufficientInventory) return BadRequest("not enough units in stock");

            var IsIncreasingStock = _ProductServices.IsIncreasingProductUpdateUnitStock(dto);
            if (IsIncreasingStock) _ProductServices.IncreaseUnitsInStock(product, dto.Quantity);
            else _ProductServices.DeacreaseUnitsInStock(product, dto.Quantity);

            await _unitOfWork.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        [Route("[controller]/Delete/")]
        public async Task DeleteProduct([FromRoute] int id)
        {

            await _ProductServices.Delete(id);

        }

        [HttpPost]
        [Route("[controller]/Update/UnitOfPrice/")]
        public IActionResult UpdateUnitOfPrice()
        {
            return Ok("");
        }

        [HttpPost]
        [Route("[controller]/Add/")]
        public async Task<IActionResult> AddProduct([FromBody] ProductCreaionDTO entity)
        {

            var isRecordExists = await _ProductValidationService.IsRecordWithEnteredCodeExists(entity.Code);
            if (isRecordExists) return BadRequest("Product exists ");

            var newProduct = DtoMapper.MapTo<ProductCreaionDTO, Product>(entity);
            if (!ModelState.IsValid) return BadRequest("Validation Error ");


            await _ProductServices.Create(newProduct);


            var attributesList = entity.Attributes;
            if (attributesList != null)
            {
                foreach (var item in attributesList)
                {
                    var newAttributeDetail = DtoMapper.MapTo<ProductAttributesDTO, ProductAttributeDetail>(item);
                    //await _AttributeService.AddDto(newAttribute);\
                    newAttributeDetail.ProductId = newProduct.Id;
                    await _AttributeDetailService.Add(newAttributeDetail);

                }

                _unitOfWork.SaveChanges();
            }

            return Ok("Created");

        }


        [HttpPut]
        [Route("[controller]/Update/")]
        public IActionResult UpdateProduct()
        {

            return Ok("");

        }




    }
}

