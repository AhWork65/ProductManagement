using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Dto.RelatedProducts
{
    public class RelatedProductsCreationDTO
    {
        public int BaseProductId { get; set; }
        public int RelatedProductId { get; set; }
    }
}
