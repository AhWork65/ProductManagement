

using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.Services.Dto.Attribute
{
    public class AttributeDto:DomainEntity
    {
        public AttributeDto()
        {

            Id = -1;
            ParentId = -1;
        }

    public string Name { get; set; }
    public string Value { get; set; }
   

    public int? ParentId { get; set; }

    }
}
