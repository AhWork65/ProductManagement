

using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.Services.Dto.Attribute
{
    public class AttributeDto
    {
        public AttributeDto()
        {

          
           ParentId = 0;
      }

    public string Name { get; set; }
    public string Value { get; set; }
   

    public int? ParentId { get; set; }

    }
}
