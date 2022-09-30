using ProductManagement.Domain.Enums;
using ProductManagementDomain.Models.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProductManagement.Domain.Dto.Attribute;
using ProductManagement.Domain.Models;

namespace ProductManagementWebApi.Models
{
    public partial class Product : DomainEntity
    {
        public Product()
        {
            ProductAttributeDetails = new HashSet<ProductAttributeDetail>();
            RelatedProductBaseProducts = new HashSet<RelatedProduct>();
            RelatedProductRelatedProductNavigations = new HashSet<RelatedProduct>();
        }

        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitStock { get; set; }
        public int CategoryId { get; set; }

        [Range(0 , 3 )]
        public int Classification { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int BaseUnitPrice { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProductAttributeDetail> ProductAttributeDetails { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProductBaseProducts { get; set; }
        public virtual ICollection<RelatedProduct> RelatedProductRelatedProductNavigations { get; set; }

        public IEnumerable<AttributeDto> AttributeList => from att in ProductAttributeDetails select new AttributeDto{
         Id  = att.Attribute.Id, Name = att.Attribute.Name , Value = att.Attribute.Value , ParentId = att.Attribute.ParentId
        };

    }
}
