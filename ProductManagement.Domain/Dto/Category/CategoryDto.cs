using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.Domain.Dto.Category
{
    public class CategoryDto:DomainEntity
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? ParentId { get; set; }
        public bool? IsActive { get; set; }
    }
}
