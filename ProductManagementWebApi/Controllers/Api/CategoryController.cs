using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Services.Service.Services;
using ProductManagementWebApi.Models;

namespace ProductManagementWebApi.Controllers.Api
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _CategoryService;

        public CategoryController
        (ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        [HttpPost]
        [Route("[controller]/PostCategory")]
        public async Task<IActionResult> PostCategory([FromBody] Category category)
        {
            await _CategoryService.Create(category);
            return Ok();
        }

        [HttpGet]
        [Route("[controller]/GetUpdateCategory")]
        public async Task<IActionResult> GetUpdateCategory([FromBody] Category category)
        {
            await _CategoryService.Update(category);
            return Ok();
        }





        [HttpGet]
        [Route("[controller]/GetAll")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _CategoryService.GetAll());

        }


        [HttpGet]
        [Route("[controller]/GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {

            var objs = await _CategoryService.GetAllActive();
            return Ok(objs);
        }


        [HttpGet]
        [Route("[controller]/GetAllInactive")]
        public async Task<IActionResult> GetAllInactive()
        {

            var objs = await _CategoryService.GetAllInactive();
            return Ok(objs);
        }


        [HttpGet]
        [Route("[controller]/GetById/{id:int}")]
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
        [HttpGet]
        [Route("[controller]/GetActiveChildCategory/{id:int}")]
        public async Task<IActionResult> GetActiveChildCategory([FromRoute] int id)
        {

            var objs = await _CategoryService.GetActiveChildCategory(id);
            return Ok(objs);

        }

        [HttpGet]
        [Route("[controller]/GetInactiveChildCategory/{id:int}")]
        public async Task<IActionResult> GetInactiveChildCategory([FromRoute] int id)
        {

            var objs = await _CategoryService.GetInactiveChildCategory(id);
            return Ok(objs);

        }
    }
}
