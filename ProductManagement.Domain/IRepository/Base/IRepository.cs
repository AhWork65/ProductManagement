using System.Linq.Expressions;

namespace ProductManagementDomain.IRepository.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindEntity(Expression<Func<TEntity, bool>> predicate);

    }
}
