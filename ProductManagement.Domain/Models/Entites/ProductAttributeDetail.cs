using System;
using System.Collections.Generic;

namespace ProductManagementDomain.Models.Entites
{
    public partial class ProductAttributeDetail
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int ProductId { get; set; }
        public int AddPrice { get; set; }

        public virtual Attribute Attribute { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
