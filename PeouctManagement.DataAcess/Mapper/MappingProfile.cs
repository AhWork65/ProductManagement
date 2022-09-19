

using AutoMapper;
using ProductManagementDomain.Models.DTOs;
using ProductManagementDomain.Models.Entites;

namespace ManagementProductProject.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>(); 
        }

    }
}
