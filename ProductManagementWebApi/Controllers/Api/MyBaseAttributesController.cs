using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Domain.Models.Base;

namespace ProductManagementWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    
    [ApiController]
    public class MyBaseAttributesController : ControllerBase
    {
        protected BaseModelResult<TResult> careateModelResult<TResult>(TResult tResult)
        {
            return new BaseModelResult<TResult>()
            {
                Issuccess = true,
                ErrorCode = 0,
                ErrorMessage = String.Empty,
                result = tResult
            };
        }

        protected BaseModelResult<TResult> InvalidResult<TResult>(int errorcode, string message)
        {
            return new BaseModelResult<TResult>()
            {
                Issuccess = false,
                ErrorCode = 1,
                ErrorMessage = message
            };
        }
    }
}
