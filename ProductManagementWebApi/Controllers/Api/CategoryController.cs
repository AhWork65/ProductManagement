using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Services.Service.Services;

namespace ProductManagementWebApi.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly Management_ProductsContext _Context;
        public readonly ICategoryService _CategoryService;

        public CategoryController
        (Management_ProductsContext context,
            ICategoryService categoryService
        )
        {
            _Context = context;
            _CategoryService = categoryService;
        }


        [HttpGet]
        [Route("[controller]/GetAll")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _CategoryService.GetAll());

        }


        [HttpGet]
        [Route("[controller]/GetAll/Active")]
        public async Task<IActionResult> GetAllActive()
        {

            var objs = await _CategoryService.GetAllActive();
            return Ok(objs);
        }


        [HttpGet]
        [Route("[controller]/GetAll/Inactive")]
        public async Task<IActionResult> GetAllInactive()
        {

            var objs = await _CategoryService.GetAllInactive();
            return Ok(objs);
        }


        [HttpGet]
        [Route("[controller]/Get/byId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var objs = await _CategoryService.GetById(id);
            return Ok(objs);

        }

        [HttpDelete]
        [Route("[controller]/Delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] int id)
        {

             await _CategoryService.Delete(id);
             return Ok(); 

        }
    }
}
