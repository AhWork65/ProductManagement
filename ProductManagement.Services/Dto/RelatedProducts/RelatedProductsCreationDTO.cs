using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Dto.RelatedProducts
{
    public class RelatedProductsCreationDTO
    {
        public int BaseProductId { get; set; }
        public int RelatedProductId { get; set; }
    }
}
