

namespace ProductManagement.Services.Dto.Attribute
{
    public class AttributeDto
    {
        public AttributeDto()
        {
            Id = -1;

           ParentId = 0;
    }

    public string Name { get; set; }

    public int Id { get; set; }

    public int? ParentId { get; set; }

    }
}
