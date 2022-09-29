using ProductManagementWebApi.Models;

namespace ProductManagement.Domain.Dto.Product
{
    public class ProductDetailDTO
    {

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitStock { get; set; }
        public int CategoryId { get; set; } 
        public int Classification { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int BaseUnitPrice { get; set; }
        public virtual ICollection<ProductAttributeDetail> ProductAttributeDetails { get; set; }

    }
}
