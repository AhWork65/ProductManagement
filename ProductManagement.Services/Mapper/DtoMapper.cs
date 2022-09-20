using AutoMapper;

namespace ProuctManagemetServices.Services.Mapper
{
    public static class DtoMapper
    {
        private static TDto MapTo<TEntity, TDto>(TEntity entity)
        {
            var mappingConfig = new MapperConfiguration(config=>
            {
                config.CreateMap<TEntity, TDto>();
            });

            var mapper = mappingConfig.CreateMapper();

            return mapper.Map<TDto>(entity);
        }

        private static IEnumerable<TDto>  ListMapTo <TEntity, TDto>(IEnumerable<TEntity>  entity)
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
