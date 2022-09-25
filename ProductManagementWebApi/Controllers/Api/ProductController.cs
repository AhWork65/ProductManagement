using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Services.Dto.Product;
using ProductManagement.Services.Service.Attributes;
using ProductManagement.Services.Service.CategoryService.Validation;
using ProductManagement.Services.Service.Product.Validation;
using ProductManagement.Services.Services.IServices;
using ProductManagement.Services.Mapper;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Controllers.Api
{

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _ProductServices;
        private readonly IUnitOfWork _unitOfWork;
       
        private readonly IProductValidationService _ProductValidationService;
        private readonly ICategoryServiceValidation _CategoryValidationService;
        
        public ProductController
            (
                IProductServices productServices,
                IUnitOfWork unitOfWork,
                IProductValidationService productValidationService,
                ICategoryServiceValidation categoryServiceValidation
            )
        {
            _ProductServices = productServices;
            _ProductValidationService = productValidationService;
            _CategoryValidationService = categoryServiceValidation;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [Route("[controller]/getall/")]
        public async Task<IActionResult> GetAll()
        {

            var objs = await _ProductServices.GetAll();

            var isRecordsExists = _ProductValidationService.IsRecordExists(objs);
            if (!isRecordsExists) return BadRequest("record does not exists");

            var result = DtoMapper.ListMapTo<Product, ProductListDTO>(objs);

            return Ok(result);

        }

        [HttpGet]
        [Route("[controller]/GetAllActive/")]
        public async Task<IActionResult> GetAllActive()
        {

            var objs = await _ProductServices.GetAllActive();

            var isRecordsExists = _ProductValidationService.IsRecordExists(objs);
            if (!isRecordsExists) return BadRequest("record does not exists");

            var result = DtoMapper.ListMapTo<Product, ProductListDTO>(objs);

            return Ok(result);

        }


        [HttpGet]
        [Route("[controller]/GetAllInactive/")]
        public async Task<IActionResult> GetAllInactive()
        {

            var objs = await _ProductServices.GetAllInactive();

            var isRecordsExists = _ProductValidationService.IsRecordExists(objs);
            if (!isRecordsExists) return BadRequest("record does not exists");

            var result = DtoMapper.ListMapTo<Product, ProductListDTO>(objs);

            return Ok(result);
        }


        [HttpGet]
        [Route("[controller]/GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var isIDExists = _ProductValidationService.IsIdExists(id);
            if (!isIDExists) return BadRequest("Id Does Not Exists");

            var isRecordWithIdExists = await _ProductValidationService.IsRecordWithEnteredIdExists(id);
            if (!isRecordWithIdExists) return BadRequest("Record does not exists");

            var obj = await _ProductServices.GetById(id);
            return Ok(obj);

        }


        [HttpGet]
        [Route("[controller]/GetByCode/{code}")]
        public async Task<IActionResult> GetByCode([FromRoute] string code)
        {
            var isCodeExists = _ProductValidationService.IsCodeExists(code);
            if (!isCodeExists) return BadRequest("code does not exists");

            var isRecordWithCodeExists = await _ProductValidationService.IsRecordWithEnteredCodeExists(code);
            if (!isRecordWithCodeExists) return BadRequest("Record does not exists ");

            var obj = await _ProductServices.GetProductByCode(code);
            return Ok(obj);

        }


        [HttpGet]
        [Route("[controller]/GetByCategoryId/{categoryId}/")]
        public async Task<IActionResult> GetByCategory([FromRoute] int categoryId)
        {

            var isIdExists = _ProductValidationService.IsIdExists(categoryId);
            if (!isIdExists) return BadRequest("Id does not Exists");

            var isCategoryExists = await _CategoryValidationService.IsExistCategoryById(categoryId);
            if (!isCategoryExists) return BadRequest("category does not exists");

            var isRecordWithCategoryExists = await _ProductValidationService.IsRecordWithEnteredCategoryExists(categoryId);
            if (!isRecordWithCategoryExists) return BadRequest("Records does not exists ");

            var obj = await _ProductServices.GetProductByCategory(categoryId);
            return Ok(obj);

        }



        //[HttpGet]
        //[Route("[controller]/GetByAttribute/{attributeId}/")]
        //public async Task<IActionResult> GetByAttribute([FromRoute] int attributeId)
        //{

        //    var isIdExists = _ProductValidationService.IsIdExists(attributeId);
        //    if (!isIdExists) return BadRequest("Id does not exists"); 

        //    var isAttributeExists = await _ProductValidationService.IsAttributeExists(attributeId);
        //    if (!isAttributeExists) return BadRequest("Attribute does not exists ");

        //    var attribute = await _AttributeService.GetById(attributeId);


        //}



        [HttpGet]
        [Route("[controller]/GetByClassification/{classification}")]
        public async Task<IActionResult> GetByClassification([FromRoute] int classification)
        {
            var isClassificationIdExists = _ProductValidationService.IsClassificationExists(classification);
            if (!isClassificationIdExists) return BadRequest("classificationId does not exists");

            var isRecordWithClassificationExists =
               await _ProductValidationService.IsRecordWithEnteredClassificationExists(classification);
            if (!isRecordWithClassificationExists) return BadRequest("Record does not exists");

            var obj = await _ProductServices.GetProductByClassification(classification);
            return Ok(obj);

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
        public async   Task<IActionResult> AddProduct([FromBody] Product entity)
        {

            // var isRecordExists = await _ProductValidationService.IsRecordWithEnteredCodeExists(entity.Code);
            // if (isRecordExists) return BadRequest("Product exists "); 
            //
            // var newProduct = DtoMapper.MapTo<ProductCreateDTO, Product>(entity);
            // if (!ModelState.IsValid) return BadRequest("Validation Error ");
            //
            // await _ProductServices.Create(newProduct);
            // _unitOfWork.SaveChanges();

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

