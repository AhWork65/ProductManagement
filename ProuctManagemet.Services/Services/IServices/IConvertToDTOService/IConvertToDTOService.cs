namespace ManagementProductProject.Services.IServices.IConvertToDTOService
{
    public interface IConvertToDTOService<TEntity , TEntityDTO>
    {

        TEntityDTO Convert(TEntity entity );
        IEnumerable<TEntityDTO> Convert(IEnumerable<TEntity> entity);

    }
}
