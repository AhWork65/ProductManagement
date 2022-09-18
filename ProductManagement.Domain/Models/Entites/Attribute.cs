namespace ProductManagementDomain.Models.Entites
{
    public partial class Attribute
    {
        public Attribute()
        {
            ProductAttributeDetails = new HashSet<ProductAttributeDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }
        public string Value { get; set; } = null!;

        public virtual ICollection<ProductAttributeDetail> ProductAttributeDetails { get; set; }
    }
}
