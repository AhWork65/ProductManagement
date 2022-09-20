using Microsoft.AspNetCore.Mvc;
using ProductManagement.Services.Services.IServices;

namespace ProductManagementWebApi.Controllers.Api
{
    
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _ProductServices;

        public ProductController(IProductServices productServices)
        {

            _ProductServices = productServices;

        }
        
        [HttpGet]
        [Route("[controller]/getall/")]
        public async Task<IActionResult> GetAll()
        {
        
            var objs = await _ProductServices.GetAll();
            return Ok(objs);
        
        }
        
        [HttpGet]
        [Route("[controller]/GetAll/Active/")]
        public async Task<IActionResult> GetAllActive()
        {
        
            var objs = await _ProductServices.GetAllActive();
            return Ok(objs);
        
        }

        
        [HttpGet]
        [Route("[controller]/GetAll/Inactive/")]
        public async Task<IActionResult> GetAllInactive()
        {
        
            var objs = await _ProductServices.GetAllInactive();
            return Ok(objs);
        
        }

        
        [HttpGet]
        [Route("[controller]/Get/ById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
        
            var obj = await _ProductServices.GetById(id);
            return Ok(obj);
        
        }
        

        [HttpGet]
        [Route("[controller]/Get/ByCode/{code}")]
        public async Task<IActionResult> GetByCode([FromRoute] string code)
        {
        
            var obj = await _ProductServices.GetProductByCode(code);
            return Ok(obj);
        
        }
        
        
        [HttpGet]
        [Route("[controller]/Get/CategoryId/{categoryId}/")]
        public async Task<IActionResult> GetByCategory([FromRoute] int categoryId)
        {
        
            var obj = await _ProductServices.GetProductByCategory(categoryId);
            return Ok(obj);
        
        }
        
        
        [HttpGet]
        [Route("[controller]/Get/Classification/{classification}")]
        public async Task<IActionResult> GetByClassification([FromRoute] int classification)
        {
        
            var obj = await _ProductServices.GetProductByClassification(classification);
            return Ok(obj);
        
        }
        
        
        [HttpGet]
        [Route("[controller]/Get/byId/with/Attributes/{id}")]
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
        public IActionResult UpdateUnitsOfStock()
        {
        
            return Ok("");
        
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

  