using System.Linq.Expressions;

namespace ManagementProductProject.Services.IServices.IDataServices.Base
{
    public interface IDataService<TEntity> where TEntity : class
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate);


    }
}
