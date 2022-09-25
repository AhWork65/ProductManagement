using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Dto.Product
{
    public class ProductCreateDTO 
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitStock { get; set; }
        public int CategoryId { get; set; }
        public int Classification { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        public int BaseUnitPrice { get; set; }
    }
}
