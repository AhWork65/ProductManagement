using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementWebApi.Models
{
    public class AttributeDto
    {
        public AttributeDto()
        {

            ParentId = 0;
        }

        public string Name { get; set; }

        //public string Value { get; set; }

        public int? ParentId { get; set; }

    }
}
