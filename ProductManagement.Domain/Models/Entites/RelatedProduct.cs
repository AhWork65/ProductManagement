using System;
using System.Collections.Generic;

namespace ProductManagementDomain.Models.Entites
{
    public partial class RelatedProduct
    {
        public int Id { get; set; }
        public int BaseProductId { get; set; }
        public int RelatedProductId { get; set; }

        public virtual Product BaseProduct { get; set; } = null!;
        public virtual Product RelatedProductNavigation { get; set; } = null!;

    }
}
