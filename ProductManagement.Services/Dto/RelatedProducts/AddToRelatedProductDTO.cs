using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Dto.RelatedProducts
{
    public class AddToRelatedProductDTO
    {
        public int RelatedProductId { get; set; }
        public int RelatedEntityId { get; set; }
    }
}
