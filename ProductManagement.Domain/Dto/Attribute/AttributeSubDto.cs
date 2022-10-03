using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.Domain.Dto.Attribute
{
   public class AttributeSubDto:DomainEntity
    {
        public AttributeSubDto()
        {
            Id = 0;
            ParentId = -1;
            subNodes = new HashSet<AttributeSubDto>();
        }
        public string Name { get; set; }
        public string Value { get; set; }

        public int? ParentId { get; set; }
        public virtual ICollection<AttributeSubDto> subNodes { get; set; }
    }
}
