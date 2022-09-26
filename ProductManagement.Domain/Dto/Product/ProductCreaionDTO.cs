
using ProductManagement.Domain.Dto.Product;

namespace ProductManagement.Services.Domain.Product
{
    public class ProductCreaionDTO 
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitStock { get; set; }
        public int CategoryId { get; set; }
        public int Classification { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        public int BaseUnitPrice { get; set; }
        public IList<ProductAttributesDTO> Attributes { get; set; }
    }
}
