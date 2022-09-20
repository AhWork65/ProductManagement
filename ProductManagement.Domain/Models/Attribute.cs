using System;
using System.Collections.Generic;

namespace ProductManagementWebApi.Models
{
    public  class Attribute
    {
      
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }
        public string Value { get; set; } = null!;

        public virtual ICollection<ProductAttributeDetail> ProductAttributeDetails { get; set; }
    }
}
