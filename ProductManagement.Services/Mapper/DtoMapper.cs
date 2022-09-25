using AutoMapper;
using ProductManagementDomain.Models.BaseEntities;

namespace ProductManagement.Services.Mapper
{
    public static class DtoMapper
    {
        public static TDto MapTo<TEntity, TDto>(TEntity entity) 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TEntity, TDto>();
            });

            var mapper = mappingConfig.CreateMapper();

            return mapper.Map<TDto>(entity);
        }

        public static IEnumerable<TDto> ListMapTo<TEntity, TDto>(IEnumerable<TEntity> entity)
        {

            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TEntity, TDto>();
            });

            var mapper = mappingConfig.CreateMapper();


            return entity.Select(item => mapper.Map<TDto>(item)).ToList();
        }
    }
}
