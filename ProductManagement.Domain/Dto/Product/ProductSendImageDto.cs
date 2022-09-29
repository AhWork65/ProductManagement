using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProductManagement.Domain.Dto.Product
{
    public class ProductSendImageDto
    {
        public int RecivedID { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
