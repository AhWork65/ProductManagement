
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.Domain.Dto.Product
{
    public class ProductDTO : DomainEntity

    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitStock { get; set; }
        public int CategoryId { get; set; }

        [Range(1, 3)]
        public int Classification { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int BaseUnitPrice { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
