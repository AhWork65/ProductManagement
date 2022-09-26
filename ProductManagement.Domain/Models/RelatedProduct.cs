using ProductManagementDomain.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementWebApi.Models
{
    public partial class RelatedProduct : DomainEntity
    {
        public int Id { get; set; }
        public int BaseProductId { get; set; }
        public int RelatedProductId { get; set; }

        public virtual Product BaseProduct { get; set; } = null!;
        public virtual Product RelatedProductNavigation { get; set; } = null!;
    }
}
