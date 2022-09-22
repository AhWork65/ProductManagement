using ProductManagementDomain.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementWebApi.Models
{
    public  class Attribute : DomainEntity
    {
      
        public int Id { get; set; }
        public string Name { get; set; } = null!;
      
        public int? ParentId { get; set; }
        [InverseProperty("ValuesAttributes")]
        public Attribute Parent { get; set; }
        public string Value { get; set; } = null!;


        [InverseProperty("Parent")]
        public virtual ICollection<Attribute> ValuesAttributes { get; set; }
        public virtual ICollection<ProductAttributeDetail> ProductAttributeDetails { get; set; }
    }
}
