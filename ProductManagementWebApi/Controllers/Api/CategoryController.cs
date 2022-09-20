using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.AppContext;

namespace ProductManagementWebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly Management_ProductsContext _Context;

        public CategoryController(Management_ProductsContext context)
        {
            _Context = context; 
        }

        [HttpGet]
        [Route("[controller]/GetAllCategories")]
        public IActionResult GetAll()
        {

            return Ok(_Context.Categories.ToList()); 

        }
    }
}
