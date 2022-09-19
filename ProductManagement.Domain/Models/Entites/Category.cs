using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagementDomain.Models.Entites
{
    public partial class Category: DomainEntityActive
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }

        public virtual Category Parent { get; set; } = null!;
        public virtual ICollection<Category> InverseParent { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
