
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ProductManagement.Domain.Dto.Product;

namespace ProductManagement.Services.Domain.Product
{
    public class ProductCreationDto 
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int UnitStock { get; set; }
        public int CategoryId { get; set; }

        [Range(0 , 3 )]
        public int Classification { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
        [Range(0,  int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int BaseUnitPrice { get; set; }
        public IFormFile? Image { get; set; }
        public IList<ProductAttributesDTO> Attributes { get; set; }
    }
}
