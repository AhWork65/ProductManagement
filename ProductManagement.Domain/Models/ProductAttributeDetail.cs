using ProductManagementDomain.Models.BaseEntities;
using System;
using System.Collections.Generic;

namespace ProductManagementWebApi.Models
{
    public partial class ProductAttributeDetail : DomainEntity
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int ProductId { get; set; }
        public int AddedUnitPrice { get; set; }

        public virtual Attribute Attribute { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
