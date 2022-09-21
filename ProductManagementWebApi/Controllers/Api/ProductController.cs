using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Services.Dto.Product;
using ProductManagement.Services.Services.IServices;

namespace ProductManagementWebApi.Controllers.Api
{
    
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _ProductServices;
        private readonly Management_ProductsContext _Context; 

        public ProductController
            (IProductServices productServices , 
            Management_ProductsContext context
                )
        {

            _ProductServices = productServices;
            _Context = context; 

        }
        
        [HttpGet]
        [Route("[controller]/getall/")]
        public async Task<IActionResult> GetAll()
        {
        
            var objs = await _ProductServices.GetAll();
            return Ok(objs);
        
        }
        
        [HttpGet]
        [Route("[controller]/GetAllActive/")]
        public async Task<IActionResult> GetAllActive()
        {
        
            var objs = await _ProductServices.GetAllActive();
            return Ok(objs);
        
        }

        
        [HttpGet]
        [Route("[controller]/GetAllInactive/")]
        public async Task<IActionResult> GetAllInactive()
        {
        
            var objs = await _ProductServices.GetAllInactive();
            return Ok(objs);
        
        }

        
        [HttpGet]
        [Route("[controller]/GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
        
            var obj = await _ProductServices.GetById(id);
            return Ok(obj);
        
        }
        

        [HttpGet]
        [Route("[controller]/GetByCode/{code}")]
        public async Task<IActionResult> GetByCode([FromRoute] string code)
        {
        
            var obj = await _ProductServices.GetProductByCode(code);
            return Ok(obj);
        
        }
        
        
        [HttpGet]
        [Route("[controller]/GetByCategoryId/{categoryId}/")]
        public async Task<IActionResult> GetByCategory([FromRoute] int categoryId)
        {
        
            var obj = await _ProductServices.GetProductByCategory(categoryId);
            return Ok(obj);
        
        }
        
        
        [HttpGet]
        [Route("[controller]/GetByClassification/{classification}")]
        public async Task<IActionResult> GetByClassification([FromRoute] int classification)
        {
        
            var obj = await _ProductServices.GetProductByClassification(classification);
            return Ok(obj);
        
        }
        
        [HttpGet]
        [Route("[controller]/GetBaseOnClassification/{classification}")]
        public async Task<IActionResult> GetBaseOnClassification([FromRoute] int classification)
        {
        
            var objs = await _ProductServices.GetProductBaseOnClassification(classification);
            return Ok(objs);
        
        }
        
        
        [HttpGet]
        [Route("[controller]/GetById/withAttributes/{id}")]
        public async Task<IActionResult> GetByIdWithAttributes([FromRoute] int id)
        {
        
            var obj = await _ProductServices.GetByIdWithAttributes(id);
            return Ok(obj);
        
        }
        

        [HttpPost]
        [Route("[controller]/Update/UnitOfPrice/")]
        public IActionResult UpdateUnitOfPrice()
        {
            return Ok("");
        }
        
        
        [HttpPost]
        [Route("[controller]/Update/UnitsOfStock/")]
        public async Task<IActionResult> UpdateUnitsOfStock(ProductUpdateUnitsInStockDTO dto)
        {

            var product = await _ProductServices.GetById(dto.Id);
            var IsIncreasingStock = _ProductServices.IsIncreasingProductUpdateUnitStock(dto);

            if (IsIncreasingStock)
                _ProductServices.IncreaseUnitsInStock( product, dto.Quantity); 
            else
                _ProductServices.DeacreaseUnitsInStock(product , dto.Quantity);

            await _Context.SaveChangesAsync();
            return Ok();

        }
        

        [HttpPost]
        [Route("[controller]/Add/")]
        public IActionResult AddProduct()
        {
        
            return Ok("");
        
        }
        

        [HttpPut]
        [Route("[controller]/Update/")]
        public IActionResult UpdateProduct()
        {
        
            return Ok("");
        
        }


        [HttpDelete]
        [Route("[controller]/Update/")]
        public async Task DeleteProduct([FromRoute] int id)
        {
        
            await _ProductServices.Delete(id);

        }

    }
}

  