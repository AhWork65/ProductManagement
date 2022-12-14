using ProductManagementDomain.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ProductManagementWebApi.Models;

namespace ProductManagement.Domain.Models
{
    public partial class Category : DomainEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
