using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Dto.Product
{
    public  class ProductAttributesDTO
    {
        public int AttributeId { get; set; }
        public int ProductId { get; set; }
        public int AddedUnitPrice { get; set; }

    }
}
