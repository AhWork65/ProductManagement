using ProductManagementDomain.Models.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementWebApi.Models
{
    public partial class ProductAttributeDetail : DomainEntity
    {
        public int AttributeId { get; set; }
        public int ProductId { get; set; }
        public int AddedUnitPrice { get; set; }

        public virtual Attribute Attribute { get; set; } = null!;
        [NotMapped]
        public virtual Product Product { get; set; } = null!;
    }
}
