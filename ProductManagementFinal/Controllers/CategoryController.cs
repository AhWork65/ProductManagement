using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagementDomain.Models.DTOs;
using ProductManagementDomain.Models.Entites;
using ProuctManagemetServices.Services.IServices;

namespace ManagementProductProject.Controllers.Api
{

    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        private readonly IActiveableEntitesDataService<Category> _CategorDataService;

        public CategoryController
            (
            IActiveableEntitesDataService<Category> categorDataService ,
            IMapper mapper
            )
        {
            
            _CategorDataService = categorDataService;
           
        }

        [HttpPost]
        [Route("category/PostCategory")]
        public async Task<IActionResult> PostCategory([FromBody]Category category)
        {
           await _CategorDataService.Create(category);
           return  Ok();
        }


        [HttpDelete]
        [Route("category/DeleteCategoryById/{id}")]
        public async Task<IActionResult> DeleteCategoryById([FromRoute] int id)
        {
            await _CategorDataService.DeleteById(id);
            return Ok();
        }
        [HttpPost]
        [Route("category/DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromBody] Category category)
        {
            await _CategorDataService.Delete(category);
            return Ok();
        }



        [HttpGet]
        [Route("category/GetAllCategory")]
        public async Task<IActionResult> GetAll()
        {
            
            var modelsObjects = await _CategorDataService.GetAll();
            return Ok(modelsObjects); 

        }

        [HttpGet]
        [Route("category/GetAllActive")]
        public async Task<IActionResult> GetAllActive()
        {

            var modelsObjects = await _CategorDataService.GetActiveList();

            return Ok(modelsObjects);

        }


        [HttpGet]
        [Route("category/GetAllDeactive")]
        public async Task<IActionResult> GetAllDeactive()
        {

            var modelsObjects = await _CategorDataService.GetDeActivList();
            return Ok(modelsObjects); 

        }



        [HttpGet]
        [Route("category/GetByid/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var modelObj = await _CategorDataService.GetById(id);
                 return Ok(modelObj);

        }


        [HttpGet]
        [Route("category/getActiveByid/{id}")]
        public async Task<IActionResult> GetActiveById([FromRoute]int id )
        {

            var modelsObjects = await _CategorDataService.GetActiveById(id);
            return Ok(modelsObjects);

        }


        [HttpGet]
        [Route("category/getDeactiveByid/{id}")]
        public async Task<IActionResult> GetDeactiveById([FromRoute] int id)
        {

            var modelsObjects = await _CategorDataService.GetDeactiveById(id);
            return Ok(modelsObjects);

        }




        [HttpGet]
        [Route("category/getByCode/{code}")]
        public async Task<IActionResult> GetByCode([FromRoute] string code)
        {

            var modelObj = await _CategorDataService.FindEntity(mdl => mdl.Code == code );
            return Ok(modelObj);

        }


        [HttpGet]
        [Route("category/getActiveByCode/{code}")]
        public async Task<IActionResult> GetActiveByCode([FromRoute] string code)
        {
            
            var modelObj = await _CategorDataService.FindActiveEntity(mdl => mdl.Code == code);
            return Ok(modelObj);

        }


        [HttpGet]
        [Route("category/getDeactiveByCode/{code}")]
        public async Task<IActionResult> GetDeactiveByCode([FromRoute] string code)
        {

            var modelObj = await _CategorDataService.FindDeactiveEntity(mdl => mdl.Code == code);
            return Ok(modelObj);

        }
    }
}
