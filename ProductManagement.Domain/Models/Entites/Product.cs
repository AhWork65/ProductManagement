
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagementDomain.Models.Entites
{
    public partial class Product: DomainEntityActive
    {
        public Product()
        {
            ProductAttributeDetails = new HashSet<ProductAttributeDetail>();
            RelatedProductBaseProducts = new HashSet<RelatedProduct>();
            RelatedProductRelatedProductNavigations = new HashSet<RelatedProduct>();
        }

        
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitStock { get; set; }
        public int CategoryId { get; set; }
        public int Classification { get; set; }
        public int UnitPrice { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductAttributeDetail> ProductAttributeDetails { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProductBaseProducts { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProductRelatedProductNavigations { get; set; }
    }
}
