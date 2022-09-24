using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.DataAccess.AppContext;
using ProductManagement.Domain.Models;
using ProductManagement.Services.Service.CategoryService;
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
        [Route("[controller]/Add")]
        public async Task<IActionResult> Add([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Category modalResult;


            try
            {
                modalResult  = await _CategoryService.Create(category);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

           return Ok(modalResult);
        }


        [HttpPut]
        [Route("[controller]/UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            try
            {
                await _CategoryService.Update(category);
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
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
        [Route("[controller]/Delete/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            try
            {
                await _CategoryService.Delete(id);
            }
            catch (EntryPointNotFoundException e)
            {
                return NotFound(new { message = e.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            
            return Ok();

        }
        [HttpGet]
        [Route("[controller]/GetActiveChildCategory/{id}")]
        public async Task<IActionResult> GetActiveChildCategory([FromRoute] int id)
        {

            var objs = await _CategoryService.GetActiveChildCategory(id);
            return Ok(objs);

        }

        [HttpGet]
        [Route("[controller]/GetInactiveChildCategory/{id}")]
        public async Task<IActionResult> GetInactiveChildCategory([FromRoute] int id)
        {

            var objs = await _CategoryService.GetInactiveChildCategory(id);
            return Ok(objs);

        }
    }
}
