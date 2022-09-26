using ProductManagementDomain.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementWebApi.Models
{
    public class Attribute : DomainEntity
    {

        public Attribute()
        {
            subNodes = new HashSet<Attribute>();
            ProductAttributeDetails = new HashSet<ProductAttributeDetail>();
        }


        public string Name { get; set; }
        public string Value { get; set; }
        public int? ParentId { get; set; }
        public virtual Attribute ParentNode { get; set; }
        public virtual ICollection<Attribute> subNodes { get; set; }
        public virtual ICollection<ProductAttributeDetail> ProductAttributeDetails { get; set; }
    }
}
