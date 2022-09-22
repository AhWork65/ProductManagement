using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Services.Dto.Attribute
{
    public class AttributeDto
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public int? ParentId { get; set; }

    }
}
