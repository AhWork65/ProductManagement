using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Models.Base
{
    public class BaseModelResult<TModel>
    {
        public TModel result { get; set; }
        public bool Issuccess { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
