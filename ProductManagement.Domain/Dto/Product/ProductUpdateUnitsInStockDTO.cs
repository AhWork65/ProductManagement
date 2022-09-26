using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Dto.Product
{
    public class ProductUpdateUnitsInStockDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public byte State { get; set; }
    }
}
